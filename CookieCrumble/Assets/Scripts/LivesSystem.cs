using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesSystem : MonoBehaviour
{
    public GameObject []lives;
    public static int life=3;

    // Start is called before the first frame upda
    // Update is called once per frame
    void Update()
    {
        if(life<1)
        {
            Destroy(lives[0].gameObject);
        }
       else if (life < 2)
        {
            Destroy(lives[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(lives[2].gameObject);
        }
        if(life==0)
        {
            Debug.Log(life);
            SceneManager.LoadScene(6);
            life = 3;
            ScoreCounter.scoreValue = 0;
        }
    }
}
