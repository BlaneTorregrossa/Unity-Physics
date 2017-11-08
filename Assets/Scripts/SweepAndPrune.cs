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
    public List<GameObject> CubeList; // List for the gameobjects

    public AABB itemA, itemB, itemC, itemD; // items for list
    public GameObject cubeA, cubeB, cubeC, cubeD;   // gameobjects paired with items
    public Pair pairA, pairB, pairC, pairD; // pairs for list

    public AABB newItem;    // for comparison
    public AABB currentItem;    // for comparison
    public Pair newPair;    // for adding a pair to the list

    private float currentMin; // for sort function
    private float prevMin;  // for sort function
    private int count;  // for while loops
    private bool check; // for if statement to be skipped after 1st call
    private int pairPlacement;
    private int CurrentPair;


    void Start()
    {
        //Clear the lists
        AxisList.Clear();
        ActiveList.Clear();
        PairList.Clear();

        pairPlacement = 0;
        check = false;
        count = 0;

        // Filling PairList
        PairList.Add(pairA);
        PairList.Add(pairB);
        PairList.Add(pairC);
        PairList.Add(pairD);

        #region  Adds values to axis list
        if (cubeA.activeSelf == true && cubeB.activeSelf == true && cubeC.activeSelf == true && cubeD.activeSelf == true)
        {
            AxisList.Add(itemA);
            AxisList.Add(itemB);
            AxisList.Add(itemC);
            AxisList.Add(itemD);
        }
        #endregion

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
    }

    /// <summary>
    /// Current Result: [][AB][BC][]
    /// What I Expect: [AB][AC][BC][BD]
    /// Bad, but better.
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
            newPair = PairList[pairPlacement];

            if (count > 4)
            {
                Debug.Log("Count exceeded what it is supposed to. Given value: " + count.ToString());
            }

            // Current check for if items overlap
            else if (newItem.min.x < currentItem.max.x && newItem.max.x > currentItem.min.x)
            {
                if (newItem.min.y < currentItem.max.y && newItem.max.y > currentItem.min.y)
                {
                    newPair.leftObject = newItem;
                    newPair.rightObject = currentItem;

                    if (newPair.leftObject == newPair.rightObject)
                    {
                        newPair.leftObject = null;
                        newPair.rightObject = null;
                    }
                }
            }

            // set palcement of pairs in list
            if (count != 4)
            {
                PairList[pairPlacement] = newPair;

                if (PairList[pairPlacement] == newPair)
                {
                    pairPlacement++;
                }
            }


            count++;
        }

    }

    public void AssignCube()
    {
        for (int i = 0; i < 4; i++)
        {
        }
    }
}
