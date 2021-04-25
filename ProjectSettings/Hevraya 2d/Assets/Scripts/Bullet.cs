using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
   public Rigidbody2D rb;
   public Vector2 fireDir;
   public  float fireRot;
   public bool shoot = false;
    void Start()
    {
       //StartCoroutine(ExampleCoroutinetype1());
       StartCoroutine(ExampleCoroutinetype2());
    }
    void Update()
    {
     if(shoot){
        rb.velocity =fireDir;
        rb.rotation = fireRot;
     }   
     else{

      rb.velocity = new Vector2(0f,0f);
     }
    }

    void OnCollisionEnter2D(Collision2D colision){
        Destroy(gameObject);
    }
    IEnumerator ExampleCoroutinetype1()
    {
     
        rb.velocity =fireDir;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator ExampleCoroutinetype2()
    {
     
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
   
}
