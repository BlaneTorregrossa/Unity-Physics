using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Bad name
public class MakeCloth : MonoBehaviour
{
    [SerializeField] public List<Blane.Triangle> _triangleList = new List<Blane.Triangle>();
    [SerializeField] public List<Blane.SpringDamper> _damperList = new List<Blane.SpringDamper>();
    [SerializeField] public List<Blane.ClothParticle> _particleList = new List<Blane.ClothParticle>();
    [SerializeField] public List<ClothParticleBehavior> _particleBehaviourList = new List<ClothParticleBehavior>();
    [SerializeField] public List<GameObject> _particleObjectList = new List<GameObject>();
    [SerializeField] public float springConstant, restLength, dampingFactor;

    private int maxWidth = 5;
    private int maxHeight = 5;

    private int currentWidth = 0;
    private int currentHeight = 0;

    void Start()
    {

        springConstant = 1;
        restLength = 15;
        dampingFactor = 1;

        CreateClothParticles();
        CreateParticleDampers();
        CreateTriangles();
    }

    void Update()
    {
        // Defaul gravity for particles
        for (int i = 0; i < _particleList.Count; i++)
        {
            _particleList[i].AddForce(new Vector3(0, -9.81f, 0));
        }

        // Damper calculations caled on update
        for (int j = 0; j < _damperList.Count; j++)
        {
            _damperList[j].CalculateForce();
        }

        for(int w = 0; w < _triangleList.Count; w++)
        {
            Blane.AerodynamicForce.Wind(_triangleList[w]);
        }
    }

    // Sets up particles for particle GameObjects for the cloth
    public void CreateClothParticles()
    {

        // Particle position is set based on counters then are added to the list, The counter then changes
        for (int n = 0; n < maxWidth * maxHeight; n++)
        {
            if (currentWidth >= maxWidth)
            {
                currentWidth = 0;
            }

            var p = new Blane.ClothParticle();
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            p.position = new Vector3(currentWidth * 10, currentHeight * 10, 0);    // Set Position for each particle
            _particleList.Add(p);   // Add Particle to the list

            particle.gameObject.transform.position = p.position;
            particle.AddComponent<ClothParticleBehavior>();
            _particleObjectList.Add(particle);

            currentWidth++; // x position for the next particle

            if (currentWidth >= maxWidth) // Change x and y position for the next particle
            {
                currentHeight++;
            }

            Debug.Log("Particle Position Placement Check: " + _particleList[n].position.ToString());    // To help confirm that the Particle GameObjects are in the same position as the Particle Objects
        }

    }

    public void CreateParticleDampers()
    {
        Blane.SpringDamper CurrentDamper;


        for (int i = 0; i < maxHeight * maxWidth; i++)
        {
            if (currentWidth == 0)
            {
                //
            }

            else if (i % currentWidth < currentWidth + 1)
            {
                CurrentDamper = new Blane.SpringDamper(springConstant, restLength, dampingFactor, _particleList[i], _particleList[i + 1]);
                _damperList.Add(CurrentDamper);
            }

            if (i < _particleList.Count + currentHeight)
            {
                CurrentDamper = new Blane.SpringDamper(springConstant, restLength, dampingFactor, _particleList[i], _particleList[i + currentHeight]);
                _damperList.Add(CurrentDamper);
            }
        }
    }

    public void CreateTriangles()
    {
        for (int j = 0; j < maxWidth * maxHeight + 1; j++)
        {
            if (j % currentWidth != currentWidth + 1)
            {
                int cornerParticle = j;
                int cornerHeightParticle = j + 1;
                int cornerWidthParticle = j + currentWidth;

                Blane.Triangle newTriangle = new Blane.Triangle(_particleList[cornerParticle], _particleList[cornerWidthParticle], _particleList[cornerHeightParticle]);
                _triangleList.Add(newTriangle);
            }
        }
    }

   
}

