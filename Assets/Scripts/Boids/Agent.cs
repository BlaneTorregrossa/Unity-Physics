using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    [CreateAssetMenu]
    public abstract class Agent : ScriptableObject
    {

        [SerializeField] public float mass;
        [SerializeField] public float max_speed;

        [SerializeField] public Vector3 velocity;
        [SerializeField] public Vector3 acceleration;
        [SerializeField] public Vector3 force;
        [SerializeField] public Vector3 position;

    }
}