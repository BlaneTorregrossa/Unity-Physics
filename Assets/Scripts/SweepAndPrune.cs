using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // Nothing using pair will be in inspector otherwise, due to this being a seperate class  
public class Pair   // Object that keeps two objects of type AABB as a designated left and right object
{
    public AABB rightObject;
    public AABB leftObject;
}

public class SweepAndPrune : MonoBehaviour
{
    public List<AABB> AxisList;     // Starting List
    public List<AABB> ActiveList;   // List after order is set
    public List<Pair> PairList;     // List for AABB pairs

    public AABB itemA, itemB, itemC, itemD; // items for list
    public GameObject cubeA, cubeB, cubeC, cubeD;   // objects paired with items
    public Pair pairA, pairB, pairC, pairD; // pairs for list

    public AABB newItem;    // for comparison
    public AABB currentItem;    // for comparison
    public Pair newPair;    // for adding a pair to the list

    private float currentMin; // for sort function
    private float prevMin;  // for sort function
    private int count;  // for while loops
    private bool check; // for if statement to be skipped after 1st call

    void Start()
    {
        //Clear the lists
        AxisList.Clear();
        ActiveList.Clear();
        PairList.Clear();
        
        // setting to 0, false, null
        check = false;
        count = 0;
        currentItem = null;

        // Filling PairList
        PairList.Add(pairA);
        PairList.Add(pairB);
        PairList.Add(pairC);
        PairList.Add(pairD);

        // Adds values to axis list
        if (cubeA.activeSelf == true && cubeB.activeSelf == true && cubeC.activeSelf == true && cubeD.activeSelf == true)
        {
            AxisList.Add(itemA);
            AxisList.Add(itemB);
            AxisList.Add(itemC);
            AxisList.Add(itemD);
        }

        StartSort();
        //or
        //AxisList.Sort((AABB a, AABB b) => a.min.x.CompareTo(b.min.x));

        Debug.Log("Axis List: " + AxisList.ToString());
    }

    // Sorting function is the only thing to be called right now
    void Update()
    {
        SortAndPrune();
    }

    // Sorts list from lowest x axis min to highest x axis min
    void StartSort()
    {
        for (int i = 0; i < 4; i++)
        {
            currentMin = AxisList[i].min.x;
            if (currentMin < prevMin)
            {
                AABB temp;
                temp = AxisList[i - 1];
                AxisList[i - 1] = AxisList[i];
                AxisList[i] = temp;
            }
            prevMin = currentMin;
        }
        Debug.Log("Index 0 xMin: " + AxisList[0].min.x.ToString());
        Debug.Log("Index 1 xMin: " + AxisList[1].min.x.ToString());
        Debug.Log("Index 2 xMin: " + AxisList[2].min.x.ToString());
        Debug.Log("Index 3 xMin: " + AxisList[3].min.x.ToString());
    }

    /// <summary>
    /// Bad, but better.
    /// Sets pairs but not in an order good for "collision."
    /// Current Result: [][AB][AD][CD]
    /// Should Be: [AB][CB][AD][CD]
    /// </summary>
    public void SortAndPrune()
    {
        if (check != true)
        {

            for (int i = 0; i < 4; i++)
            {
                // adds the items from axis list to active list
                ActiveList.Add(AxisList[i]);

                //if Active list is not empty compare current index with axis list
                if (ActiveList[0] != null)
                {

                    if (ActiveList.Contains(AxisList[i]))
                    {
                        Debug.Log("Match from both lists! From: " + AxisList[i].ToString());
                    }
                }

            }
            check = true;
        }

        while (count != 4)
        {
            currentItem = newItem;
            newItem = ActiveList[count];
            newPair = PairList[count];

            if (currentItem == null)
            {
                Debug.Log("CurrentItem is set to Null.");
            }

            #region Redo This
            // BAD (Consider Redoing this)
            else if (newItem.min.x > currentItem.min.x && newItem.max.x >= currentItem.max.x)
            {
                if ((newItem.min.y > currentItem.min.y && newItem.max.y >= currentItem.max.y) || (currentItem.min.y > newItem.min.y && currentItem.max.y >= newItem.max.y))
                {
                    newPair.leftObject = currentItem;
                    newPair.rightObject = newItem;
                }

            }

            else if (newItem.min.x >= currentItem.min.x && newItem.min.x < currentItem.max.x)
            {
                if (newItem.min.y >= currentItem.min.y && newItem.min.y < currentItem.max.y)
                {
                    newPair.leftObject = newItem;
                    newPair.rightObject = currentItem;
                }
            }

            //else if (currentItem.min.x > newItem.min.x && currentItem.max.x >= newItem.max.x)
            //{
            //    if (((newItem.min.y > currentItem.min.y && newItem.max.y >= currentItem.max.y)) || (currentItem.min.y > newItem.min.y && currentItem.max.y >= newItem.max.y))
            //    {
            //        newPair.leftObject = newItem;
            //        newPair.rightObject = currentItem;
            //    }
            //}

            //else if (currentItem.min.x >= newItem.min.x && currentItem.max.x <= newItem.max.x)
            //{
            //    if (currentItem.min.y >= newItem.min.y && currentItem.max.y <= newItem.max.y)
            //    {
            //        newPair.leftObject = currentItem;
            //        newPair.rightObject = newItem;
            //    }
            //}

            // EVEN WORSE (Consider scrapping this)
            if (count == 0)
            {
                //pairA = newPair;
                PairList[0] = newPair;
            }

            if (count == 1)
            {
                //pairB = newPair;
                PairList[1] = newPair;
            }

            if (count == 2)
            {
                //pairC = newPair;
                PairList[2] = newPair;
            }

            if (count == 3)
            {
                //pairD = newPair;
                PairList[3] = newPair;
            }

            count++;
            #endregion
        }
    }
}
