using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utilities : MonoBehaviour
{

    public GameObject realBox1;
    public GameObject realBox2;
    public AABB box1;
    public AABB box2;

    private Vector3 scale1;
    private Vector3 scale2;

    private void Start()
    {
        TestOverlap(box1, box2);
    }

    // To test overlap of objects
    public bool TestOverlap(AABB I, AABB J)
    {
        if ((J.min.x > I.min.x && J.max.x >= I.max.x) || (I.min.x > J.min.x && I.max.x >= J.max.x))
        {
            if ((J.min.y > I.min.y && J.max.y >= I.max.y) || (I.min.y > J.min.y && I.max.y >= J.max.y))
            {
                scale1 = new Vector3((I.max.x), (I.max.y), 1);
                scale2 = new Vector3((J.max.x), (J.max.y), 1);
                Instantiate(realBox1).transform.localScale = scale1;
                Instantiate(realBox2).transform.localScale = scale2;
                Debug.Log("Overlap!");
                return true;
            }
        }

        return false;
    }

}
