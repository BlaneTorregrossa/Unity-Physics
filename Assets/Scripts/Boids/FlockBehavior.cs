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
            agentCreateNum = 15;
            factoryInstance.CreateAgents(agentCreateNum);
        }

        private void Update()
        {
            boids = factoryInstance.GetBoids();
            MoveToNewPosition(); // *
        }

        // Rule 1 *
        private Vector3 Cohesion(Boid bI)
        {

            Vector3 percievedCenter = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                    percievedCenter = percievedCenter + b.Position;
            }

            percievedCenter = percievedCenter / (boids.Count - 1);
            return (percievedCenter - bI.Position) / 100;
        }

        // Rule 2 *
        private Vector3 Dispurtion(Boid bI)
        {
            Vector3 center = new Vector3(0, 0, 0);

            foreach (Boid b in boids)
            {
                if (b != bI)
                {
                    if (Mathf.Sqrt(
                        (((b.Position.x) - (bI.Position.x)) * 2
                        + ((b.Position.y) - (bI.Position.y)) * 2
                        + ((b.Position.z) - (bI.Position.z)) * 2
                        ))
                        < 100)
                    {
                        center = center - (b.Position - bI.Position);
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
                    percievedVelocity = percievedVelocity + b.Velocity;
            }

            percievedVelocity = percievedVelocity / (boids.Count - 1);

            return (percievedVelocity - bI.Velocity) / 8;
        }

        // Come back to Later
        private Vector3 SetGoal(Boid bI)
        {
            Vector3 Goal = new Vector3(0, 0, 0);

            return Goal;
        }

        // ***
        private void VelocityLimit(Boid bI)
        {
            float Limit = 1;
            if (Mathf.Sqrt(((bI.Velocity.x) + (bI.Velocity.y)) * 2) > Limit)
            {
                bI.Velocity =
                    (bI.Velocity /
                    Mathf.Sqrt(((bI.Velocity.x) + (bI.Velocity.y)) * 2))
                    * Limit;
                Debug.Log("Velocity should be reset");
            }
        }

        // Set Boundries ***
        private Vector3 BoundPosition(Boid bI)
        {
            int Xmin = -25, Xmax = 25, Ymin = -25, Ymax = 25, Zmin = -25, Zmax = 25;
            Vector3 returnForce = new Vector3(0, 0, 0);

            #region Set boundries
            if (bI.Position.x <= Xmin)
            {
                returnForce.x = 10;
            }
            else if (bI.Position.x >= Xmax)
            {
                returnForce.x = -10;
            }
            if (bI.Position.y <= Ymin)
            {
                returnForce.y = 10;
            }
            else if (bI.Position.y >= Ymax)
            {
                returnForce.y = -10;
            }
            if (bI.Position.z <= Zmin)
            {
                returnForce.z = 10;
            }
            else if (bI.Position.z >= Zmax)
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

                b.Velocity = b.Velocity + v1 + v2 + v3 + v4 + v5;
                VelocityLimit(b);
                b.Position = b.Position + b.Velocity;
                Debug.Log(b.Position.ToString());
            }

        }


    }
}
