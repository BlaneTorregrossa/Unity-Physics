using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair
{
    public AABB rightObject;
    public AABB leftObject;
}

public class SweepAndPrune : MonoBehaviour
{
    public List<AABB> AxisList;
    public List<AABB> ActiveList;

    public AABB itemA; public AABB itemB; public AABB itemC; public AABB itemD;
    public GameObject cubeA; public GameObject cubeB; public GameObject cubeC; public GameObject cubeD;

    public AABB newItem;
    public AABB currentItem;

    private float currentMin;
    private float prevMin;

    void Start()
    {
        ActiveList.Clear();

        if(cubeA.activeSelf == true)
        {
            AxisList.Add(itemA);
        }

        if (cubeB.activeSelf == true)
        {
            AxisList.Add(itemB);
        }

        if (cubeC.activeSelf == true)
        {
            AxisList.Add(itemC);
        }

        if (cubeD.activeSelf == true)
        {
            AxisList.Add(itemD);
        }

        //StartSort();
        //or
        AxisList.Sort((AABB a, AABB b) => a.min.x.CompareTo(b.min.x));

    }

    void Update()
    {
        SortAndPrune();
    }

    // Sorts list from lowest x axis min to highest x axis min
    //void StartSort()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        currentMin = AxisList[i].min.x;
    //        if (currentMin < prevMin)
    //        {
    //            AABB temp;
    //            temp = AxisList[i - 1];
    //            AxisList[i - 1] = AxisList[i];
    //            AxisList[i] = temp;
    //        }
    //        prevMin = currentMin;
    //    }
    //    Debug.Log("Index 0 xMin: " + AxisList[0].min.x.ToString());
    //    Debug.Log("Index 1 xMin: " + AxisList[1].min.x.ToString());
    //    Debug.Log("Index 2 xMin: " + AxisList[2].min.x.ToString());
    //    Debug.Log("Index 3 xMin: " + AxisList[3].min.x.ToString());
    //}

    void SortAndPrune()
    {
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; j++)
            {

            }
        }
    }
}
