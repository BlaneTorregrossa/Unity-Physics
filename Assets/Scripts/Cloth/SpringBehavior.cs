using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Go trough Particle and SpringDamper script before coming back to this
/// Evreything needs revision here depending on how particle and SpringDamper are looking
/// </summary>
public class SpringBehavior : MonoBehaviour
{

    public GameObject particleObject;
    public GameObject particleAltObject;
    public GameObject anchorObject;

    public Blane.Particle _particle;
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
        _particle.position = new Vector3(0, 0, 0);
        particleObject.transform.position = _particle.position;

    }

    void Update()
    {
        _particle.Update(Time.deltaTime);
        particleObject.transform.position = _particle.position;
    }
}
