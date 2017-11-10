using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Agent : ScriptableObject
{
    public Vector3 Velocity;
    public Vector3 Position;

    protected float mass;
    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 force;
    protected float Max_Speed;
}
