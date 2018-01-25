using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class ClothParticle
    {
        [SerializeField] public float mass;
        [SerializeField] public Vector3 velocity;
        [SerializeField] public Vector3 acceleration;
        [SerializeField] public Vector3 position;
        [SerializeField] public Vector3 force;
        [SerializeField] public Vector3 size;


        //public ClothParticle(Vector3 POS, float M)
        //{
        //    force = new Vector3(0, 0, 0);
        //    position = POS;
        //    mass = M;
        //}

        // Updates Particle Position
        public Vector3 Update(float deltaTime)
        {
            acceleration = force / mass;
            velocity += acceleration * deltaTime;
            position += velocity * deltaTime;

            //// Safety net for particles going out of range
            //if (float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsNaN(position.z))
            //{
            //    Debug.Log("Particles position no longer avalible. ");
            //}

            return position;
        }

        // Modify Particle
        public void ModifyParticle(float M, Vector3 S, Vector3 P, Vector3 F, Vector3 V)
        {
            mass = M;
            size = S;
            position = P;
            force = F;
            velocity = V;
        }

        // Adds Force to Particle
        public void AddForce(Vector3 newForce)
        {
            force += newForce;
        }

        // Update particle Position
        public Vector3 Update_Position(Vector3 newPos)
        {
            position = newPos;
            return position;
        }

        // Update Particle Size
        public Vector3 Adjust_Size(int scale)
        {
            size = new Vector3(scale, scale, scale);
            return size;
        }
    }

}