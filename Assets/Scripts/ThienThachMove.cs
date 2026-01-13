using UnityEngine;
using System.Collections;

public class ThienThachMove : MonoBehaviour {

    public float speed;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        gameObject.Recycle();
    }
}
