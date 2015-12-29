using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class StaticGameObjects:MonoBehaviour
{
    private GameObject[] listOfObjects;
    private int itemsInList;
    private int sizeOfList;

    public StaticGameObjects() : this (0){ }
    public StaticGameObjects(int size)
    {
        sizeOfList = size;
        itemsInList = 0;
        listOfObjects = new GameObject[sizeOfList];
    }
    public StaticGameObjects(int numObjects, GameObject[] aList)
    {
        itemsInList = numObjects;
        sizeOfList = aList.Length;
        listOfObjects = aList;
        if(numObjects > 0)
            radixSort();
    }

    //binary search add ( case is nlog + n time )
    public void Add (GameObject item)
    {
        if(sizeOfList == itemsInList)
        {
            increaseListSize(32);
        }
        int index = search_x(item);

        for ( int i = itemsInList; i >= index; index--)
        {
            listOfObjects[i + 1] = listOfObjects[i];
        }
        listOfObjects[index] = item;
    }

    //finds the ideal index of where the most likely x value would be
    private int search_x (GameObject item)
    {
        int lower = 0, upper = itemsInList;

        while (lower <= upper)
        {
            int middle = (lower + upper) / 2;

            // item is greater than
            if (listOfObjects[middle].transform.position.x < item.transform.position.x)
            {
                lower = middle + 1;
            }
            // item is less than
            else if (listOfObjects[middle].transform.position.x > item.transform.position.x)
            {
                upper = middle - 1;
            }
            else
            {
                return middle;
            }
        }
        //if something terribly goes wrong
        return itemsInList;

    }
    //increase the array size by an n amount
    private void increaseListSize(int increase)
    {
        GameObject[] aList = new GameObject[sizeOfList + increase];
        sizeOfList += increase;

        for ( int i = 0; i < sizeOfList; i++)
        {
            aList[i] = listOfObjects[i];
        }

        listOfObjects = aList;
    }
    
    //deletes old list, adds new list, semi-sorts new list
    public void newList (GameObject[] list, int numOfItems)
    {
        for(int i = 0; i < itemsInList; i++)
        {
            Destroy(listOfObjects[i]);
        }
        listOfObjects = list;
        itemsInList = numOfItems;
        radixSort();


    }

    private void radixSort()
    {
        const long DECIMAL_FIXING = 1000000;
        long largestNumber = (long)listOfObjects[0].transform.position.x*DECIMAL_FIXING;
        for (int i = 0; i < itemsInList; i++)
        {
            if ((long)listOfObjects[i].transform.position.x*DECIMAL_FIXING > largestNumber)
                largestNumber = (long)listOfObjects[i].transform.position.x*DECIMAL_FIXING;
        }
        long power = 1;

        while (largestNumber / power > 0)
        {

            //declare a new array for the sorted list
            GameObject[] list2 = new GameObject[itemsInList];
            int[] radixArray = new int[10];

            //finds the base repersentaion of the digit location and adds to the radix list
            for (int i = 0; i < itemsInList; i++)
            {
                radixArray[(long)(listOfObjects[i].transform.position.x*DECIMAL_FIXING / power) % 10]++;
            }

            //adds the radix list onto eachother
            for (int i = 1; i < radixArray.Length; i++)
            {
                radixArray[i] = radixArray[i - 1] + radixArray[i];
            }

            //put the sorted items onto the list
            for (int i = itemsInList - 1; i > 0; i--)
            {
                list2[--radixArray[(long)(listOfObjects[i].transform.position.x*DECIMAL_FIXING / power) % 10]] = listOfObjects[i];
            }
            //replace list
            listOfObjects = list2;
            power = power * 10;
        }

    }
}