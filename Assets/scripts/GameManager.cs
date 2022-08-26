using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOver;
    void Awake()
    {
        _gameOver.SetActive(false);
    }

    public void onGameOver()
    {
        _gameOver.SetActive(true);
        Time.timeScale = 1;
    }
    
    private void Updade()
    {
       if (Input.GetKeyDown(KeyCode.R))
       {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }


    }

}
