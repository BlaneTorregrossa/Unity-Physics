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

        public List<Blane.Particle> altPerticleList = new List<Blane.Particle>();

        public Blane.Particle p0, p1, p2, p3, p4,
                            p5, p6, p7, p8, p9,
                            p10, p11, p12, p13, p14,
                            p15, p16, p17, p18, p19,
                            p20, p21, p22, p23, p24;

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
                    Debug.Log("1st Particle Position Check: " + particleList[j].position.ToString());     // To keep track of set positions of particles
                }
                else
                {
                    particleList[j].position.y = particleList[j].position.y + 5;
                    prevPosition = particleList[j].position;
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

            altPerticleList.Add(p0); altPerticleList.Add(p1); altPerticleList.Add(p2); altPerticleList.Add(p3); altPerticleList.Add(p4);
            altPerticleList.Add(p5); altPerticleList.Add(p6); altPerticleList.Add(p7); altPerticleList.Add(p8); altPerticleList.Add(p9);
            altPerticleList.Add(p10); altPerticleList.Add(p11); altPerticleList.Add(p12); altPerticleList.Add(p13); altPerticleList.Add(p14);
            altPerticleList.Add(p15); altPerticleList.Add(p16); altPerticleList.Add(p17); altPerticleList.Add(p18); altPerticleList.Add(p19);
            altPerticleList.Add(p20); altPerticleList.Add(p21); altPerticleList.Add(p22); altPerticleList.Add(p23); altPerticleList.Add(p24);
            #endregion

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