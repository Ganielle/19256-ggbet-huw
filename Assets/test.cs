using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("IsNetworkAvailable" + Awu.IsNetworkAvailable);
        print("IsAndroidTV" + Awu.IsAndroidTV);
        print("IsConnectedViaCellular" + Awu.IsConnectedViaCellular);
        print("IsNetworkAvailable" + Awu.IsConnectedViaWifi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
