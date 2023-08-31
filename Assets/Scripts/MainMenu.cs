using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip startClip;
    public void PlayerVsPlayer()
    {
        AudioManager.Instance.PlaySound(startClip);
        SceneManager.LoadScene(1);
    }

    public void PlayerVsAI()
    {
        AudioManager.Instance.PlaySound(startClip);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
