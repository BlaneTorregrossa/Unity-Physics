using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// REWORK NEEDED
public class ClothBehavior : MonoBehaviour
{

    public Vector3 particlePosition;

    //public List<Blane.Particle> ParticleList = new List<Blane.Particle>();

    public Blane.SpringDamper _springDamper = new Blane.SpringDamper();

    public List<ParticleUpdate> particleList = new List<ParticleUpdate>();

    public GameObject particleObject;
    public GameObject anchorObject;

    public List<GameObject> particleObjectList = new List<GameObject>();
    public List<GameObject> anchorObjectList = new List<GameObject>();

    void Start()
    {
        CreateClothParticles();
        #region Getting Cloth POS from another class and setting that to gameobject
        //_cloth.Initialize();
        //_cloth.SetParticlePosition();

        ////  ***
        ////  Loop sets up particle objects to equal the position of the given particle
        //for (int m = 0; m < 16; m++)
        //{
        //    particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //    particleObjectList.Add(particleObject);
        //    particleObjectList[m].transform.position = _cloth.particleList[m].position;
        //    //Debug.Log("2nd Particle Position Check: " + particleObjectList[m].transform.position.ToString());

        //    if (m >= 1)
        //    {
        //        anchorObject = particleObjectList[m - 1];
        //        anchorObjectList.Add(anchorObject);
        //        anchorObjectList[m - 1].transform.position = _cloth.anchorList[m - 1].position;
        //    }
        //}
        #endregion
        SetDampers();
    }


    void Update()
    {
        for (int u = 0; u < particleList.Count; u++)
        {

        }

        #region Not used
        //for (int u = 0; u < 16; u++)
        //{
        //    _cloth.particleList[u].Update(Time.deltaTime);
        //}
        #endregion
    }

    void CreateClothParticles()
    {
        int xPosCounter = 0;
        int yPosCounter = 4;

        for (int m = 0; m < 16; m++)
        {
            particleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            particleObject.transform.position = new Vector3(xPosCounter * 10, yPosCounter * 10, 0);
            var pu = particleObject.AddComponent<ParticleUpdate>();
            particleList.Add(pu);
            particleObjectList.Add(particleObject);
            //pu.currentParticle.Initilize(particleList[m].transform.position);
            Debug.Log("2nd Particle Position Check: " + particleObjectList[m].transform.position.ToString());

            xPosCounter++;

            if (xPosCounter >= 4)
            {
                yPosCounter++;
                xPosCounter = 0;
            }
        }
    }

    void SetDampers()
    {
        for (int i = 0; i < particleObjectList.Count; i++)
        {
            for (int j = 0; j < particleObjectList.Count; j++)
            {
                if (particleObjectList[i].transform.position.x == particleObjectList[j].transform.position.x ||
                    particleObjectList[i].transform.position.x - 10 == particleObjectList[j].transform.position.x ||
                    particleObjectList[i].transform.position.x + 10 == particleObjectList[j].transform.position.x)
                {
                    if (particleObjectList[i].transform.position.y - 10 == particleObjectList[j].transform.position.y)
                    {
                        _springDamper.Initialize(1, 10, 1, particleList[j].currentParticle, particleList[i].currentParticle);
                    }
                }
            }
        }
    }
}
