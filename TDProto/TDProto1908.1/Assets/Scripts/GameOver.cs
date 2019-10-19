using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Text wavesText;

    // like Start() but called everytime a game object gets enabled

    private void OnEnable()
    {
        wavesText.text = PlayerStats.Waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Menu ()
    {
        Debug.Log("Go to menu");
    }
}
