using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiScript : MonoBehaviour
{
    [SerializeField] Platform platform;
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject ending;
    [SerializeField] TMP_Text score;

    public void PlayButton()
    {
        platform.gameStarted = true;
        menuButtons.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("score", 0);
    }

    public void Ending()
    {
        ending.SetActive(true);
        score.text = "Score" + PlayerPrefs.GetInt("score");
        platform.gameStarted = false;
    }
}
