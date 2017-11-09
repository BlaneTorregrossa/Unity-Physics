using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{

}


[CreateAssetMenu]
public abstract class Agent : ScriptableObject
{
    public float mass;
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 position;
    public float max_Speed;

    public void Add_Force(float a, Vector3 b)
    {

    }

}
