using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public Collect checkCoin;
    [SerializeField]
    private Vector2 newPos1;
    [SerializeField]
    private Vector2 newPos2;
    [SerializeField]
    private Vector2 newPos3;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (checkCoin.hasCoin == true)
            {
                checkCoin.coin.transform.position = newPos1;
                checkCoin.coin.SetActive(true);
            }
        }

    }
}
