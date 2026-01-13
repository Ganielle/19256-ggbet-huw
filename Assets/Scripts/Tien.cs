using UnityEngine;
using System.Collections;

public class Tien : MonoBehaviour {

    public float speedStart;
    private float speed;

    void OnEnable()
    {
        speed = speedStart;
    }

    void Update()
    {
        speed += 0.03f;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        gameObject.Recycle();
    }
}
