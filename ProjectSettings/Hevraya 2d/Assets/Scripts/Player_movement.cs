using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public string Up;
    public string Down;
    public string Left;
    public string Right;
    public float Speed;
    private Rigidbody2D rb;
    private Vector2 Movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
      if (Input.GetKey(Up))
      {Movement += new Vector2(0f,Speed);}
      
      else if (Input.GetKey(Down))
      {Movement += new Vector2(0f,-Speed);} 
      
      if (Input.GetKey(Left))
      {Movement += new Vector2(-Speed,0f);} 
      
      else if (Input.GetKey(Right))
      {Movement += new Vector2(Speed,0f);} 
       
    }
    void FixedUpdate() {
        rb.velocity = Movement;
        Movement = new Vector2(0f,0f);
    }
}
