using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Vector2 playerDir = Vector2.zero;
    private Rigidbody2D playerRb = null;

    [SerializeField]
    private float playerSpeed = 100f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        GetPlayerInputs();
    }

    void GetPlayerInputs() 
    {
        playerDir.x = Input.GetAxis("Horizontal");
        playerDir.y = Input.GetAxis("Vertical");

        playerRb.velocity = playerDir * playerSpeed;
    }

}
