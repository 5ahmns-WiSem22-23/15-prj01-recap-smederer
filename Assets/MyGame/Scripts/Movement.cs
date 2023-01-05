
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool facingRight = true;

    [SerializeField]
    private float boostMultiplier = 2.0f;
    [SerializeField]
    private float moveSpeed = 4.0f;
    private float boostTimer = 0.0f;
    private float boostDuration = 0.7f;
    private bool dividieren = false;
    private bool boostIsAktive = false;
    
    
    Vector2 movement;



    void Update()
    {
        //1 movement part, in "fixedupdate weitergeführt"
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //2 rotation part - richtung auslesen ----> wenn man "roation" nur über pfeiltasten will, einfach "Input.GetKeyDown(KeyCode.Left/RightArrow)", verwenden.
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            facingRight = true;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            facingRight = false;
        }
        //2 rotation part - scale *-1
        if (facingRight)
        {
            rb.transform.localScale = new Vector2(-1, 1);
        }
        else if (!facingRight)
        {
            rb.transform.localScale = new Vector2(1, 1);
        }

        //3 boost part, in "OnTriggerEnter2D" weitergeführt
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

    //1 movement part
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //3 boost part
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


}
