using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float boostMultiplier = 2.0f;
    public float moveSpeed = 4.0f;
    public Rigidbody2D rb;

    private float boostTimer = 0.0f;
    private float boostDuration = 0.7f;
    private bool dividieren = false;
    private bool boostIsAktive = false;
    
    

    Vector2 movement;



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Rotation();

        if (boostTimer <= 0)
        {
            boostIsAktive = false;

            if (dividieren == true)
            {
                moveSpeed /= boostMultiplier;
                dividieren = false;
            }
            
        }
        else
        {
            boostTimer -= Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boost" && boostIsAktive == false)
        {
            moveSpeed *= boostMultiplier;
            boostTimer = boostDuration;
            dividieren = true;
            boostIsAktive = true;
        }
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            rb.transform.localScale = new Vector3(0.6875f, 1.551187f, 1f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            rb.transform.localScale = new Vector3(1.551187f, 0.6875f, 1f);
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Boost")
    //    {
    //        moveSpeed /= boostMultiplier;
    //    }
    //}

}
