using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Mess Needs to be Redone
public class SpringBehavior : MonoBehaviour
{
    public GameObject particleObject;
    public GameObject anchorObject;
    public Blane.Particle _particle;
    public Blane.Particle _anchor;
    public Blane.SpringDamper _springDamper;

    private List<Blane.Particle> particleList = new List<Blane.Particle>();
    private List<Blane.Particle> anchorList = new List<Blane.Particle>();
    public List<GameObject> particleObjectList = new List<GameObject>();
    public List<GameObject> anchorObjectList = new List<GameObject>();

    // sets up particle default positions and force as well as the lists
    void Start()
    {
        _particle.Initilize();
        _anchor.Initilize();
        _springDamper.Initialize(1, 10, 1, _particle, _anchor);

        for (int i = 0; i < 36; i++)
        {
            particleList.Add(_particle);
            //anchorList.Add(particleList[i + 1]);
        }

        anchorList[35] = particleList[0];

        for (int j = 0; j < 36; j++)
        {
            for (int n = 0; n < 36; n++)
            {
                particleList[n].position = particleList[j].position + new Vector3(0, 3, 0);
                if (particleList[n].position == new Vector3(particleList[n].position.x, 18, particleList[n].position.z))
                {
                    particleList[n].position = new Vector3(particleList[n].position.x + 1, 0, particleList[n].position.z);
                }
                particleList[n].startingPosition = particleList[n].position;
            }
        }

        // for the gameobjects in unity
        for (int m = 0; m < 36; m++)
        {
            particleObjectList.Add(particleObject);
            particleObjectList[m].transform.position = particleList[m].position;
            anchorObjectList.Add(anchorObject);
            anchorObjectList[m].transform.position = anchorList[m].position;
            Instantiate(particleObjectList[m]);
        }
    }



    // update particle position and force applied to particle
    void Update()
    {

        

        _particle.Update(Time.deltaTime);
        _anchor.Update(Time.deltaTime);
        _springDamper.CalculateForce();
        particleObject.transform.position = _springDamper.p1.position;
        anchorObject.transform.position = _springDamper.p2.position;
    }
}
