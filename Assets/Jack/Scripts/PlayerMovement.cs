// =========================================================
// Title: 
// Author(s): 
// Date: 
// Details: 
// =========================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float inputH  = Input.GetAxisRaw("Horizontal");
        float inputV  = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(inputH, inputV);
        moveVelocity = moveInput.normalized * speed;
       
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }
}
