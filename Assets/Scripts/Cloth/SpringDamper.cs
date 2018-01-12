using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    // Entire Class based off of notes for spring Dampers
    public class SpringDamper
    {
        public ClothParticle p1, p2;
        public float Ks, Kd, Lo;

        public void Initialize(float springConst, float restLength, float dampingFactor, ClothParticle particle, ClothParticle particleAlt)
        {
            Ks = springConst;
            Lo = restLength;
            Kd = dampingFactor;
            p1 = particle;
            p2 = particleAlt;
        }

        // Calculates Force to apply to particle and the anchor of said particle
        public void CalculateForce()
        {
            // Step 1
            Vector3 particlePosDelta = p2.position - p1.position;   // was e
            float l = Vector3.Magnitude(particlePosDelta);
            Vector3 e = particlePosDelta / l;   // was e*

            // Step 2
            Vector3 v1 = p1.velocity;
            Vector3 v2 = p2.velocity;
            float V1 = Vector3.Dot(e, v1);
            float V2 = Vector3.Dot(e, v2);

            // Step 3
            float fsd = -Ks * (Lo - l) - Kd * (V1 - V2);
            Vector3 f1 = fsd * e;
            Vector3 f2 = -f1;

            // Added force
            p1.AddForce(f1);
            p2.AddForce(f2);
        }
    }
}