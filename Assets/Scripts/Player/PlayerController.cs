using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject[] bulltet;
    public Transform bulletPos;
    public GameObject maybayno;
    public Transform [ ] pows;
    public GameObject giapThanToc;

    public static bool dead;
    public static float distance;
    public static int coin;
    public static int score;

    private Text textDistance;
    private Text textTien;
    private Text textScore;
    private int loaidan;

    void Start()
    {
        coin = 0;
        distance = 0;
        score = 0;
        dead = false;       
        textDistance = GameObject.Find("TextDistance").GetComponent<Text>();
        textTien = GameObject.Find("TextTien").GetComponent<Text>();
        textScore = GameObject.Find("TextScore").GetComponent<Text>();

        textDistance.text = "" + (int)distance + " m";
        textTien.text = "" + coin;
        textScore.text = "Score: " + score;
        if(!PlayerPrefs.HasKey(ClassConst.levelDan))
        {
            loaidan = 0;
        }
        else
        {
            loaidan = PlayerPrefs.GetInt(ClassConst.levelDan) - 1;
        }
        StartCoroutine(CallBullet(0.15f));
    }

    void Update()
    {
        if(GameController.giap == true)
        {
            giapThanToc.SetActive(true);
        }
        else
        {
            giapThanToc.SetActive(false);
        }

        if(!dead)
        {
            if(!GameController.giap)
            {
                distance += 0.5f;
            }
            else
            {
                distance += 5f;
            }
            textDistance.text = "" + (int)distance + "m";
            textScore.text = "Score: " + score;
        }
    }

    IEnumerator CallBullet(float time)
    {
        while(!dead)
        {
            if(GameController.pow == true)
            {
                for(int i = 0; i < pows.Length; i++)
                {
                    bulltet [ loaidan ].Spawn(pows[i].position, bulltet [ loaidan ].transform.rotation);
                }
            }
            else
            {
                bulltet [ loaidan ].Spawn(bulletPos.position, bulltet [ loaidan ].transform.rotation);
            }
            yield return new WaitForSeconds(time);  
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag=="ThienThach" && !dead && !GameController.giap)
        {
            dead = true;

            GameObject [ ] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < enemys.Length; i++)
            {
                enemys [ i ].Recycle();
            }

            GameObject [ ] tiens = GameObject.FindGameObjectsWithTag("Tien");
            for(int j = 0; j < tiens.Length; j++)
            {
                tiens [ j ].Recycle();
            }
            maybayno.Spawn(new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.Recycle();
        }

        if(other.tag == "Tien" && !dead)
        {
            coin += 10;
            textTien.text = "" + coin;
            other.gameObject.Recycle();
        }
    }   
}
