using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public string shootkey;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    public Vector2 shootdir;
    public Camera cam;
    public LineRenderer lineRenderer;
    public float bullet_cooldown;
    bool bulletshot = false;
   
    
    void Update()
    {
    
        mouse_pos = cam.ScreenToWorldPoint(Input.mousePosition);
        shootdir = new Vector2(mouse_pos.x-firepoint.position.x,mouse_pos.y-firepoint.position.y);

        if (Input.GetKeyDown(shootkey)&& !bulletshot)
        {
            //StartCoroutine( RangeAttacktype1());
            RangedAttackType2();
            
           //StartCoroutine(Wait());
           
        }
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(bullet_cooldown);
        bulletshot= false;
    }

    IEnumerator RangeAttacktype1()
    {
        bulletshot= true;
      RaycastHit2D hitInfo =  Physics2D.Raycast(firepoint.position,shootdir);
      Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
      Bullet bullet = bulletPrefab.GetComponent<Bullet>();
      
      if(hitInfo)
      {
          bullet.fireDir = new Vector2(-firepoint.position.x,-firepoint.position.y) + hitInfo.point;
          lineRenderer.SetPosition(0, firepoint.position);
          lineRenderer.SetPosition(1, hitInfo.point);
      }
     else{
         bullet.fireDir = shootdir;
         lineRenderer.SetPosition(0, firepoint.position);
         lineRenderer.SetPosition(1, new Vector2(firepoint.position.x, firepoint.position.y)+shootdir*100);
     }
     lineRenderer.enabled = true;
     yield return new WaitForSeconds(0.2f);
     

     lineRenderer.enabled = false;
     
    }
    void RangedAttackType2()
    {
        //bulletshot= true;
       GameObject Bulletobject = Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
      Bullet bullet = Bulletobject.GetComponent<Bullet>();
      Rigidbody2D bulletRb = Bulletobject.GetComponent<Rigidbody2D>();
      float angle = Mathf.Atan2(shootdir.x,shootdir.y) ;
      bullet.fireDir = new Vector2(Mathf.Sin(angle),Mathf.Cos(angle))*100f;
      bullet.fireRot = angle* Mathf.Rad2Deg;
      bullet.shoot = true;
    }
}
