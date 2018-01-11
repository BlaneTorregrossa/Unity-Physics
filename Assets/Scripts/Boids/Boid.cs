using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public interface IMovable
    {
        bool Add_Force(float magnitude, Vector3 Direction); 
        Vector3 Update_Agent(float deltaTime);
    }


    // Inherits from both Agent Class and the above interface
    public class Boid : Agent, IMovable
    {

        public void Initialize(Transform t)
        {
            mass = 1;
            max_speed = 50;

            velocity = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
            force = new Vector3(0, 0, 0);

            position = t.position;
        }

        // ***
        bool IMovable.Add_Force(float magnitude, Vector3 Direction)
        {
            bool check;

            if (magnitude != 0)
                check = true;
            else
                check = false;

            return check;
        }

        // Update acceleration, velocity, and position
        Vector3 IMovable.Update_Agent(float deltaTime)
        {
            acceleration = force / mass;
            velocity += acceleration * deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, max_speed);     // Clamp velocity to boid's max speed
            position += velocity * deltaTime;

            return position;
        }
    }
}
