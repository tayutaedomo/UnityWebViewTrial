using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleSigninWebView : MonoBehaviour {

    private string url = "https://accounts.google.com/Login?hl=Ja";

    WebViewObject webViewObject;

	// Use this for initialization
	void Start () {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(msg);
        });

        Debug.Log("URL: " + url);

        webViewObject.LoadURL(url);

        Debug.Log("Screen.width: " + Screen.width);
        Debug.Log("Screen.height: " + Screen.height);

        //webViewObject.SetMargins(Screen.width / 4, Screen.height / 4, Screen.width / 4, Screen.height / 4);
        //webViewObject.SetMargins(0, 0, Screen.width, Screen.height);
        //webViewObject.SetMargins(10, 10, 10, 10);
        webViewObject.SetMargins(0, 0, 0, 0);

        webViewObject.SetVisibility(true);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
