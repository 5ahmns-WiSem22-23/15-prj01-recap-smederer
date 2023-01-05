
using UnityEngine;


public class Collect : MonoBehaviour
{
    public bool hasCoin = false;
    public GameObject coin;
    public GameObject coinSanta;

    private void Start()
    {
        coinSanta.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            hasCoin = true;
            coin.SetActive(false);
            coinSanta.SetActive(true);
        }

    }


}
