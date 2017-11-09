using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : MonoBehaviour
{

    public GameObject boidAgentObject;

    public List<Boid> BoidList;
    public List<GameObject> boidObjectList;

    public int agentCounter;    // NO

    void Start()
    {
        agentCounter = 0;
    }

    void Update()
    {

    }

    // Rule 1 *
    Vector3 Cohesion(Boid bI)
    {
        var PercievedCenter = new Vector3(0, 0, 0);

        foreach (Boid b in BoidList)
        {
            if (b != bI)
            {
                PercievedCenter += b.position;
            }
        }

        PercievedCenter = PercievedCenter / (agentCounter - 1);

        return (PercievedCenter - bI.position) / 100;
    }

    // Rule 2 *
    Vector3 Dispurtion(Boid bI)
    {
        var center = new Vector3(0, 0, 0);

        foreach (Boid b in BoidList)
        {
            if (b != bI)
            {
                if (Mathf.Sqrt(
                    Mathf.Pow(b.position.x - bI.position.x, b.position.x - bI.position.x) +
                    Mathf.Pow(b.position.y - bI.position.y, b.position.y - bI.position.y))
                     < 100)
                {
                    center = center - (b.position - bI.position);
                }
            }
        }

        return center;
    }

    // Rule 3 *
    Vector3 Allignement(Boid bI)
    {
        var PercievedVelocity = new Vector3(0, 0, 0);

        foreach (Boid b in BoidList)
        {
            if (b != bI)
            {
                PercievedVelocity += b.velocity;
            }
        }

        PercievedVelocity = PercievedVelocity / (agentCounter - 1);

        return (PercievedVelocity = bI.velocity) / 100;
    }

    // Changing later
    Vector3 SetGoal(Boid bI)
    {
        Vector3 Target = new Vector3(10, 10, 0);


        return (Target - bI.position);
    }

    // *
    Vector3 VelocityLimit(Boid bI)
    {
        float VLimit = 100;

        if (Mathf.Sqrt(Mathf.Pow(bI.velocity.x, bI.velocity.x) + Mathf.Pow(bI.velocity.y, bI.velocity.y)) > VLimit)
        {
            bI.velocity = (bI.velocity / Mathf.Sqrt(
            Mathf.Pow(bI.velocity.x, bI.velocity.x)
            + Mathf.Pow(bI.velocity.y, bI.velocity.y)))
            * VLimit;
        }

        return bI.velocity;
    }

    // * 
    Vector3 BoundPosition(Boid bI)
    {
        int xMin, xMax, yMin, yMax, zMinMax;
        Vector3 returnForce = new Vector3(0, 0, 0);

        //not to keep
        xMin = 0; xMax = 50;
        yMin = 0; yMax = 50;
        zMinMax = 0; // since it's going to only be x and y axis, z will always be 0

        if (bI.position.z != zMinMax)
        {
            returnForce.z = 0;
        }   // 0
        if (bI.position.y < yMin)
        {
            returnForce.y = 5;
        }   // 5 Sets if perhed or not
        if (bI.position.y > yMax)
        {
            returnForce.y = -5;
        }   // -5
        if (bI.position.x < xMin)
        {
            returnForce.x = 5;
        }   // 5
        if (bI.position.x > xMax)
        {
            returnForce.x = -5;
        }   // -5

        return returnForce;
    }

    void MoveAllBoidsToNewPositions()
    {
        foreach (Boid b in BoidList)
        {
            var v1 = Cohesion(b);
            var v2 = Dispurtion(b);
            var v3 = Allignement(b);
            var v4 = SetGoal(b);
            var v5 = BoundPosition(b);

            b.velocity += b.velocity + v1 + v2 + v3 + v4 + v5;
            VelocityLimit(b);
            b.position += b.position + b.velocity;
        }
    }
}
