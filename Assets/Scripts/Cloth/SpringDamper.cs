using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class SpringDamper
    {
        public Particle p1, p2;
        public float Ks, Kd, Lo;

        public SpringDamper()
        {
        }

        public void Initialize(float springConst, float restLength, float dampingFactor, Particle particle, Particle particleAlt)
        {
            Ks = springConst;
            Lo = restLength;
            Kd = dampingFactor;
            p1 = particle;
            p2 = particleAlt;
        }

        public void CalculateForce()
        {
            // Step 1
            Vector3 eMag = p2.position - p1.position;
            float l = Vector3.Magnitude(eMag);
            Vector3 e = eMag / l;

            // Step 2
            Vector3 v1 = p1.velocity, v2 = p2.velocity;
            float V1 = Vector3.Dot(e, v1);
            float V2 = Vector3.Dot(e, v2);

            // Step 3
            float fsd = -Ks * (Lo - l) - Kd * (V1 - V2);
            Vector3 f1 = fsd * e;
            Vector3 f2 = -f1;

            p1.AddForce(f1);
            p2.AddForce(f2);
        }
        

        


    }
}