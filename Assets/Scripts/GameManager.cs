using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text paddle1ScoreText;
    [SerializeField] private TMP_Text paddle2ScoreText;

    [SerializeField] private Transform paddle1Tranform;
    [SerializeField] private GameObject paddle2Go;
    [SerializeField] private Transform ballTranform;
    [SerializeField] private CanvasGroup victoryCanvas;
    [SerializeField] private TMP_Text victoryText;
    [SerializeField] private AudioClip winSFX;

    private int paddle1Score;
    private int paddle2Score;
    private int maxScore = 6;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();
    }

    public void Paddle2Scored()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
    }

    public void RestarGame()
    {
        paddle1Tranform.position = new Vector2(paddle1Tranform.position.x, 0);
        paddle2Go.transform.position = new Vector2(paddle2Go.transform.position.x, 0);
        ballTranform.position = new Vector2(0, 0);
    }

    public void VictoryCheck()
    {
        if (paddle1Score >= maxScore)
        {
            AudioManager.Instance.PlaySound(winSFX);
            StartCoroutine(GameStatus());
            victoryText.text = "Victory player 1";
        }
        else if (paddle2Score >= maxScore)
        {
            AudioManager.Instance.PlaySound(winSFX);
            StartCoroutine(GameStatus());
            if (paddle2Go.gameObject.CompareTag("Ai"))
            {
                victoryText.text = "Victory AI";
            }
            else
            {
                victoryText.text = "Victory player 2";
            }
        }
    }

    private void Pause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    IEnumerator GameStatus()
    {
        float delay = 4f;
        Pause();
        victoryCanvas.alpha = 1f;
        yield return new WaitForSecondsRealtime(delay);
        Pause();
        SceneManager.LoadScene(0);
    }
}
