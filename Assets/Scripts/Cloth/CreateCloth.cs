using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blane
{
    public class CreateCloth
    {
        public Blane.Particle _particle = new Blane.Particle();
        public Blane.Particle _anchor = new Blane.Particle();
        public Blane.SpringDamper _springDamper = new Blane.SpringDamper();

        public List<Blane.Particle> particleList = new List<Blane.Particle>();
        public List<Blane.Particle> anchorList = new List<Blane.Particle>();

        private Vector3 prevPosition = new Vector3(0, 0, 0);

        public void Initialize()
        {
            _particle.Initilize();
            _anchor.Initilize();
            _springDamper.Initialize(1, 10, 1, _particle, _anchor);

            for (int i = 0; i < 25; i++)
            {
                particleList.Add(_springDamper.p1);
                anchorList.Add(_springDamper.p2);
            }
        }

        public void SetParticlePosition()
        {
            int counter = 0;
            for (int j = 0; j < 25; j++)
            {
                particleList[j].position.y += 3;
                prevPosition = particleList[j].position;
                if (counter == 5)
                {
                    particleList[j].position.y = 0;
                    particleList[j].position.x = particleList[j].position.x + 3;
                    counter = 0;
                }
                counter++;
                Debug.Log("1st Particle Position Check: " + particleList[j].position.ToString());     // To keep track of set positions of particles
            }
        }

        public void Update_Position()
        {
            for (int u = 0; u < 25; u++)
            {
                particleList[u].Update(Time.deltaTime);
                anchorList[u].Update(Time.deltaTime);

                _springDamper.CalculateForce();
            }
        }
    }
}