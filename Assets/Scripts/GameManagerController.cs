using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public GameObject canvas;
    private GameObject player;
    public Text textScore;


    public static int score = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
        score = 0;
        Debug.Log(Spawner.spawnDelay);

        textScore = canvas.GetComponentInChildren<Text>();
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
