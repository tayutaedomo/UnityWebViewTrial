using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Refer: https://qiita.com/mczkzk/items/0ed0665c7da3b550770e#unity-webview
 */
public class SimpleWebView : MonoBehaviour {

    private string url = "https://www.google.co.jp/";
    WebViewObject webViewObject;

    // Use this for initialization
    void Start () {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(msg);
        });
        webViewObject.LoadURL(url);
        // 中央に配置
        Debug.Log("Screen.width: " + Screen.width);
        Debug.Log("Screen.height: " + Screen.height);
        webViewObject.SetMargins(Screen.width / 4, Screen.height / 4, Screen.width / 4, Screen.height / 4);
        webViewObject.SetVisibility(true);
    }
    
    // Update is called once per frame
    void Update () {
    }
}
