using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public GameObject canvas;
    private GameObject player;
    public Text textScore;

    public float gameTime;

    public Text textBox;

    public static int score = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
        score = 0;
        Debug.Log(Spawner.spawnDelay);
        gameTime = SliderController.gameSessionTime;
        textBox.text = gameTime.ToString();
        textScore = canvas.GetComponentInChildren<Text>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        gameTime -= Time.deltaTime;
        textBox.text = Mathf.Round(gameTime).ToString();

        if (gameTime <= 0)
        {
            player.GetComponent<PlayerController>().CallEndMenu();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}