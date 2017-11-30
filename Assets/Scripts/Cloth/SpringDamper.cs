using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class SpringDamper
    {
        public Particle p1, p2;
        private float Ks, Lo;

        public void Initialize(float springConst, float restLength, Particle particle, Particle particleAlt)
        {
            springConst = Ks;
            restLength = Lo;
            particle = p1;
            particleAlt = p2;
        }

        //Ks*Lo
        public Vector3 Update(float deltaTime)
        {

            return new Vector3(0, 0, 0);
        }
    }
}