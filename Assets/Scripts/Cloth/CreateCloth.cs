using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blane
{
    public class CreateCloth
    {
        public Blane.Particle _particle;
        public Blane.Particle _particleAlt;
        public Blane.SpringDamper _springDamper;

        private List<Blane.Particle> particleList = new List<Blane.Particle>();
        private List<Blane.Particle> anchorList = new List<Blane.Particle>();

        void Start()
        {
            _particle.Initilize();
            _particleAlt.Initilize();
            _springDamper.Initialize(1, 10, 1, _particle, _particleAlt);

            for (int i = 0; i < 36; i++)
            {
                particleList.Add(_particle);
                anchorList.Add(particleList[i + 1]);
            }

            anchorList[35] = particleList[0];

            for (int j = 0; j < 36; j++)
            {
                particleList[j].position = particleList[j - 1].position + new Vector3(0, 3, 0);
                if (particleList[j].position == new Vector3(particleList[j].position.x, 18, particleList[j].position.z))
                {
                    particleList[j].position = new Vector3(particleList[j].position.x + 3, 0, particleList[j].position.z);
                }
                particleList[j].startingPosition = particleList[j].position;
            }

        }

        void Update()
        {
            for (int u = 0; u < 26; u++)
            {
                particleList[u].Update(Time.deltaTime);
                anchorList[u].Update(Time.deltaTime);
                _springDamper.CalculateForce();
            }
        }
    }
}