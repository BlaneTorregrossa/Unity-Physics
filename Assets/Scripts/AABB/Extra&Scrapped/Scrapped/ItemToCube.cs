using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToCube : MonoBehaviour
{

    public List<GameObject> CubeList;

    public GameObject cubeA, cubeB, cubeC, cubeD;
    public AABB itemA, itemB, itemC, itemD;

	void Start ()
    {
        CubeList.Add(cubeA);
        CubeList.Add(cubeB);
        CubeList.Add(cubeC);
        CubeList.Add(cubeD);
    }

    void Update ()
    {
		
	}
}
