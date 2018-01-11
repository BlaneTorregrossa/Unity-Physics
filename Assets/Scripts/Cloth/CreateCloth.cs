using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blane
{

    //  NO LONGER USED, BETTER TO CREATE CLOTH IN THE MONOBEHAVIOUR CLASS
    public class CreateCloth
    {
        public SpringDamper _springDamper = new SpringDamper();

        public List<Particle> particleList = new List<Particle>();
        public List<Particle> anchorList = new List<Particle>();

        public void Initialize()
        {
            for (int t = 0; t < 16; t++)
            {
                particleList.Add(new Particle());

                //if (t >= 1)
                anchorList.Add(particleList[t/* - 1*/]);
                DamperCall(particleList[t], anchorList[t]);
            }

        }

        // Sets Starting Positions of each particle
        public void SetParticlePosition()
        {
            int counter = 0;
            Vector3 SetPosition = new Vector3(0, 0, 0);
            for (int j = 0; j < 16; j++)
            {
                if (counter == 4)
                {
                    SetPosition = new Vector3(0, SetPosition.y, 0); //  x = 0, z = 0
                    SetPosition += new Vector3(0, 10, 0);    //  +10 y
                    particleList[j].Initilize(SetPosition);
                    anchorList[j].Initilize(SetPosition);
                    counter = 0;
                }

                if (counter != 4)
                {
                    particleList[j].Initilize(SetPosition);
                    anchorList[j].Initilize(SetPosition);
                    SetPosition += new Vector3(10, 0, 0);    // +10 x
                    counter += 1;
                }
            }
        }

        public void DamperCall(Particle _particle, Particle _anchor)
        {
            _springDamper.Initialize(1, 10, 1, _particle, _anchor);
        }

    }
}