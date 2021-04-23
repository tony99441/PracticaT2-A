using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
   public float velocidadCorrer = 10;
      private Animator animator;
      private Rigidbody2D rb;
      public float fuerzaSalto = 10f;
      public GameObject Moneda; 
      private Transform tr;
      
      private SpriteRenderer sr;
      private const int Animacion_Quieto = 0;
      private const int Animacion_Correr = 1;
      private const int Animacion_Saltar = 2;
      private const int Animacion_Slide =3;
  
      private Collider2D cl;
  
      public bool EstadoMuerte = false;
      void Start()
      {
          rb = GetComponent<Rigidbody2D>();
          animator = GetComponent<Animator>();
          sr = GetComponent<SpriteRenderer>();
          tr = GetComponent<Transform>();
          cl = GetComponent<Collider2D>();
          Moneda = GetComponent<GameObject>(); 
      }
  
      // Update is called once per frame
      void Update()
      {
          if (EstadoMuerte == false)
          {
              if (Input.GetKey(KeyCode.RightArrow))
              {
                  tr.localScale = new Vector3(0.53f, 0.516f, 1);
                  rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
                  CambiarAnimacion(Animacion_Correr);
                  if (Input.GetKeyDown(KeyCode.Space))
                  {
                      CambiarAnimacion(Animacion_Saltar);
                      rb.velocity = Vector2.up * fuerzaSalto;
                     
                  }
              }
              if (Input.GetKey(KeyCode.LeftArrow))
              {
                  tr.localScale = new Vector3(-0.53f, 0.516f, 1);
                  rb.velocity = new Vector2(-velocidadCorrer, rb.velocity.y);
                  CambiarAnimacion(Animacion_Correr);
                  if (Input.GetKeyDown(KeyCode.Space))
                  {
                      CambiarAnimacion(Animacion_Saltar);
                      rb.velocity = Vector2.up * fuerzaSalto;
                      
                  }
              }
          }

          else
          {
              CambiarAnimacion(Animacion_Slide); 
          }
          
      }
  
      private void CambiarAnimacion(int animation)
      {
          animator.SetInteger("Estado", animation);
      }
  
      
  
      private void OnCollisionEnter2D(Collision2D collision)
      {
          if (collision.gameObject.tag == "Moneda")
          {
              Destroy(GameObject.FindWithTag("Moneda"));
          }
  
         
          
      }
  }