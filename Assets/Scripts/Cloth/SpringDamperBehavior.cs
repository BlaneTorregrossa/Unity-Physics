using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringDamperBehavior : MonoBehaviour
{
    public MakeCloth _cloth = new MakeCloth();
    public Blane.SpringDamper springDamper;
    //public Blane.ClothParticle particleA, particleB;
    //public float springConst, restLength, dampingFactor;
    public GameObject particleObjectA, particleObjectB;


    void Start ()
    {
        _cloth.CreateClothParticles();
    }

    void Update ()
    {
       
    }
}
