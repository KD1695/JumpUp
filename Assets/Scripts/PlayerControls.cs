using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            body.AddForce(new Vector3(30, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(new Vector3(-30, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, 2500, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            GameState.Instance.ModifyPlayerHealth(-400);
        }
        else if(other.tag == "Health")
        {
            GameState.Instance.ModifyPlayerHealth(15);
            other.gameObject.SetActive(false);
        }
        else
        {
            GameState.Instance.ModifyPlayerHealth(-10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameState.Instance.ModifyPlayerHealth(-10);
    }
}