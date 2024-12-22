using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private Text scoreText;
    private int score;

    public int Score { get => score;
        set
        {
            score = value;
            UpdataScoreText(score);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        score = 0;
    }
    private void Update()
    {
        if(score>PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }
    void UpdataScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
