using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class WebViewVisibility : MonoBehaviour {

	WebViewObject webview;
	bool webview_disabled = false;

	public Text message = null;

	// Use this for initialization
	void Start() {
		message.enabled = false;

		webview = GetComponent<WebViewObject>();

		webview.Init((msg) => {
			Debug.Log("Call from Web view : " + msg);

			if(Regex.IsMatch(msg, @"^close")) {
				webview_disabled = true;

				message.text = msg;
			}
		});

		var url = "https://tayutaedomo-webview.herokuapp.com/webview_callback.html";
		Debug.Log(url);

		webview.LoadURL(url);
		webview.SetVisibility(true);
		webview.SetMargins(100, 100, 100, 100);
	}
	
	// Update is called once per frame
	void Update() {
		if (webview_disabled) {
			message.enabled = true;

			webview_disabled = false;

			webview.SetVisibility(false);
		}
	}
}
