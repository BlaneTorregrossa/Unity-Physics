using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpringBehavior : MonoBehaviour
{

    public GameObject particleObject;
    public GameObject anchorObject;
    public Blane.Particle _particle;
    public Blane.Particle _particleAlt;
    public Blane.SpringDamper _springDamper;

    private List<Blane.Particle> particleList;
    private List<Blane.Particle> anchorList;
    private List<GameObject> particleObjectList;
    private List<GameObject> anchorObjectList;

    void Start()
    {
        _particle.Initilize();
        _particleAlt.Initilize();
        _springDamper.Initialize(1, 10, 1, _particle, _particleAlt);

        for (int i = 0; i < 36; i++)
        {
            particleList.Add(_particle);
            anchorList.Add(particleList[i - 1]);
        }

        for (int j = 0; j < 36; j++)
        {
            for (int n = 0; n < 36; n++)
            {
                particleList[j].position = particleList[n].position + new Vector3(0, 3, 0);
                if (particleList[j].position == new Vector3(particleList[j].position.x, 18, particleList[j].position.z))
                {
                    particleList[j].position = new Vector3(particleList[j].position.x + 1, 0, particleList[j].position.z);
                }
                _particle.startingPosition = _particle.position;
            }
        }

        // for the gameobjects in unity
        for (int m = 0; m < 36; m++)
        {
            
        }
    }

    void Update()
    {
        _particle.Update(Time.deltaTime);
        _particleAlt.Update(Time.deltaTime);
        particleObject.transform.position = _springDamper.p1.position;
        anchorObject.transform.position = _springDamper.p2.position;
        _springDamper.CalculateForce();

    }
}
