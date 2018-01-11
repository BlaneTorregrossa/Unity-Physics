using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class Particle
    {
        [SerializeField] public float mass;
        [SerializeField] public Vector3 velocity;
        [SerializeField] public Vector3 acceleration;
        [SerializeField] public Vector3 position;
        [SerializeField] public Vector3 force;
        [SerializeField] public Vector3 size;    // Not part of original design

        // everything except position and mass is set to be a zeroed out
        void Start()
        {
            mass = 1;
            size = new Vector3(1, 1, 1);
            velocity = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
            force = new Vector3(0, 0, 0);
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

        // Adds Force to Particle
        public void AddForce(Vector3 newForce)
        {
            force += newForce;
        }

        // ***
        public Vector3 Update_Position(Vector3 newPos)
        {
            position = newPos;
            return position;
        }

        // ***
        public Vector3 Adjust_Size(int scale)
        {
            size = new Vector3(scale, scale, scale);
            return size;
        }
    }

}