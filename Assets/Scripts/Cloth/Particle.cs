using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    
    // Good
    [System.Serializable]
    public class Particle
    {
        public float mass;

        public Vector3 velocity;
        public Vector3 acceleration;
        public Vector3 position;
        public Vector3 force;

        public void Initilize()
        {
            mass = 1;
            velocity = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
            position = new Vector3(0, 0, 0);
            force = new Vector3(0, -9.81f, 0);
        }

        public Vector3 Update(float deltaTime)
        {
            acceleration = force / mass;
            velocity = velocity + acceleration * deltaTime;
            position = position + velocity * deltaTime;

            return position;
        }

        public Vector3 AddForce(Vector3 newForce)
        {
            return force = force + newForce;
        }


    }

}