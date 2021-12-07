using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool pink, brown, vanilla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if ((PlayerController.color == "Vanilla" && vanilla) || (PlayerController.color == "Pink" && pink) || (PlayerController.color == "Brown" && brown) )
                this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
