using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBehavior : MonoBehaviour
{
    public float kCohesion;
    public float kDisruption;
    public float kAllignment;

    void Start()
    {
    }

    void Update()
    {

    }

    // Rule 1 *
    Vector3 Cohesion(Boid bI)
    {
        var seperation = new Vector3(0, 0, 0);

        return seperation;
    }

    // Rule 2 *
    Vector3 Dispurtion(Boid bI)
    {
        var center = new Vector3(0, 0, 0);

        return center;
    }

    // Rule 3 *
    Vector3 Allignement(Boid bI)
    {
        var allign = new Vector3(0, 0, 0);

        return allign;
    }

    // Change
    Vector3 SetGoal(Boid bI)
    {
        Vector3 Target = new Vector3(0, 0, 0);

        return Target;
    }

    // *
    Vector3 VelocityLimit(Boid bI)
    {
        Vector3 newVelocity = new Vector3(0, 0, 0);

        return newVelocity;
    }

    // *
    Vector3 BoundPosition(Boid bI)
    {
        Vector3 returnForce = new Vector3(0, 0, 0);

        return returnForce;
    }

    
}
