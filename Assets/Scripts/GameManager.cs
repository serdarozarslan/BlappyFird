using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject DeathScreen;

    public GameObject StartScreen;

    public static GameManager Instance => _instance ??= FindObjectOfType<GameManager>();

    public Birdie birdie;

    public bool isGameStarted;

    public bool isGameEnded;

    public int score;

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI BestScore;

    public Animator platformAnimator;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
        ScoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StopPlatform();
        BestScoreText();
    }

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        isGameStarted = true;
        birdie.rb2D.isKinematic = false;
        StartScreen.SetActive(false);
        ScoreText.gameObject.SetActive(true);
    }

    public void StopPlatform()
    {
        if (isGameEnded)
        {
            platformAnimator.enabled = false;
        }
    }

    public void BestScoreText()
    {
        if (score > PlayerPrefs.GetInt("BestScore",0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}