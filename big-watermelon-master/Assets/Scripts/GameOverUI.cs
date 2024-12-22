using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI BestScore;
    // Start is called before the first frame update
    public void OnEnable()
    {
        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void Reload()
    {
        PlayerManager.Instance.isGameOver = false;
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        PlayerManager.Instance.isGameOver = false;
        PlayerManager.Instance.time = PlayerManager.Instance.PlayTimeTotal;
        gameObject.SetActive(false);
    }
}
