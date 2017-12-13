using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blane
{
    // Not placing the objects
    public class CreateCloth
    {
        public Blane.Particle _particle;
        public Blane.Particle _anchor;
        public Blane.SpringDamper _springDamper;

        public List<Blane.Particle> particleList = new List<Blane.Particle>();
        public List<Blane.Particle> anchorList = new List<Blane.Particle>();

        void Start()
        {
            _particle.Initilize();
            _anchor.Initilize();
            _springDamper.Initialize(1, 10, 1, _particle, _anchor);

            for (int i = 0; i < 25; i++)
            {
                particleList.Add(_particle);
                anchorList.Add(particleList[i + 1]);
            }

            for (int j = 0; j < 25; j++)
            {
                particleList[j].position = particleList[j - 1].position + new Vector3(0, 3, 0);
                if (particleList[j].position == new Vector3(particleList[j].position.x, 21, particleList[j].position.z))
                {
                    particleList[j].position = new Vector3(particleList[j].position.x + 3, 0, particleList[j].position.z);
                }
            }


        }

        void Update()
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