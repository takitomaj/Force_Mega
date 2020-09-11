
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

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
	public Text Nombre;

	public Text dano;
	public Text vida;

	public GameObject droper;
	
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
	public Canvas Canvas_mochila;
	public Canvas canvas_Pausa;
	public Canvas barraVida;
	public int Vida_acumulada;

	public bool derecha = true;
	
	void Start()
	{
		Canvas_mochila.enabled = false;
		
		cam = Camera.main;
		//stats = new Data_Personaje(true);
		loadStatus();
		Nombre.text = stats.Nombre;
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		SetVida();


		maxSpeed = 3.0f + stats.Movimiento;
		if (canvas_Pausa.isActiveAndEnabled)
		{
			canvas_Pausa.enabled = false;
		}
		vida.enabled = false;
		dano.enabled = false;
	}
	public void MostrarDano(int i_dano)
	{
		dano.enabled = true;
		dano.rectTransform.transform.position = droper.transform.position;

		Rigidbody2D rb_dano = dano.GetComponent<Rigidbody2D>();
		dano.text = i_dano+"";

		rb_dano.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);
		int ladop = UnityEngine.Random.Range(1, 100);
		if (ladop >= 50)
		{
			rb_dano.AddForce(Vector2.left * 1, ForceMode2D.Impulse);
		}
		else
		{
			rb_dano.AddForce(Vector2.right * 1, ForceMode2D.Impulse);
		}
		
		//yield return new WaitForSeconds(10f);
		//dano.enabled = false;


	}
	
	public void MostrarVida(int i_Vida)
	{
		Vida_acumulada += i_Vida;
		vida.enabled = true;
		vida.rectTransform.transform.position = droper.transform.position;

		Rigidbody2D rb_vida = vida.GetComponent<Rigidbody2D>();
		vida.text = Vida_acumulada + "";

		rb_vida.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);
		int ladop = UnityEngine.Random.Range(1, 100);
		if (ladop >= 50)
		{
			rb_vida.AddForce(Vector2.left * 1, ForceMode2D.Impulse);
		}
		else
		{
			rb_vida.AddForce(Vector2.right * 1, ForceMode2D.Impulse);
		}
			
		if (stats.vida>=stats.vida_maxima) { Vida_acumulada = 0; }
		
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
		if (Canvas_mochila.isActiveAndEnabled) 
		{
			Canvas_mochila.enabled = false;
			
		} else 
		{
			Canvas_mochila.enabled = true;
			 
		}
	}
	public void pausa()
	{
		if (canvas_Pausa.isActiveAndEnabled)
		{
			canvas_Pausa.enabled = false;

		}
		else
		{
			canvas_Pausa.enabled = true;

		}
	}
	public void melee_atack()
	{
		Espadazo();
	}
	
	public int getLvl() { return stats.lvl; }
	public void updateName() 
	{
		Nombre.text = stats.Nombre;
	}
	void Update()
	{

		//Nombre.text = stats.Nombre;
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
		if (collision.gameObject.tag=="suelo") 
		{
			tirra = true;
		}
		if (collision.gameObject.tag == "Curacion +1")
		{
			tirra = true;
			Recibir_vida(1);
		}
		if(collision.gameObject.tag == "Enemy") 
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			//Debug.Log("colisiona Enemigo");
			Rigidbody2D rb2d=gameObject.GetComponent<Rigidbody2D>();
			rb2d.AddForce(Vector2.up *8,ForceMode2D.Impulse);
			rb2d.AddForce(Vector2.left * 1000, ForceMode2D.Impulse);
			Debug.Log("dano"+ enemy.dano);
			Recibir_Dano(enemy.dano);

		}
	}
	public void OnCollisionExit2D(Collision2D collision)
	{
		
		tirra = false;
	}

	public void Recibir_Dano(int dano)
	{
		int danoNeto = -dano + stats.Constitucion + sc_equipamiento.Instancia.getModConstitucion();
		if (danoNeto >= 0) { danoNeto = 0; }
		stats.vida = danoNeto +stats.vida  ;
		Barra_vida.SetHelt(stats.vida);
		//StartCoroutine(MostrarDano_instancia(danoNeto));
		MostrarDano(danoNeto);

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
			MostrarVida(vidat);
		}
		else if(stats.vida > stats.vida_maxima) 
		{ 
			stats.vida = stats.vida_maxima;
			Barra_vida.SetHelt(stats.vida);
		}
		
	}

	public void saveStatus()
	{
		stats.getEquipo_to_Serialisable();
		stats.getInventari_to_serialisable();
		stats.dinero = sc_Inventario.Instancia.Dineros;
		serializador.SavePersonaje(stats);
	
	}
	
	public void loadStatus()
	{
		if (serializador.LoadPersonaje()!=null) { 
			stats = serializador.LoadPersonaje();
			stats.setEquipo();
			stats.setInventario();
			sc_Inventario.Instancia.Dineros = stats.dinero;
		}
		else 
		{
			stats = new Data_Personaje(false);
		}
		
	}
	


}
