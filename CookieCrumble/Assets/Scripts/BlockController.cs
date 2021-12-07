using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool pink, brown, vanilla;
    public AudioClip respawnSound;
    public AudioSource audio;
    public Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= -15)
        {
            this.transform.position = initialPos;
            audio.PlayOneShot(respawnSound);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if ((PlayerController.color != "Vanilla" && vanilla) || (PlayerController.color != "Pink" && pink) || (PlayerController.color != "Brown" && brown))
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            else 
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            

          

        }


        if (collision.gameObject.CompareTag("vanillaBlock"))
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
