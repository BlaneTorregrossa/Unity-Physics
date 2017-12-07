using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{

    [System.Serializable]
    public class Particle
    {
        public float mass;

        public Vector3 velocity;
        public Vector3 acceleration;
        public Vector3 position;
        public Vector3 force;
        public Vector3 startingPosition;

        public void Initilize()
        {
            mass = 1;
            velocity = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
            position = new Vector3(0, 0, 0);
            force = new Vector3(0, -9.81f, 0);
        }

        public Vector3 Update(float deltaTime)
        {
            acceleration = force / mass;
            velocity += acceleration * deltaTime;
            position += velocity * deltaTime;

            #region area test control
            if (Input.GetKey(KeyCode.UpArrow))
            {
                position.y++;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                position.y--;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                position.x--;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                position.x++;
            }
            #endregion

            return position;
        }

        public Vector3 AddForce(Vector3 newForce)
        {
            return force += newForce;
        }


    }

}