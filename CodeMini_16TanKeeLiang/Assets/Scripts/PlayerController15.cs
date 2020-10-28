using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController15 : MonoBehaviour
{
    float speed = 10.0f;
    float planeAabsLimits = 10.0f;
    float planeBabsLimits = 5.0f;

    float relzLimit;
    float relxLimit;

    int planeIndicator = 0;

    float gravityModifier = 2.0f;
    float jumpForce = 8.0f;
    int spaceTrack = 0;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float Inputvertical = Input.GetAxis("Vertical");
        float Inputhorizontal = Input.GetAxis("Horizontal");

       
        if(planeIndicator == 0)
        {
            relzLimit = planeAabsLimits;
            relxLimit = planeAabsLimits;

            if (transform.position.z > relzLimit)
            {
                if (transform.position.x > -relxLimit / 2 && transform.position.x < relxLimit / 2)
                {
                    transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
                }
            }
            else if (transform.position.z < -relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
            }

            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Inputhorizontal * speed * Time.deltaTime);
            }
        }
        else
        {
            relzLimit = planeAabsLimits + 2 * planeBabsLimits;
            relxLimit = planeBabsLimits;

            if(transform.position.z < planeAabsLimits)
            {
                if(transform.position.x > -planeAabsLimits / 2 && transform.position.x < planeAabsLimits / 2)
                {
                    transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, planeAabsLimits);
                }
            }
            else if (transform.position.z > relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
            }
            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Inputhorizontal * speed * Time.deltaTime);
            }
        }
        JumpPlayer();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Debug.Log("In Plane A");
            planeIndicator = 0;
            spaceTrack = 0;
        }
        if(collision.gameObject.CompareTag("PlaneB"))
        {
            Debug.Log("In Plane B");
            planeIndicator = 1;
            spaceTrack = 0;
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceTrack < 1)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            spaceTrack++;
        }
    }
}
