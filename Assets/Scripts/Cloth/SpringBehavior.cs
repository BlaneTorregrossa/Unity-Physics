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

        int counter = 0;
        int altCounter = 0;

        //  Loop sets up particle objects to equal the position of the given particle
        for (int m = 0; m < 25; m++)
        {
            particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            particleObjectList.Add(particleObject);
            particleObjectList[m].transform.position = _cloth.particleList[m].position - new Vector3(counter, altCounter, 0);
            Debug.Log("2nd Particle Position Check: " + particleObjectList[m].transform.position.ToString());

            anchorObject = particleObjectList[m];
            anchorObjectList.Add(anchorObject);
            anchorObjectList[m].transform.position = _cloth.anchorList[m].position - new Vector3(counter - 1, altCounter, 0);
            if (counter >= 20)
            {
                counter = 0;
                altCounter += 5;
            }
            else
                counter += 5;
        }
    }


    // update particle position and force applied to particle
    void Update()
    {
        /// ***
        for (int p = 0; p < 25; p++)
        {
            _cloth.particleList[p].position = _cloth.Update_Position(p);
            _cloth.anchorList[p].position = _cloth.Update_Anchor_Position(p);

            particleObjectList[p].transform.position = _cloth.particleList[p].position;
            particleObjectList[p].transform.position = _cloth.anchorList[p].position;

            Debug.Log("particle Object Position" + particleObjectList[p].transform.position.ToString());
            Debug.Log("anchor Object Position" + anchorObjectList[p].transform.position.ToString());
        }
    }
}
