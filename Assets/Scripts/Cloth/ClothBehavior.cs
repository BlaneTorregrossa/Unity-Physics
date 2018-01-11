using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// REWORK NEEDED
public class ClothBehavior : MonoBehaviour
{

    Blane.CreateCloth clothInstance;

    public List<Blane.Particle> particleList = new List<Blane.Particle>();
    public GameObject particleObject;
    public List<GameObject> particleObjectList = new List<GameObject>();

    public Blane.SpringDamper _springDamper = new Blane.SpringDamper();

    // Calls functions to create the cloth
    void Start()
    {
        GetParticlePos();
        SetClothParticles();
    }

    void Update()
    {

    }

    // Rethink how you are using this
    void GetParticlePos()
    {

    }

    // Sets the particles for the cloth to the given positions
    void SetClothParticles()
    {
        for (int m = 0; m < particleList.Count; m++)
        {
            particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);  // Set to sphere, effectivelly works as visual representation for a "point"

            Destroy(particleObject.GetComponent<Rigidbody>());  // To make sure Unity's rigidbodies aren't used for the particles
            Destroy(particleObject.GetComponent<SphereCollider>());  // Destroys the Sphere Collider that's attached to the Sphere

            particleObject.transform.position = particleList[m].position;   // Set particle GameObject Positions
            particleObjectList.Add(particleObject); // List of all the Objects for the particles
            Debug.Log("Particle Object Placement: " + particleObjectList[m].transform.position.ToString()); // To help confirm that the gameobjects are in the correct position
        }
    }
    

    //  Update Size and Position of the particles
    void UpdateParticleObject(Vector3 Scale, Vector3 Pos)
    {
        for (int q = 0; q < particleList.Count; q++)
        {
            var p = particleList[q];
            p.position = Pos;
            p.size = Scale;
        }
    }

}
