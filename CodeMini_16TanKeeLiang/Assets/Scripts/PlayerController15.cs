using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController15 : MonoBehaviour
{
    float speed = 10.0f;
    float zAxis = 10.0f;
    int planeIndicator = 0;
    float xAxis = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Inputvertical = Input.GetAxis("Vertical");
        float Inputhorizontal = Input.GetAxis("Horizontal");

       
        if(planeIndicator == 0)
        {

            if (transform.position.z < -zAxis)
            {
                if (transform.position.x > xAxis / 2 && transform.position.x < xAxis)
                {
                    transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);
                }
            }
            else if (transform.position.z > zAxis)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);
            }
        }
        if (transform.position.x < -xAxis)
        {
            transform.position = new Vector3(-xAxis, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xAxis)
        {
            transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            
        }
    }
    */
}
