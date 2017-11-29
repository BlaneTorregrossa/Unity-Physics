using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBehavior : MonoBehaviour
{

    public GameObject particleObject;
    public GameObject particleAltObject;
    public GameObject anchorObject;

    public Blane.Particle _particle;
    public Blane.Particle _particleAlt;
    protected Vector3 anchorPos;
    protected float springConstant;
    protected float restLength;

    private Vector3 PullPosition;

    void Start()
    {
        restLength = 5;
        springConstant = 3;
        anchorPos = anchorObject.transform.position;

        _particle.Initilize();
        _particleAlt.Initilize();
        _particle.position = new Vector3(0, 0, 0);
        _particleAlt.position = new Vector3(3, 0, 0);
        particleObject.transform.position = _particle.position;
        particleAltObject.transform.position = _particleAlt.position;

    }

    // * Not how it should be 
    void CheckParticle(Blane.Particle p1, Blane.Particle p2, float ks, float lo)
    {
        float tempValue = ks * lo;

        if (p1.position.y < -lo)
        {
            PullPosition = p1.position;
            p1.force = new Vector3(0, tempValue / 2, 0);
        }

        if (p1.position.y > PullPosition.y / 2)
        {
            p1.force = new Vector3(0, -9.81f, 0);
        }

    }

    void Update()
    {
        _particle.Update(Time.deltaTime);
        _particleAlt.Update(Time.deltaTime);
        CheckParticle(_particle, _particleAlt, restLength, springConstant);
        particleObject.transform.position = _particle.position;
        particleAltObject.transform.position = _particleAlt.position;
    }
}
