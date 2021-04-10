using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
   
      
    public float Speed;
    private Rigidbody2D rb;
    private Vector2 Movement;

     private Vector3 mouse_pos;
    public Transform target; //Assign to the object you want to rotate
    private Vector3 object_pos;
    private float angle;


    private Vector2 lookInput, screenCenter;
    private Animation anim;




    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        rb = GetComponent<Rigidbody2D>();
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        Debug.Log(screenCenter.x);
        Debug.Log(screenCenter.y);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
    

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;
        //problem:
        //animation component doesn't want to play animations might switch to animator and modify controller further. will fix later since its 2 am.
        //also, we need sprites for the character facing all other directions except forward and animations for walking to the side. -Gal
       if(lookInput.y>screenCenter.y && Input.GetKey(KeyCode.W)){
            anim.Play("up");
       }
       else if(lookInput.y<screenCenter.y && Input.GetKey(KeyCode.S)){
            anim.Play("down");
       }
        
        
        

      if (Input.GetKey(KeyCode.W))
      {Movement += new Vector2(0f,Speed);}
      
      else if (Input.GetKey(KeyCode.S))
      {Movement += new Vector2(0f,-Speed);} 
      
      if (Input.GetKey(KeyCode.A))
      {Movement += new Vector2(-Speed,0f);} 
      
      else if (Input.GetKey(KeyCode.D))
      {Movement += new Vector2(Speed,0f);} 
       
    }
    void FixedUpdate() {
        rb.velocity = Movement;
        Movement = new Vector2(0f,0f);
    }
}
