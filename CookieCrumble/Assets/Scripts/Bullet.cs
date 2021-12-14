using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * speed;
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
