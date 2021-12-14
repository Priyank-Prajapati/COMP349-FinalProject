using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	PlayerController playerController;
	public GameObject player;


	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
		rb = this.GetComponent<Rigidbody2D>();
		if (playerController.isFacingRight)
        {
			rb.velocity = Vector3.right * speed;
        }
		if (!playerController.isFacingRight)
        {
			rb.velocity = Vector3.left * speed;
		}
		
	}
    void Update()
    {
		if (this.transform.position.x <= -30)
		{
			Destroy(this.gameObject);
		}

	}

    void OnTriggerEnter2D(Collider2D hitInfo)
	{
        var hit = hitInfo.gameObject;
        if (hit.tag == "enemy")
        {
			Destroy(hit);
        }
		if (hit.tag != "coin")
        {
			Destroy(this.gameObject);
        }
		
       
    }

}
