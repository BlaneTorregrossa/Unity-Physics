//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class ClothBehavior : MonoBehaviour
//{
//    //public List<Blane.ClothParticle> particleList = new List<Blane.ClothParticle>();
//    public Blane.SpringDamper _springDamper = new Blane.SpringDamper();

//    public GameObject particleObject;
//    public List<GameObject> particleObjectList = new List<GameObject>();

//    void Start()
//    {
//        SetClothParticles();
//    }

//    // To call functions for changing particle size and position for both the particle and the gameObject for the particle
//    void Update()
//    {

//    }

//    // Sets the particles for the cloth to the given positions
//    //  ***: Need a better way to keep track of the initial Particle List
//    void SetClothParticles()
//    {

//        clothInstance.CreateClothParticles();   // Why is this causing problems ???

//        for (int m = 0; m < clothInstance._particleList.Count; m++)
//        {
//            particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);  // Set to sphere, effectivelly works as visual representation for a "point"

//            //Destroy(particleObject.GetComponent<Rigidbody>());  // To ensure that no Rigidbody is attached to the oarticle objects
//            Destroy(particleObject.GetComponent<SphereCollider>());  // Destroys the Sphere Collider that's attached to the Sphere

//            particleObjectList.Add(particleObject); // List of all the Objects for the particles
            
//            //  ***
//            particleObjectList[m].transform.position = clothInstance._particleList[m].position; // Assign the positions from the particle list to the particle objects

//            Debug.Log("Particle Object Placement: " + particleObjectList[m].transform.position.ToString()); // To help confirm that the gameobjects are in the correct position
//        }
//    }

//    //  Update Size and Position of the particles
//    void UpdateParticleObject(Vector3 Scale, Vector3 Pos)
//    {
//        for (int q = 0; q < clothInstance._particleList.Count; q++)
//        {
//            var p = clothInstance._particleList[q];
//            p.position = Pos;
//            p.size = Scale;
//        }
//    }
//}


