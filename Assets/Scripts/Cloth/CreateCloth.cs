using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blane
{

    public class CreateCloth
    {

        public Particle p;
        public List<Particle> _particleList = new List<Blane.Particle>();


        void Start()
        {
            CreateClothParticles();
        }

        void Update()
        {
            getParticleClothPos();
        }

        public void CreateClothParticles()
        {
            int xPosCounter = 0;
            int yPosCounter = 4;

            for (int n = 0; n < 16; n++)
            {
                p.position = new Vector3(xPosCounter * 10, yPosCounter * 10, 0);    // Set Position for each particle
                _particleList.Add(p);   // Add Particle to the list
                Debug.Log("Particle Position Placement Check: " + _particleList[n].position.ToString());
                xPosCounter++; // x position for the next particle

                if (xPosCounter >= 4)
                {
                    // Change x and y position for the next particle
                    yPosCounter--;
                    xPosCounter = 0;
                }
            }
        }

        public List<Particle> getParticleClothPos()
        {
            return _particleList;
        }
    }
}