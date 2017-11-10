using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boid : Agent
{

    private Vector3 prevPos;
    private Vector3 prevVel;

    void Start()
    {

    }

    void Update()
    {
        prevPos = force;
        prevVel = velocity;
    }

    public void Initialize(float m, float ms)
    {
        mass = m;
        Max_Speed = ms;
        velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        acceleration = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        force = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
    }

    // Bad
    public bool Add_Force(float c)
    {
        bool check = false;


        return check;
    }

    // Update acceleration, velocity, and position
    // From Example
    public void Update_Agent(float deltaTime)
    {
        acceleration = force / mass;
        velocity += acceleration * deltaTime;
        Velocity = Vector3.ClampMagnitude(velocity, Max_Speed);
        Position += velocity * deltaTime;
    }

}
