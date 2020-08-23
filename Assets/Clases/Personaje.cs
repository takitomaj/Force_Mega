
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
//using UnityEngine.Networking;


public class Personaje : MonoBehaviour
{
	//activar alpha =255
	private const int _ActivarAlpha= 255;
	//variablesde prueba
	int pos = 1;
	int countTest = 0;
	//variables de equipo
	public UnityEngine.UI.Image casco;
	public UnityEngine.UI.Image peto;
	public UnityEngine.UI.Image Botas;

	public Data_Personaje stats;

	public float maxSpeed = 3f;
	public float speed = 75f;
	public HeltBar Barra_vida;

	
	

	private Rigidbody2D rb2d;
	
	void Start()
	{
		stats =new Data_Personaje(true);
		rb2d = GetComponent<Rigidbody2D>();
		Barra_vida.SetMax_helth(stats.vida_maxima);
		Barra_vida.SetHelt(stats.Vida);
		casco.color = new Color(255, 255, 255, 0);
		peto.color = new Color(255, 255, 255, 0);

		maxSpeed = 3.0f+stats.Movimiento1;

	}
	
	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//disparp
			//CmdDisparo();
			Recibir_Dano(10);
			if (pos == 1)
			{
				casco.color = new Color(stats.colores[countTest, 0],//Rojo  R
									    stats.colores[countTest, 1],//Verde G
										stats.colores[countTest, 2],//Azul  B
										1);                         //Alpha AGGGGGGGGGG
				peto.color = new Color(stats.colores[countTest, 0],//Rojo  R
										stats.colores[countTest, 1],//Verde G
										stats.colores[countTest, 2],//Azul  B
										1);                         //Alpha AGGGGGGGGGG



				if (countTest == 2){countTest = 0;}
				else{countTest++;}
				
				pos = 0;
			}
			else
			{
				
				//quitar
				casco.color = new Color(255, 255, 255, 0);
				pos = 1;
				
			}
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
	public void Recibir_Dano(int dano)
	{
		stats.Vida = stats.Vida - dano;
		Barra_vida.SetHelt(stats.Vida);
	}


}
