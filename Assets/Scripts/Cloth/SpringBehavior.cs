using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// REWORK NEEDED
public class SpringBehavior : MonoBehaviour
{
    public Blane.CreateCloth _cloth = new Blane.CreateCloth();

    public Vector3 particlePosition;

    public GameObject particleObject;
    public GameObject anchorObject;

    public List<GameObject> particleObjectList = new List<GameObject>();
    public List<GameObject> anchorObjectList = new List<GameObject>();

    void Start()
    {
        _cloth.Initialize();
        _cloth.SetParticlePosition();

        //  CURRENT ISSUE: Particle list gets reset.
        //  Loop sets up particle objects to equal the position of the given particle
        for (int m = 0; m < 25; m++)
        {
            particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            particleObjectList.Add(particleObject);
            particleObjectList[m].transform.position = _cloth.particleList[m].position;
            Debug.Log("2nd Particle Position Check: " + _cloth.particleList[m].position.ToString());    // Is repeating values, Shouldn't be.

            anchorObject = particleObjectList[m];
            anchorObjectList.Add(anchorObject);
            anchorObjectList[m].transform.position = _cloth.anchorList[m].position;
        }

    }

    // update particle position and force applied to particle
    void Update()
    {
        for (int p = 0; p < 25; p++)
        {
            particleObjectList[p].transform.position = _cloth.particleList[p].position;

            //  ANCHOR BEING RE-ASSIGNED LIKE THIS SCREWS UP THE PARTICLE POSITION

            //anchorObjectList[p].transform.position = _cloth.anchorList[p].position;

            Debug.Log("particle Object Position" + particleObjectList[p].transform.position.ToString());
            //Debug.Log("anchor Object Position" + anchorObjectList[p].transform.position.ToString());
        }
    }
}
