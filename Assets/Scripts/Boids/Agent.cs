using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class Agent : ScriptableObject
{

    public float mass;
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 position;
    public float Max_Speed;
    public float perch_Timer;
    public bool perched;


}
