using UnityEngine;
using System.Collections;

public class BackGroundRoll : MonoBehaviour {

    public float speedRoll;
    public float titleSizeY;

    private Vector3 startPos;
    private float timeMove;   

    void Start()
    {
        startPos = transform.position;      
    }

    void Update()
    {
        if(!PlayerController.dead)
        {            
            timeMove += Time.deltaTime;
            float newPos = Mathf.Repeat(timeMove * speedRoll, titleSizeY);
            transform.position = startPos + Vector3.down * newPos;            
        }
    }
}
