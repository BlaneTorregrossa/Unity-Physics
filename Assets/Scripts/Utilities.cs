using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utilities : MonoBehaviour
{
    public AABB box1;
    public AABB box2;

    private void Start()
    {
        TestOverlap(box1, box2);
    }

    // To test overlap of objects
    public bool TestOverlap(AABB I, AABB J)
    { 
        if (J.min.x >= I.min.x && J.min.x <= I.max.x)
        {
            Debug.Log("Overlap A!");
        }

        if (I.min.y >= J.min.y && I.min.y <= J.max.y)
        {
            Debug.Log("Overlap B!");
        }

        //if (J != I)
        //{
        //    Debug.Log("Box Overlaps!");
        //}

        return true;
    }

}
