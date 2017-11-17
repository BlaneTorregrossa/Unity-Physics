using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{

    /// <summary>
    /// Needed: 
    /// remove rigidbody from GameObject X
    /// Add the Boid Behavior as a component    X 
    /// set boid field in the boid behavior component   X
    /// add gameobject to list  X
    /// add BoidBehavior to list    (???)
    /// </summary>
    public class AgentFactory : MonoBehaviour
    {

        public List<Agent> agents;      // List of agent not boid
        public List<BoidBehavior> behaviors;
        public List<GameObject> objects;



        public void CreateAgents(int count)
        {

            for (int i = 0; i < count; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Capsule); // Set object to be a capsule
                var b = ScriptableObject.CreateInstance<Boid>();
                var bb = go.AddComponent<BoidBehavior>();   // Add boid behaviour as a component

                Destroy(go.GetComponent<Rigidbody>());  // Destroy rigidbody of the gameobject
                Destroy(go.GetComponent<CapsuleCollider>());    // Remove Default Collider

                agents.Add(b);
                bb.SetMovable(b);
                behaviors.Add(bb);  // ???

                bb.CallInit(go.transform);
                objects.Add(go);
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
