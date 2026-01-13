using UnityEngine;
using System.Collections;

public class MayBayNo : MonoBehaviour {

    public void Destroy()
    {
        gameObject.Recycle();
    }
}
