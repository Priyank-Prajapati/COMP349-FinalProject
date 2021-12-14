using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
   public void PlayGame()
    {
        ScoreCounter.scoreValue = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


}
