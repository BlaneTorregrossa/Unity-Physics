using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{

    public interface IMovable
    {

        void Initialize(int m, int ms, Transform t);

        bool Add_Force(float magnitude, Vector3 Direction);

        // Update acceleration, velocity, and position
        Vector3 Update_Agent(float deltaTime);
    }


    public class Boid : Agent, IMovable
    {

        void IMovable.Initialize(int m, int ms, Transform t)
        {
            mass = m;
            max_speed = ms;
            velocity = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
            force = new Vector3(0, 0, 0);
            Position = t.position;
        }

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
            Velocity = Vector3.ClampMagnitude(velocity, max_speed);
            Position += Velocity * deltaTime;

            return Position;
        }
    }
}
