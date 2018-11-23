using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/*
 * Refer: https://qiita.com/snaka/items/46042be015ad320d5f4b
 */
public class MyWebView : MonoBehaviour {

    // Inspector で画面上に配置した GUI Text にアタッチする
    public Text DebugText;

    string m_filePath;

    // Use this for initialization
    void Start () {
        m_filePath = Path.Combine(Application.persistentDataPath, "sample.html");
        Debug.Log (m_filePath);
        PrepareHTML();

        // このスクリプトがアタッチされているGameObjectからWebViewObjectを取得する
        var webview = GetComponent<WebViewObject>();

        // WebViewObject の初期化時にWebページ側から呼び出すことができるコールバック関数を定義する。
        // Web側からコールバック関数呼び出すには、リンク要素の href 属性などURLを指定する箇所で
        // 'unit:(任意の文字列)' のように指定すると、コールバック関数が呼び出される。
        // このとき、"(任意の文字列)"の部分が関数の引数として渡される。
        webview.Init ((string msg) => {
            Debug.Log ("Call from Web view : " + msg);
            DebugText.text = msg;
        });

        // var url = "file://" + m_filePath;
        // var url = "https://google.co.jp";
        var url = "https://tayutaedomo-webview.herokuapp.com/MyWebView.html";
        Debug.Log(url);

        webview.LoadURL(url);
        webview.SetVisibility(true);
        webview.SetMargins(10,100,10,10);
    }
    
    // Update is called once per frame
    void Update () {
    }

    void PrepareHTML() {
        using(var writer = new StreamWriter(m_filePath, false)) {
            writer.Write(
@"<html>
<body>
Hello unity-webview !!!<br/>
<ul>
  <li><a href='unity:hoge'>callback 'hoge'</a></li>
  <li><a href='unity:fuga'>callback 'fuga'</a></li>
</ul>
</body>
</html>
");
            writer.Close();
        }
    }
}
