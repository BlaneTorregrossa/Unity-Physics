using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// REWORK NEEDED
public class SpringBehavior : MonoBehaviour
{
    public Blane.CreateCloth _cloth;
    public Vector3 particlePosition;

    public List<GameObject> particleObjectList = new List<GameObject>();
    public List<GameObject> anchorObjectList = new List<GameObject>();


    // sets up particle default positions and force as well as the lists
    void Start()
    {
        // for the gameobjects in unity
        for (int m = 0; m < 25; m++)
        {
            var particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            var anchorObject = particleObject;
            particleObjectList.Add(particleObject);
            anchorObjectList.Add(anchorObject);
        }
    }

    // *** update particle position and force applied to particle
    void Update()
    {
        for (int p = 0; p < 25; p++)
        {
            particleObjectList[p].transform.position = _cloth.particleList[p].position;
            anchorObjectList[p].transform.position = _cloth.anchorList[p].position;
        }
    }
}
