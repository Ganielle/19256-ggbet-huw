using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed;
    public float damage;
 

    void Update()
    {        
         transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        gameObject.Recycle();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().TakeDamage(damage*WareHouse.maybaySelected);
            gameObject.Recycle();
        }        
    }    
}
