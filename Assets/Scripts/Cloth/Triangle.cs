using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blane
{

    public class Triangle
    {
        [SerializeField] public ClothParticle p1, p2, p3;
        //[SerializeField] public float density;
        //[SerializeField] public float drag;

        // For new tirangles
        public Triangle(ClothParticle A, ClothParticle B, ClothParticle C)
        {
            p1 = A;
            p2 = B;
            p3 = A;
        }

    }

}