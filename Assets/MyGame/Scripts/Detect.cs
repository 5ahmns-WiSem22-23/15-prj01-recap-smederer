
using UnityEngine;
using TMPro;

public class Detect : MonoBehaviour
{
   
    public Collect checkCoin;
    public TextMeshProUGUI score;

    [SerializeField]
    private Vector2[] posiListe =
    {
        new Vector2(1, -6),
        new Vector2(6, -5),
        new Vector2(7, -2)
    };
    [SerializeField]
    private GameObject[] coinsCollected;
     
    private int scroeInt;


    private void Start()
    {
        for (int i = 0; i < coinsCollected.Length; i++)
        {
            coinsCollected[i].SetActive(false);
        }
    }


    private void Update()
    {
        score.text = scroeInt.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && checkCoin.hasCoin == true)
        {
            
            int index = Random.Range(0, posiListe.Length);
            checkCoin.coin.transform.position = posiListe[index];
            checkCoin.coin.SetActive(true);
            checkCoin.coinSanta.SetActive(false);
            checkCoin.hasCoin = false;
            scroeInt++;
        }
        for (int i = 0; i < coinsCollected.Length; i++)
        {
            coinsCollected[scroeInt-1].SetActive(true);
        }
    }
  
}
