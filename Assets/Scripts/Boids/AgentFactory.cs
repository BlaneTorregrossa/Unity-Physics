using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Note: The following changes can only be applied when DTO and Behaviors are set correctlly)
/// Changes needed (All set in a loop):
/// remove rigidbody from GameObject    *
/// Add the Boid Behavior as a component    
/// set boid field in the boid behavior component
/// add gameobject to list  *
/// add BoidBehavior to list    *
/// </summary>
public class AgentFactory : MonoBehaviour
{

    private GameObject Go;
    private List<Agent> agents;

    void Start()
    {

    }

    void Update()
    {

    }

    public void CreateAgents(int count)
    {
        foreach (Boid b in agents)
        {
            var go = Go;
            var bb = go.AddComponent<BoidBehavior>();
            var boid = ScriptableObject.CreateInstance<Boid>();
            agents.Add(boid);
            bb.SetMovable(boid);

        }
    }


    public List<Boid> GetBoids()
    {
        List<Boid> result = null;

        foreach (Boid b in agents)
        {
            result.Add(b);
        }

        return result;
    }


}
