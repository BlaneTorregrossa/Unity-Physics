using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    [CreateAssetMenu]
    public abstract class Agent : ScriptableObject
    {
        public Vector3 Velocity;
        public Vector3 Position;

        [SerializeField] protected float mass;
        [SerializeField] protected Vector3 velocity;
        [SerializeField] protected Vector3 acceleration;
        [SerializeField] protected Vector3 force;
        [SerializeField] protected float max_speed;
    }
}