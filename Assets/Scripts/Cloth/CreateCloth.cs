using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blane
{

    public class CreateCloth
    {

        public ClothParticle p = new ClothParticle();
        public List<ClothParticle> _particleList = new List<ClothParticle>();

        void Start()
        {
            CreateClothParticles();
        }

        // Sets up particles for particle GameObjects for the cloth
        public void CreateClothParticles()
        {
            int xPosCounter = 0;
            int yPosCounter = 4;

            // Particle position is set based on counters then are added to the list, The counter then changes
            for (int n = 0; n < 16; n++)
            {
                p.position = new Vector3(xPosCounter * 10, yPosCounter * 10, 0);    // Set Position for each particle
                _particleList.Add(p);   // Add Particle to the list
                xPosCounter++; // x position for the next particle
                
                if (xPosCounter >= 4) // Change x and y position for the next particle
                {
                    yPosCounter--;
                    xPosCounter = 0;
                }

                Debug.Log("Particle Position Placement Check: " + _particleList[n].position.ToString());    // To help confirm that the Particle GameObjects are in the same position as the Particle Objects
            }

        }
    }
}