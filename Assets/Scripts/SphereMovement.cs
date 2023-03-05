using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public int Speed = 40; // for the sphere's movement
    public int textTimes = 0; // a flag for the system to know the state of the texture loaded
    public Material newMat;
    public Material mat;

    void Start()
    {
        mat = Resources.Load("SphereColor", typeof(Material)) as Material;       //this is used to keep the original material of the sphere
        newMat = Resources.Load("Sphere_texture", typeof(Material)) as Material; //this is used for loading the texture by pressing T

    }

    void Update()
    {
        float xValue = 0.0f;
        float zValue = 0.0f;
        float yValue = 0.0f;

        GameObject sphere = GameObject.FindWithTag("SPH"); //find the red sphere inside the cube and load it to "sphere"

        var sphereRenderer = sphere.GetComponent<Renderer>(); 
        
      
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -100)
            {
                xValue = -Speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xValue = Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            yValue = -Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yValue = Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            zValue = -Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            zValue = Speed * Time.deltaTime;
        }

        //Change the position of the keys by pressing the arrow keys and the "-","+" of the num keypad
        transform.position = new Vector3(transform.position.x + xValue, transform.position.y + yValue, transform.position.z + zValue);

        if (Input.GetKey(KeyCode.T) && textTimes==0) // if the texture is not loaded
        {
            sphereRenderer.material = newMat;       // load the texture
            textTimes = 1; 
            System.Threading.Thread.Sleep(800);

        }else if (Input.GetKey(KeyCode.T) && textTimes == 1) // if the texture is loaded 
        {
            sphereRenderer.material = mat;          // return to the original 
            textTimes = 0;                          
            System.Threading.Thread.Sleep(800);

        }
    }
}
