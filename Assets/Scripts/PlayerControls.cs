using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] GameState gameState;
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
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(new Vector3(0, -10, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, 2500 * gameState.JumpForceMultiplier(), 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            gameState.ModifyPlayerHealth(-400);
        }
        else if(other.gameObject.GetComponent<PowerUp>() != null)
        {
            other.gameObject.GetComponent<PowerUp>().Activate();
            other.gameObject.SetActive(false);
        }
        else if(!gameState.IsPlayerInvincible())
        {
            gameState.ModifyPlayerHealth(-10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameState.IsPlayerInvincible())
            gameState.ModifyPlayerHealth(-10);
    }
}