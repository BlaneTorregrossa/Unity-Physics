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

    public AABB objectA;
    public AABB objectB;
    public AABB objectC;
    public AABB objectD;

    private float currentMin;
    private float prevMin;

    void Start()
    {
        objectA.min.x = 1; objectA.max.x = 4;
        objectB.min.x = 0; objectB.max.x = 3;
        objectC.min.x = 3; objectC.max.x = 4;
        objectD.min.x = 2; objectD.max.x = 3;

        AxisList.Add(objectA); AxisList.Add(objectB);
        AxisList.Add(objectC); AxisList.Add(objectD);
        StartSort();
    }

    void Update()
    {
        SortAndSweep();
    }

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

    void SortAndSweep()
    {
        for(int i = 0; i < 4; ++i)
        {
            ActiveList.Add(AxisList[i]);
            for (int j = 0; j < 4; j++)
            {
                if (AxisList[i + 1] == ActiveList[j])
                {
                    Debug.Log("Overlap!");
                }

            }
        }
    }
}
