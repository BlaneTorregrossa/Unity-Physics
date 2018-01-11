using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Have to have this class change the particle Variables
// Trashed Class
public class ParticleUpdate : MonoBehaviour
{

    public Blane.Particle currentParticle;

    void Start()
    {
        currentParticle.size = transform.localScale;
        currentParticle.Initilize(transform.position);
    }

    void Update ()
    {
        //transform.localScale = currentParticle.size;    //  For use when Size is to be adjusted by the User *
        //transform.position = currentParticle.Update(Time.deltaTime);    //  To update Particle position with or without user Input ***
        //transform.position = currentParticle.Update_Position(new Vector3(5, 5));    //  To update Particle position with or without user Input ***
    }

    
    // List of particle values to be adjusted if User Chooses:
    // Mass
    // Particle Size (To a certain Degree)
    // Particle Position

}
