using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    // Can't use any of this yet...
    public class FlockBehavior : MonoBehaviour
    {
        public float kCohesion;
        public float kDisruption;
        public float kAllignment;
        public AgentFactory factoryInstance;

        private List<Boid> boids;

        // Factory functiosn called here
        private void Start()
        {
            factoryInstance.CreateAgents(15);
        }

        private void Update()
        {
            boids = factoryInstance.GetBoids();
            MoveToNewPosition();
        }

        // Rule 1 
        private Vector3 Cohesion(Boid bI)
        {
            var seperation = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                    seperation = seperation + b.Position;
            }

            seperation = seperation / (boids.Count - 1);
            return seperation;
        }

        // Rule 2 
        private Vector3 Dispurtion(Boid bI)
        {
            var center = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                {
                    if (Mathf.Sqrt(
                        (b.Position.x * 2) + (b.Position.y * 2) + (b.Position.z * 2)
                        - (bI.Position.x * 2) + (bI.Position.y * 2) + (bI.Position.z * 2))
                        < 100)
                    {
                        center = center - (b.Position - bI.Position);
                    }
                }
            }

            return center;
        }

        // Rule 3 
        private Vector3 Allignement(Boid bI)
        {
            var allign = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                    allign = allign + b.Velocity;
            }

            allign = (allign - bI.Velocity) / 8;
            return allign;
        }

        // Come back to Later
        private Vector3 SetGoal(Boid bI)
        {
            Vector3 Goal = new Vector3(0, 0, 0);

            return Goal;
        }

        // Check to see if velocity is higher than set limit
        private void VelocityLimit(Boid bI)
        {
            int Limit = 100;
            if (Mathf.Sqrt((bI.Velocity.x * 2) + (bI.Velocity.y * 2) + (bI.Velocity.z * 2)) > Limit)
            {
                bI.Velocity =
                    (bI.Velocity / Mathf.Sqrt((bI.Velocity.x * 2) + (bI.Velocity.y * 2) + (bI.Velocity.z * 2))) * Limit;
            }
        }

        // Set Boundries for boids (Can be changed)
        private Vector3 BoundPosition(Boid bI)
        {
            int Xmin = -100, Xmax = 100, Ymin = -100, Ymax = 100, Zmin = 0, Zmax = 0;
            Vector3 returnForce = new Vector3(0, 0, 0);

            #region Set boundries
            if (bI.Position.x < Xmin)
            {
                returnForce.x = 15;
            }
            if (bI.Position.x > Xmax)
            {
                returnForce.x = -15;
            }
            if (bI.Position.y < Ymin)
            {
                returnForce.y = 15;
            }
            if (bI.Position.y > Ymax)
            {
                returnForce.y = -15;
            }
            if (bI.Position.z < Zmin || bI.Position.z > Zmax)
            {
                bI.Position.z = 0;
            }
            #endregion

            return returnForce;
        }

        public void MoveToNewPosition()
        {
            Vector3 v1, v2, v3, v4, v5;


            foreach (Boid b in boids)
            {
                v1 = Cohesion(b);
                v2 = Dispurtion(b);
                v3 = Allignement(b);
                v4 = SetGoal(b);
                v5 = BoundPosition(b);

                b.Velocity = b.Velocity + v1 + v2 + v3 + v4 + v5;
                VelocityLimit(b);   // void function
                b.Position = b.Position + b.Velocity;
            }

        }
    }
}
