using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public PauseGameController pauseGameController;
    public Transform[] enemyPoss;
    public GameObject[] enemys;   
    public GameObject panelInGame;
    public GameObject panelPauseGame;
    public GameObject panelGameOver;
    public GameObject tien;
    public Text sllBom;
    public Text sllGiap;
    public Text sllPow;
    public GameObject bom;
    public GameObject camera;
    public GameObject thienthach;
    public GameObject [ ] boss;

    public static bool pow;
    public static bool giap;

    private float timeThienThach;
    private float timeGiap;
    private float timePow;
    private float timer=3f;
    private float timeCallTien;
    private float timeCallBoss;
    private int highestScore;
    private int longestDistance;
    private int maxCoin;
    private Animator anim;
    private GameObject[] enemyCurrent;
    private Vector3 player;
    private LineRenderer line;
    private bool checkedThienThach;

    void OnEnable()
    {
        sllBom.text = PlayerPrefs.GetInt(ClassConst.bom).ToString();
        sllGiap.text = PlayerPrefs.GetInt(ClassConst.giap).ToString();
        sllPow.text = PlayerPrefs.GetInt(ClassConst.pow).ToString();
        anim = camera.GetComponent<Animator>();
        line = GetComponent<LineRenderer>();
        timeThienThach = 0f;
        timeGiap = 0f;
        timePow = 0f;
        timer = 3f;       
        timeCallBoss = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!panelPauseGame.activeInHierarchy && !panelGameOver.activeInHierarchy)
            {
                Debug.Log("Pause");
                ButPause();
            }
            else if (panelPauseGame.activeInHierarchy && !panelGameOver.activeInHierarchy)
            {
                Debug.Log("RESUME");
                pauseGameController.ButRefresh();
            }
        }

        if (!PlayerController.dead)
        {
            if(timePow > 0)
            {
                timePow -= Time.deltaTime;
            }
            else
            {
                pow = false;
            }

            if(timeGiap > 0)
            {
                timeGiap -= Time.deltaTime;
            }
            else
            {
                giap = false;
            }

            timeThienThach += Time.deltaTime;
            if(timeThienThach > 8f)
            {
                CallThienThach();
            }

            timeCallBoss += Time.deltaTime;
            if(timeCallBoss > 20)
            {
                CallBoss();
            }

            timer += Time.deltaTime;
            if(giap == false)
            {                
                if(timer >= 3f)
                {
                    if(0 < PlayerController.distance && PlayerController.distance <= 500)
                        CallEnemy(2, 0);
                    if(500 < PlayerController.distance && PlayerController.distance <= 1000)
                        CallEnemy(4, 0);
                    if(1000 < PlayerController.distance && PlayerController.distance <= 2000)
                        CallEnemy(4, 1);
                    if(2000 < PlayerController.distance && PlayerController.distance <= 3000)
                        CallEnemy(4, 2);
                    if(3000 < PlayerController.distance && PlayerController.distance <= 4000)
                        CallEnemy(4, 3);
                    if(4000 < PlayerController.distance)
                        CallEnemy(6, 4);
                }
            }
            if(timeGiap >2)
            {
                if(timer >= 0.15f)
                {                    
                    if(0 < PlayerController.distance && PlayerController.distance <= 1000)
                        CallEnemy(4, 0);
                    if(1000 < PlayerController.distance && PlayerController.distance <= 2000)
                        CallEnemy(4, 1);
                    if(2000 < PlayerController.distance && PlayerController.distance <= 3000)
                        CallEnemy(4, 2);
                    if(3000 < PlayerController.distance && PlayerController.distance <= 4000)
                        CallEnemy(4, 3);
                    if(4000 < PlayerController.distance)
                        CallEnemy(4, 4);                   
                }
                enemyCurrent = GameObject.FindGameObjectsWithTag("Enemy");
                for(int i = 0; i < enemyCurrent.Length; i++)
                {
                    if(enemyCurrent [ i ] != null)
                    {
                        enemyCurrent [ i ].GetComponent<EnemyMove>().speed = enemyCurrent [ i ].GetComponent<EnemyMove>().speedMove * 3;
                    }
                }
            }            
        }

        if(PlayerController.dead)
        {            
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {       
        yield return new WaitForSeconds(3f);

        PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) + PlayerController.coin);

        highestScore = PlayerPrefs.GetInt(ClassConst.highestScore);
        if(highestScore < PlayerController.score)
        {
            PlayerPrefs.SetInt(ClassConst.highestScore, PlayerController.score);
        }

        longestDistance = PlayerPrefs.GetInt(ClassConst.longestDistance);
        if(longestDistance < (int)PlayerController.distance)
        {
            PlayerPrefs.SetInt(ClassConst.longestDistance, (int)PlayerController.distance);
        }

        maxCoin = PlayerPrefs.GetInt(ClassConst.maxCoin);
        if(maxCoin < PlayerController.coin)
        {
            PlayerPrefs.SetInt(ClassConst.maxCoin, PlayerController.coin);
        }

        panelInGame.SetActive(false);
        panelPauseGame.SetActive(false);
        panelGameOver.SetActive(true);
        gameObject.SetActive(false);        
    }

    private void CallBoss()
    {
        boss [ Random.Range(0, boss.Length) ].Spawn(enemyPoss [ Random.Range(0, enemyPoss.Length) ].position, Quaternion.identity);
        timeCallBoss = 0;
    }

    private void CallEnemy(int sl, int way)
    {
        for(int i = 0; i < sl; i++)
        {           
            enemys [ way * 4 + Random.Range(0, 7) ].Spawn(enemyPoss[i].position, Quaternion.identity);
        }
        timer = 0;
    }   

    private void CallThienThach()
    {
        Vector3 pl = Vector3.zero
        ;
        if(!checkedThienThach)
        {
            pl = GameObject.FindGameObjectWithTag("Player").transform.position;            
            checkedThienThach = true;
        }
        line.enabled = true;
        line.SetPosition(0, new Vector3(pl.x + 0.3f, pl.y-5f, pl.z));
        line.SetPosition(1, new Vector3(pl.x + 0.3f, pl.y + 10f, pl.z));
        StartCoroutine(ThienThach(1f,pl));
        timeThienThach = 0f;
    }

    private IEnumerator ThienThach(float time,Vector3 pl)
    {
        thienthach.Spawn(new Vector3(pl.x + 0.3f, pl.y + 20f, pl.z), Quaternion.identity);
        yield return new WaitForSeconds(time);       
        line.enabled = false;             
        checkedThienThach = false;        
    }

    public void ButPause()
    {        
        Time.timeScale = 0;
        panelInGame.SetActive(false);
        panelPauseGame.SetActive(true);
    }

    public void ButBom()
    {
        if(PlayerPrefs.GetInt(ClassConst.bom) > 0)
        {
            AudioControll.instance.audioBom.Play();
            Instantiate(bom, bom.transform.position, bom.transform.rotation);
            PlayerPrefs.SetInt(ClassConst.bom, PlayerPrefs.GetInt(ClassConst.bom) - 1);
            sllBom.text = PlayerPrefs.GetInt(ClassConst.bom).ToString();
            anim.Play("CameraRung");
            GameObject [ ] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < enemys.Length; i++)
            {
                enemys [ i ].Recycle();
                PlayerController.score += 1;
            }
        }
    }

    public void ButGiap()
    {
        if(PlayerPrefs.GetInt(ClassConst.giap) > 0)
        {            
            timeGiap = 4f;
            giap = true;
            PlayerPrefs.SetInt(ClassConst.giap, PlayerPrefs.GetInt(ClassConst.giap) - 1);
            sllGiap.text = PlayerPrefs.GetInt(ClassConst.giap).ToString();
            anim.Play("CameraRung");
        }
    }

    public void ButPow()
    {
        if(PlayerPrefs.GetInt(ClassConst.pow) > 0)
        {           
            timePow = 10f;
            pow = true;
            PlayerPrefs.SetInt(ClassConst.pow, PlayerPrefs.GetInt(ClassConst.pow) - 1);
            sllPow.text = PlayerPrefs.GetInt(ClassConst.pow).ToString();
        }
    }

}
