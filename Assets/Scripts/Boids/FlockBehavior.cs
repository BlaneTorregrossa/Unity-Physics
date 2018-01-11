using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class FlockBehavior : MonoBehaviour
    {
        public int agentCreateNum;  // Used for attempt to fix cohesion and Allignment
        public AgentFactory factoryInstance;

        private List<Boid> boids;

        // Factory functiosn called here
        private void Start()
        {
            agentCreateNum = 25;    // The amount of agents created for the secne
            factoryInstance.CreateAgents(agentCreateNum);   // Call for creating agents with given value for agents to create
        }

        private void Update()
        {
            boids = factoryInstance.GetBoids();     // Get Created boids
            MoveToNewPosition();    // For position Update
        }

        // Rule 1 *
        private Vector3 Cohesion(Boid bI)
        {

            Vector3 percievedCenter = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                    percievedCenter = percievedCenter + b.position;
            }

            percievedCenter = percievedCenter / (boids.Count - 1);
            return (percievedCenter - bI.position) / 100;
        }

        // Rule 2 *
        private Vector3 Dispurtion(Boid bI)
        {
            Vector3 center = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                {
                    if (Vector3.Magnitude(b.position - bI.position) < 3)
                    {
                        center = center - (b.position - bI.position);
                    }
                }
            }

            return center;
        }

        // Rule 3 *
        private Vector3 Allignement(Boid bI)
        {
            Vector3 percievedVelocity = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                    percievedVelocity = percievedVelocity + b.velocity;
            }

            percievedVelocity = percievedVelocity / (boids.Count - 1);

            return (percievedVelocity - bI.velocity) / 8;
        }

        // Come back to Later (Set Goal to a leader)
        private Vector3 SetGoal(Boid bI)
        {
            Vector3 Goal = new Vector3(0, -5, 0);

            return (Goal - bI.position) / 100;
        }

        // Limit for velocity variable
        private void VelocityLimit(Boid bI)
        {
            float Limit = 3f;
            if (bI.velocity.magnitude > Limit)
            {
                bI.velocity =
                    (bI.velocity /
                    bI.velocity.magnitude)
                    * Limit;
            }
        }

        // Set Boundries (Can Implement Perching if I had time)
        private Vector3 BoundPosition(Boid bI)
        {
            int Xmin = -100, Xmax = 100, Ymin = -100, Ymax = 100, Zmin = -100, Zmax = 100;
            Vector3 returnForce = new Vector3(0, 0, 0);

            #region Set boundries
            if (bI.position.x <= Xmin)
            {
                returnForce.x = 10;
            }
            else if (bI.position.x >= Xmax)
            {
                returnForce.x = -10;
            }
            if (bI.position.y <= Ymin)
            {
                returnForce.y = 10;
            }
            else if (bI.position.y >= Ymax)
            {
                returnForce.y = -10;
            }
            if (bI.position.z <= Zmin)
            {
                returnForce.z = 10;
            }
            else if (bI.position.z >= Zmax)
            {
                returnForce.z = -10;
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

                b.velocity = b.velocity + v1 + v2 + v3 + v4 + v5;   // Velocity set by Rules the boids are to "Follow" that were set in seperate functions
                VelocityLimit(b);   // Without this it's hard to keep visual track of the boids
                b.position = b.position + b.velocity;   // Position update with the new velocity
                Debug.Log(b.position.ToString());
            }

        }


    }
}
