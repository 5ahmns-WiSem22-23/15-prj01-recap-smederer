using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public bool hasCoin = false;
    public GameObject coin;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            hasCoin = true;
            coin.SetActive(false); 
        }

    }


}
