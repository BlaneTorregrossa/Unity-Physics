using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpringBehavior : MonoBehaviour
{

    public GameObject particleObject;
    public GameObject particleAltObject;
    public GameObject midPoint;

    public Blane.Particle _particle;
    public Blane.Particle _particleAlt;
    public Blane.SpringDamper _springDamper;

    void Start()
    {
        _particle.Initilize();
        _particleAlt.Initilize();
        _particle.position = new Vector3(0, -2, 0);
        particleObject.transform.position = _particle.position;
        particleAltObject.transform.position = _particleAlt.position;
    }

    void Update()
    {
        _particle.Update(Time.deltaTime);
        _particleAlt.Update(Time.deltaTime);
        particleObject.transform.position = _particle.position;
        particleAltObject.transform.position = _particleAlt.position;
    }
}
