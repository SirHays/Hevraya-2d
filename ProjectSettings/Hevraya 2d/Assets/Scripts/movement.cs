using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
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
    public Animator an;




    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // screenCenter.x = Screen.width * .5f;
        // screenCenter.y = Screen.height * .5f;
        // Debug.Log(screenCenter.x);
        // Debug.Log(screenCenter.y);
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
        an.SetBool("iswalking", false);
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        
        an.SetFloat("dar", angle);
        
        
        
        

      if (Input.GetKey(KeyCode.W))
      {
        Movement += new Vector2(0f,Speed);
        an.SetBool("iswalking", true);
        }
      
      else if (Input.GetKey(KeyCode.S))
      {
        Movement += new Vector2(0f,-Speed);
        an.SetBool("iswalking", true);
        } 
      
      if (Input.GetKey(KeyCode.A))
      {
        Movement += new Vector2(-Speed,0f);
        an.SetBool("iswalking", true);
        } 
      
      else if (Input.GetKey(KeyCode.D))
      {
        Movement += new Vector2(Speed,0f);
        an.SetBool("iswalking", true);
        } 
       
    }
    void FixedUpdate() {
        rb.velocity = Movement;
        Movement = new Vector2(0f,0f);
        //an.SetBool("iswalking", false);
    }
}
