using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float startHealth;
    public float health;
    public GameObject maybayno;

    public GameObject tienDrop;
   
    private Image imageHealth;

    void Awake()
    {
        imageHealth = GetComponentInChildren<Image>();
    }

    void OnEnable()
    {
        health = startHealth;
        imageHealth.fillAmount = health / startHealth;        
    }

    void OnBecameInvisible()
    {
        gameObject.Recycle();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag== "Player")
        {            
            maybayno.Spawn(gameObject.transform.position, Quaternion.identity);
            PlayerController.score += 1;
            gameObject.Recycle();

        }
    }

    public void TakeDamage(float amount)
    {
        if(GetComponent<Renderer>().isVisible)
        {
            if(health > 0)
            {
                health -= amount;
                imageHealth.fillAmount = health / startHealth;
            }
            else
            {
                if(gameObject.name == "db1(Clone)" || gameObject.name == "db2(Clone)" || gameObject.name == "db3(Clone)")
                {
                    GameObject [ ] enemys = GameObject.FindGameObjectsWithTag("Enemy");
                    for(int i = 0; i < enemys.Length; i++)
                    {
                        PlayerController.score += 1;
                        maybayno.Spawn(new Vector3(enemys [ i ].transform.position.x + 0.2f, enemys [ i ].transform.position.y, enemys [ i ].transform.position.z), Quaternion.identity);
                        tienDrop.Spawn(new Vector3(enemys[i].transform.position.x + 0.2f, enemys[i].transform.position.y, enemys[i].transform.position.z), Quaternion.identity);
                        enemys [ i ].Recycle();
                    }
                }
                else
                {
                    PlayerController.score += 1;
                    maybayno.Spawn(new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
                    tienDrop.Spawn(transform.position, Quaternion.identity);
                    gameObject.Recycle();
                }
            }
        }
    }
}
