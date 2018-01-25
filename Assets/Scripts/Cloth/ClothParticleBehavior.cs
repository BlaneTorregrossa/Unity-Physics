using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothParticleBehavior : MonoBehaviour
{

    public Blane.ClothParticle CurrentParticle = new Blane.ClothParticle();

    void Start()
    {
        
    }

    void Update()
    {
        CurrentParticle.position = transform.position;
        transform.position = CurrentParticle.Update(Time.deltaTime);
    }
}
