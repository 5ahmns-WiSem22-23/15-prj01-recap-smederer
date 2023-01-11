using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;




public class GameManager : MonoBehaviour
{
    public GameObject button;
    public Rigidbody2D player;
    public Detect score;

    public TextMeshProUGUI timerText;
    private float timer;

    void Start()

    {
        timer = 130;
        button.SetActive(false);
    }

    void Update()
    {
        
        if (score.scroeInt == 24 || timer <= 0)
        {
            button.SetActive(true);
            player.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
        else
        {
            int zeit = (int)timer;
            timerText.text = zeit.ToString();
            timer -= Time.deltaTime;
        }
        Debug.Log(timer);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
