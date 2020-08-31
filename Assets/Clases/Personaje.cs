
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
//using NUnit.Framework.Internal;
//using UnityEngine.Networking;


public class Personaje : MonoBehaviour
{
	
	
	//variablesde prueba
	int pos = 1;
	int countTest = 0;
	public bool tirra = true;
	//variables de equipo
	public UnityEngine.UI.Image casco;
	public UnityEngine.UI.Image peto;
	public UnityEngine.UI.Image Botas;

	public Data_Personaje stats;
	public HeltBar Barra_vida;
	//movimiento
	public float maxSpeed = 3f;
	public float speed = 75f;
	public int JumpForce = 800;
	public Boolean salto = false;
	private Rigidbody2D rb2d;
	public Joystick joystickM;
	private Animator anim;
	//interaccion Touch
	public Camera cam;
	public Interacuar Focus;
	public Canvas Inventario_Equipo;


	public bool derecha = true;
	
	void Start()
	{
		Inventario_Equipo.enabled = false;
		cam = Camera.main;
		stats = new Data_Personaje(true);
		
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		SetVida();


		maxSpeed = 3.0f + stats.Movimiento;

	}
	public void Espadazo()
	{
		anim.SetTrigger("espadazo");
	}
	public void Shoot()
	{
		anim.SetTrigger("ataque");
	}
	public void unShoot()
	{
		anim.SetBool("disparando", false);
	}

	public void InventarioEquipo() 
	{
		if (Inventario_Equipo.isActiveAndEnabled) 
		{
			Inventario_Equipo.enabled = false;
			
		} else 
		{
			Inventario_Equipo.enabled = true;
			 
		}
	}
	public void melee_atack()
	{
		Espadazo();
	}
	


	void Update()
	{
		
		
		//seting de touch y mouse
		if (Input.GetMouseButtonDown(0))
		{

			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				
					QuitFocus();
				
			}
		}
		if (Input.GetMouseButtonDown(1))
		{

			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				Interacuar inter = hit.collider.GetComponent<Interacuar>();
				if (inter != null)
				{
					SetFocus(inter);
				}
			}
		}

		SetVida();
	}
	public void SetFocus(Interacuar newInter)
	{
		if (Focus != newInter) {
			if (Focus!=null) 
			{ 
				Focus = newInter;
				newInter.OnFocus(transform);
			} 
		}
	}
	public void QuitFocus()
	{
		if (Focus != null) 
		{
			Focus = null;
		}
	}
	

	//192.168.1.5
	void FixedUpdate()
	{
		float h = 0f;

		//movimiento horisontal
		if (Input.GetAxis("Horizontal") != 0)
		{
			h = Input.GetAxis("Horizontal");
		}
		else if (joystickM.Horizontal != 0)
		{
			h = joystickM.Horizontal;
		}
		//salto
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//disparp
			//CmdDisparo();
			salto = true;
		}
		
		if (joystickM.Vertical >= 0.5f)
		{
			//saltar
			salto = true;
		}
		float vel = Math.Abs(h);
		anim.SetFloat("velocidad",vel );
		anim.SetBool("suelo", tirra);

		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f)
		{

			if (!derecha) { 
			transform.Rotate(0f, 180f, 0f);
				derecha = true;
			}
			
			//transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (h < -0.1f)
		{
			if (derecha)
			{
				transform.Rotate(0f, 180f, 0f);
				derecha = false;
			}
			
			//transform.localScale = new Vector3(-1f, 1f, 1f);
		}

		if (salto && tirra)
		{
			rb2d.AddForce(Vector2.up * JumpForce );
			salto = false;
		}
	}
	public void OnCollisionStay2D(Collision2D collision)
	{
		//if (collision.gameObject.tag=="suelo") {
		tirra = true;
		//}
		if (collision.gameObject.tag == "Curacion +1")
		{
			stats.vida += 1;
		}
	}
	public void OnCollisionExit2D(Collision2D collision)
	{
		
		tirra = false;
	}

	public void Recibir_Dano(int dano)
	{
		stats.vida = stats.vida - dano;
		Barra_vida.SetHelt(stats.vida);
	}
	public void SetVida() 
	{
		Barra_vida.SetMax_helth(stats.vida_maxima);
		Barra_vida.SetHelt(stats.vida);
	}
	public void GanarEXP(int exp)
	{
		int expTotal = stats.Exp + exp;
		if (stats.Next_lvl> expTotal) 
		{
			stats.Exp = expTotal;
		}else if (stats.Next_lvl == expTotal) 
		{
			stats.Lvl_UP();
			stats.vida = stats.vida_maxima;
		}
		else if (stats.Next_lvl < expTotal)
		{
			int remanente = expTotal - stats.Next_lvl;
			stats.Lvl_UP();
			stats.vida = stats.vida_maxima;
			GanarEXP(remanente);
		}


	}

	public void Recibir_vida(int vidat) 
	{
		
		stats.vida = stats.vida + vidat;
		if (stats.vida <= stats.vida_maxima) 
		{
			Barra_vida.SetHelt(stats.vida);
		}
		else if(stats.vida > stats.vida_maxima) 
		{ 
			stats.vida = stats.vida_maxima;
			Barra_vida.SetHelt(stats.vida);
		}
	}

	public void saveStatus()
	{
		
		serializador.SavePersonaje(stats);
		//XML_serialisador xml = new XML_serialisador();
		//xml.EscrivirXML(sc_Inventario.Instancia.items[0]);
		//serializador.saveInventario();
	}
	public void loadStatus()
	{
		stats = serializador.LoadPersonaje();
		//XML_serialisador xml = new XML_serialisador();
		
		//sc_Inventario.Instancia.AddItem(xml.leerXML());
		//Barra_vida.SetMax_helth(stats.vida_maxima);
		//Barra_vida.SetHelt(stats.vida);
		//maxSpeed = 3.0f + stats.Movimiento;
		//serializador.loadInventario();
	}
	


}
