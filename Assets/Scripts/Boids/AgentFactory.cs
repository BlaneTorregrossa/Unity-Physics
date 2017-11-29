﻿using System.Collections;
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



        public void CreateAgents(int count)
        {

            for (int i = 0; i < count; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Capsule); // Set object to be a capsule
                var b = ScriptableObject.CreateInstance<Boid>();
                var bb = go.AddComponent<BoidBehavior>();   // Add boid behaviour as a component

                //go.transform.position = new Vector3 (Random.Range(-5, 5), Random.Range(-5, 5), 0);
                b.Initialize(go.transform);
                bb.SetMovable(b);

                Destroy(go.GetComponent<Rigidbody>());  // Destroy rigidbody of the gameobject
                Destroy(go.GetComponent<CapsuleCollider>());    // Remove Default Collider

                agents.Add(b);
                bb.SetMovable(b);
                behaviors.Add(bb);  // ???

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
