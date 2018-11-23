using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaVRWebView : MonoBehaviour {

    private string url = "https://cdn.instavr.co/html/8EYZ4Q2iIXtL8XjPvvs2_app.html?bust=36kws29wr78";

    WebViewObject webViewObject;

	// Use this for initialization
	void Start () {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(msg);
        });

        Debug.Log("URL: " + url);

        webViewObject.LoadURL(url);

        webViewObject.SetMargins(0, 0, 0, 0);

        webViewObject.SetVisibility(true);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
