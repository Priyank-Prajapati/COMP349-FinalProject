using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{

    public int colorNumber;
    public bool firstPlatorms;
    float time;
    public float timeDelay;
    bool c;
   public Sprite  [] allSprites;
    GameObject  []child;
    string color;
    // Start is called before the first frame update
    void Start()
    {
        child = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            child[i] = this.transform.GetChild(i).gameObject;
            child[i].GetComponent<SpriteRenderer>().sprite = allSprites[0];
        }
        //this.GetComponent<Collider2D>().isTrigger = true;
        //    if (colorNumber==1)
        //        this.GetComponent<Renderer>().material.color = Color.blue;
        //    else if(colorNumber==0)
        //        this.GetComponent<Renderer>().material.color = Color.red;
        //else if (colorNumber == 3)
        //    this.GetComponent<Renderer>().material.color = Color.green;
        //time = 0f;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        time = time + 0.5f * Time.deltaTime;
        if (time >= timeDelay)
        {
            time = 0f;
            if (firstPlatorms)
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    if (child[i].GetComponent<SpriteRenderer>().sprite == allSprites[0])
                    {
                        child[i].GetComponent<SpriteRenderer>().sprite = allSprites[1];
                        color = "Vanilla";
                    }
                    else if (child[i].GetComponent<SpriteRenderer>().sprite == allSprites[1])
                    {
                        child[i].GetComponent<SpriteRenderer>().sprite = allSprites[2];
                        color = "Brown";
                    }
                    else if (child[i].GetComponent<SpriteRenderer>().sprite == allSprites[2])
                    {
                        child[i].GetComponent<SpriteRenderer>().sprite = allSprites[0];
                        color = "Pink";
                    }
                }
            }
            //else
            //{
            //    if (this.GetComponent<Renderer>().material.color == Color.red)
            //        this.GetComponent<Renderer>().material.color = Color.blue;
            //    else if (this.GetComponent<Renderer>().material.color == Color.blue)
            //        this.GetComponent<Renderer>().material.color = Color.green;
            //    else if (this.GetComponent<Renderer>().material.color == Color.green)
            //        this.GetComponent<Renderer>().material.color = Color.red;
            //}

            if (c)
            {
                this.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
          
            if (PlayerController.color == color)
            {
                this.GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }
}
