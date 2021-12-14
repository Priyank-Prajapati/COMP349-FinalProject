using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour
{
   public void PlayGame()
    {
        ScoreCounter.scoreValue = 0;
        SceneManager.LoadScene(3);
    }


    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void LOAD_SCENE(string SceneName)
    {
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName);
    }

    public void AudioMute()
    {
        AudioListener.volume = 0f;
    }

    public void AudioUnmute()
    {
        AudioListener.volume = 1f;
    }


}
