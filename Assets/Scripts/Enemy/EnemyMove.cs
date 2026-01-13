using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public float speedMove;
    public float speed;

    void OnEnable()
    {
        speed = speedMove;
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
