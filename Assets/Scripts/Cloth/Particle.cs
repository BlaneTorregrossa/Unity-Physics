using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{

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
            velocity += acceleration * deltaTime;
            position += velocity * deltaTime;

            return position;
        }
    }

}