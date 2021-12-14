using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformController : MonoBehaviour
{
    string color;
    bool c;
    public bool pink, brown, vanilla;
    GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        if (pink)
            color = "Pink";
        if (brown)
            color = "Brown";
        if (vanilla)
            color = "Vanilla";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.color == color)
        {
            blocks = GameObject.FindGameObjectsWithTag("jumpBlocks");
            foreach (GameObject block in blocks)
            {
                block.GetComponent<Collider2D>().isTrigger = false;
            }
        }
        else
        {
            blocks = GameObject.FindGameObjectsWithTag("jumpBlocks");
            foreach (GameObject block in blocks)
            {
                block.GetComponent<Collider2D>().isTrigger = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(PlayerController.color + " " + color);
            if (PlayerController.color == color)
            {
                blocks = GameObject.FindGameObjectsWithTag("jumpBlocks");
                foreach (GameObject block in blocks)
                {
                    block.GetComponent<Collider2D>().isTrigger = false;
                }
            } else
            {
                blocks = GameObject.FindGameObjectsWithTag("jumpBlocks");
                foreach(GameObject block in blocks)
                {
                    block.GetComponent<Collider2D>().isTrigger = true;
                }
               
            }
        }
    }
}
