using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public Vector2[] posiListe = 
    {
        new Vector2(1, -6),
        new Vector2(6, -5),
        new Vector2(7, -2)
    };
    public Collect checkCoin;
  



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (checkCoin.hasCoin == true)  
            {
                int index = Random.Range(0, posiListe.Length);
                Debug.Log(index);
                checkCoin.coin.transform.position = posiListe[index];
                checkCoin.coin.SetActive(true);
            }
        }

    }
}
