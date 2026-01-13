using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Locating : MonoBehaviour
{
    [SerializeField] Text textsimdata;
    [SerializeField] Text textState;
 
    [SerializeField] Text textCountry;
    [SerializeField] Text textCity;

    void Start()
    {
        textsimdata.text = Awu.IsConnectedViaCellular.ToString();


        StartCoroutine(DetectCountry());
    }

    IEnumerator DetectCountry()
    {
    //UnityWebRequest request = UnityWebRequest.Get("https://extreme-ip-lookup.com/json/?key=Gjl5n1EQR5PNpGg8tS4V");
    UnityWebRequest request = UnityWebRequest.Get("http://ip-api.com/json/?fields=61439");
    
        request.chunkedTransfer = false;
        yield return request.Send();
        textState.text = "Locating...";
        print("====" + request);
        if (request == null)
        {
            textState.text = "error : " + request.error;
        }
        else
        {
            if (request.isDone)
            {
                print("-----request---->>>>>>>>" + request.downloadHandler.text);
                Country res = JsonUtility.FromJson<Country>(request.downloadHandler.text);
                textState.text = res.regionName;

                textCity.text = res.city;
                textCountry.text = res.country;               
            }
        }
    }

}

internal class Country
{

	public string country;
	public string regionName;
	public string city;	
}