using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behav : MonoBehaviour
{
    private Color cubeColor;
    private int d;
    private float velocity_x;
    private float velocity_y;
    private float velocity_z;
    private Color randomColor;
    private int Speed = 10;
    public Rigidbody rb; //for each object created by pressing space



    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.FindWithTag("SC"); // load the Screen Cube to cube

        cubeColor.r = Random.value;
        cubeColor.g = Random.value;
        cubeColor.b = Random.value;
        cubeColor.a = 0.4f;

        var cubeRenderer = cube.GetComponent<Renderer>(); //load the cube's renderer

        cubeRenderer.material.SetColor("_Color", cubeColor); //set the cube's random color

    }


    // Update is called once per frame
    void Update()
    {
        int random_shape = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            //Compute the random shape number 0 for cube, 1 for sphere and 2 for cylinder
            random_shape = Random.Range(0, 3);

            d = Random.Range(1, 11); // for the random scale of each shape

            //Compute the velocity of each shape randomly ranging from 0.1 to 0.9
            velocity_x = Random.value;
            velocity_y = Random.value;
            velocity_z = Random.value;

            //Compute the color values randomly
            randomColor.r = Random.value;
            randomColor.g = Random.value;
            randomColor.b = Random.value;
            randomColor.a = 1.0f; //we don't want full transparency

            System.Threading.Thread.Sleep(800); // So it won't load more object at once 
            if (random_shape == 0)
            {
                CreateCube();
            }
            else if (random_shape == 1)
            {
                CreateSphere();
            }
            else
            {
                CreateCylinder();
            }
        }
    }

    private void CreateCube()
    {
        GameObject smallCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        smallCube.transform.position = new Vector3(0, 0, 0);
        smallCube.transform.localScale = new Vector3(d, d, d);

        var smallCubeRenderer = smallCube.GetComponent<Renderer>();

        smallCubeRenderer.material.SetColor("_Color", randomColor);

        smallCube.AddComponent<Rigidbody>();

        var rb = smallCube.GetComponent<Rigidbody>();

        // we don't want gravity and we want the object to move
        rb.useGravity = false;
        rb.isKinematic = false;

        // the randomly generated velocity of the object 
        rb.velocity = new Vector3(velocity_x, velocity_y, velocity_z) * Speed;
    }

    private void CreateSphere()
    {
        GameObject smallSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        smallSphere.transform.position = new Vector3(0, 0, 0);
        smallSphere.transform.localScale = new Vector3(d, d, d);

        var smallSphereRenderer = smallSphere.GetComponent<Renderer>();

        smallSphereRenderer.material.SetColor("_Color", randomColor);

        smallSphere.AddComponent<Rigidbody>();

        var rb = smallSphere.GetComponent<Rigidbody>();

        // we don't want gravity and we want the object to move
        rb.useGravity = false;
        rb.isKinematic = false;
        rb.freezeRotation = true; // we don't want any rotation on cylinders

        // the randomly generated velocity of the object 
        rb.velocity = new Vector3(velocity_x, velocity_y, velocity_z) * Speed;

    }
    private void CreateCylinder()
    {
        GameObject smallCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        smallCylinder.transform.position = new Vector3(0, 0, 0);
        smallCylinder.transform.localScale = new Vector3(d, d, d);

        var smallCylinderRenderer = smallCylinder.GetComponent<Renderer>();

        smallCylinderRenderer.material.SetColor("_Color", randomColor);

        smallCylinder.AddComponent<Rigidbody>();

        var rb = smallCylinder.GetComponent<Rigidbody>();

        // we don't want gravity and we want the object to move
        rb.useGravity = false;
        rb.isKinematic = false;
        
        // the randomly generated velocity of the object 
        rb.velocity = new Vector3(velocity_x, velocity_y, velocity_z) * Speed;
    }
}
