using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
     private Transform firepoint;
    public float bulletspeed =20f;
    public GameObject bulletPrefab;
    public string shootkey;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    public Vector2 shootdir;
    public Camera cam;
    void Start() 
    {
        firepoint = gameObject.transform;
    }
    
    void Update()
    {
        mouse_pos = cam.ScreenToWorldPoint(Input.mousePosition);
        shootdir = new Vector2(mouse_pos.x-firepoint.position.x,mouse_pos.y-firepoint.position.y);

        if (Input.GetKeyDown(shootkey))
        {
            RangeAttack();
        }
    }

    void RangeAttack()
    {
        GameObject bullet = Instantiate(bulletPrefab,firepoint.position, firepoint.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.velocity= shootdir * bulletspeed;
    }
}
