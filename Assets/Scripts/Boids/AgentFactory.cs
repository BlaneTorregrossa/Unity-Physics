using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{

    public class AgentFactory : MonoBehaviour
    {

        public GameObject agent;

        public List<Agent> agents;      // List of agent not boid
        public List<BoidBehavior> behaviors;
        public List<GameObject> objects;

        public Agent leader;

        public void CreateAgents(int count)
        {

            for (int i = 0; i < count; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Capsule); // Set object to be a capsule
                var b = ScriptableObject.CreateInstance<Boid>();    // Create a new Boid
                var bb = go.AddComponent<BoidBehavior>();   // Add boid behaviour as a component to the gameobject

                go.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));   // Set Random Starting position for the boid
                b.Initialize(go.transform);     // Initialize boud values with a given object transform
                bb.SetMovable(b);

                Destroy(go.GetComponent<Rigidbody>());  // Destroy rigidbody of the gameobject
                Destroy(go.GetComponent<CapsuleCollider>());    // Remove Default Collider

                agents.Add(b);
                bb.SetMovable(b);
                behaviors.Add(bb);
                objects.Add(go);
            }

            // Choosing the leader
            leader = agents[Random.Range(0, count - 1)];
            leader.isLeader = true;

            // Assigning the leader gameobject's name 
            for (int j = 0; j < agents.Count; j++)
            {
                if (agents[j].isLeader == true)
                {
                    objects[j].name = "Leader";
                }
            }
        }

        public List<Boid> GetBoids()
        {
            List<Boid> result = new List<Boid>();
            foreach (Boid b in agents)
                result.Add(b);

            return result;
        }

    }

}
