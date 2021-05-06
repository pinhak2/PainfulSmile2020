using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public GameObject canvas;
    private GameObject player;
    public Text textScore;


    public int score = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
        score = 0;

        textScore = canvas.GetComponentInChildren<Text>();
    }



}
