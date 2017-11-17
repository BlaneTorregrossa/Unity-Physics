using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class BoidBehavior : AgentBehavior
    {

        IMovable movable;

        public void CallInit(Transform t)
        {
            movable.Initialize(t);
        }

        public void SetMovable(IMovable mover)
        {
            movable = mover;
        }

        public void LateUpdate()
        {
            transform.position += movable.Update_Agent(Time.deltaTime);
        }

    }

}