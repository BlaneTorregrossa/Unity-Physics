using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class BoidBehavior : MonoBehaviour
    {

        IMovable movable;

        public void SetMovable(IMovable mover)
        {
            movable = mover;
        }

        public void LateUpdate()
        {
            transform.position = movable.Update_Agent(Time.deltaTime);
        }

    }

}