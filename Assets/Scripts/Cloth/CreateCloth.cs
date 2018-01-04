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

        #region Not Used
        public List<Blane.Particle> altParticleList = new List<Blane.Particle>();

        public Blane.Particle p0, p1, p2, p3, p4,
                            p5, p6, p7, p8, p9,
                            p10, p11, p12, p13, p14,
                            p15, p16, p17, p18, p19,
                            p20, p21, p22, p23, p24;
        #endregion

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
                if (j == 0)
                {
                    particleList[j].position.y = 0;
                    prevPosition = particleList[j].position;
                    counter++;
                    particleList[j].startingPos = prevPosition;
                    Debug.Log("1st Particle Position Check: " + particleList[j].position.ToString());     // To keep track of set positions of particles
                }
                else
                {
                    particleList[j].position.y = particleList[j].position.y + 5;
                    prevPosition = particleList[j].position;
                    particleList[j].startingPos = prevPosition;
                    if (counter == 5)
                    {
                        particleList[j].position.y = 0;
                        particleList[j].position.x = particleList[j].position.x + 5;
                        counter = 0;
                    }
                    counter++;
                    Debug.Log("1st Particle Position Check: " + particleList[j].position.ToString());     // To keep track of set positions of particles
                }
            }
            #region Not used
            p0 = particleList[0]; p1 = particleList[1]; p2 = particleList[2]; p3 = particleList[3]; p4 = particleList[4];
            p5 = particleList[5]; p6 = particleList[6]; p7 = particleList[7]; p8 = particleList[8]; p9 = particleList[9];
            p10 = particleList[10]; p11 = particleList[11]; p12 = particleList[12]; p13 = particleList[13]; p14 = particleList[14];
            p15 = particleList[15]; p16 = particleList[16]; p17 = particleList[17]; p18 = particleList[18]; p19 = particleList[19];
            p20 = particleList[20]; p21 = particleList[21]; p22 = particleList[22]; p23 = particleList[23]; p24 = particleList[24];

            altParticleList.Add(p0); altParticleList.Add(p1); altParticleList.Add(p2); altParticleList.Add(p3); altParticleList.Add(p4);
            altParticleList.Add(p5); altParticleList.Add(p6); altParticleList.Add(p7); altParticleList.Add(p8); altParticleList.Add(p9);
            altParticleList.Add(p10); altParticleList.Add(p11); altParticleList.Add(p12); altParticleList.Add(p13); altParticleList.Add(p14);
            altParticleList.Add(p15); altParticleList.Add(p16); altParticleList.Add(p17); altParticleList.Add(p18); altParticleList.Add(p19);
            altParticleList.Add(p20); altParticleList.Add(p21); altParticleList.Add(p22); altParticleList.Add(p23); altParticleList.Add(p24);
            #endregion

        }

        public Vector3 Update_Position(int index)
        {
            _springDamper.CalculateForce();

            Vector3 result = particleList[index].Update(Time.deltaTime);

            return result;

        }

        public Vector3 Update_Anchor_Position(int index)
        {
            _springDamper.CalculateForce();

            Vector3 result = anchorList[index].Update(Time.deltaTime);

            return result;

        }

    }
}