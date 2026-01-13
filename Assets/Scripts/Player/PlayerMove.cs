using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speedMove;
    public float xMin, xMax, yMin = -3, yMax = 3;

    private Vector3 mousePos;
    private Vector3 moverment;
    private Rigidbody2D rgb;   

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR
        if(Input.GetButtonDown("Fire1"))
        {                         
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);                                  
        }
        if(Input.GetButton("Fire1"))
        {           
           transform.position += new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x-mousePos.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - mousePos.y, 0)*speedMove *Time.deltaTime;
           mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        rgb.position = new Vector3(Mathf.Clamp(rgb.position.x, xMin, xMax), Mathf.Clamp(rgb.position.y, yMin, yMax), 0);
#endif
#if UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(touch.position);
                transform.position = Vector3.Lerp(transform.position, new Vector3(touchedPos.x, touchedPos.y, -1), 20*Time.deltaTime);
            }
        }

        rgb.position = new Vector3(Mathf.Clamp(rgb.position.x, xMin, xMax), Mathf.Clamp(rgb.position.y, yMin, yMax), 0);
#endif
    } 
}
