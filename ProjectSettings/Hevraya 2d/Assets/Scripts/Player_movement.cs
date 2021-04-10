using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public Animation walkingUPanim;
      
    public string Up;
    public string Down;
    public string Left;
    public string Right;
    public float Speed;
    private Rigidbody2D rb;
    private Vector2 Movement;

     private Vector3 mouse_pos;
    public Transform target; //Assign to the object you want to rotate
    private Vector3 object_pos;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation an = GetComponent<Animation>();
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if(angle <= 180 && angle >=0){
            
            GetComponent<Animation>().Play("walking up tho");
        }
        else{
            an.Play("WALKING");
        }

        
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
