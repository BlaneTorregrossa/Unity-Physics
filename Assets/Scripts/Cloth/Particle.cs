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
        public Vector3 size;
        //public Vector3 startingPos

        // everything except position and mass is set to be a zeroed out
        public void Initilize(Vector3 POS)
        {
            mass = 1;
            size = new Vector3(1, 1, 1);
            velocity = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
            position = POS;
            force = new Vector3(0, 0, 0);
            //startingPos = POS;
        }

        // Updates Particle Position based on velocity and deltaTime
        public Vector3 Update(float deltaTime)
        {
            acceleration = force / mass;
            velocity += acceleration * deltaTime;
            position += velocity * deltaTime;
            force = new Vector3(0, 0, 0);
            return position;
        }

        // Adds Force to Particle, Function returned a vector3 at one point
        public void AddForce(Vector3 newForce)
        {
            force += newForce;
        }

        public Vector3 Update_Position(Vector3 newPos)
        {
            position = newPos;
            return position;
        }
    }

}