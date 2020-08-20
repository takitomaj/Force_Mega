
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;


public class Personaje : MonoBehaviour
{
	

	public float maxSpeed = 3f;
	public float speed = 75f;
	

	
	

	private Rigidbody2D rb2d;
	
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	
	}
	
	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//disparp
			//CmdDisparo();
		}

	}
	//192.168.1.5
	void FixedUpdate()
	{
		float h = 0f;


		if (Input.GetAxis("Horizontal") != 0)
		{
			h = Input.GetAxis("Horizontal");
		}

		


		rb2d.AddForce(Vector2.right * speed * h);


		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f)
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (h < -0.1f)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

	}
	

}
