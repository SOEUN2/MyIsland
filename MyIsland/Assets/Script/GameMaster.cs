using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SocketIO;

public class GameMaster : MonoBehaviour {

	//float timer;
	private SocketIOComponent socket;

	Dictionary<string, string> data = new Dictionary<string, string>();
	JSONObject jdata;

	// Use this for initialization
	void Start () {
		GameObject goSocket = GameObject.Find("SocketIO");
		socket = goSocket.GetComponent<SocketIOComponent>();
		socket.On("SendMessageByNode", SendMessageByNode);

		data.Add("name", "dooobeee");
		data.Add("message", "hi there!");

		jdata = new JSONObject(data);		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(jdata);
		socket.Emit("SendMessageByUnity", jdata);
		Debug.Log("[SocketIO] Send Message to Server...");

		//LoadingScene이면 2.0f지나고 씬전환
		//if (SceneManager.GetActiveScene().name == "LoadingScene") {
			//timer += Time.deltaTime;
			//Debug.Log (timer);
			//if (timer >= 2.0f) {
			//	SceneManager.LoadScene ("LoginScene");
			//}
		//}
	}
	private void SendMessageByNode(SocketIOEvent e)
	{
		//name : 이벤트 이름, data : JSON Data
		Debug.Log("[SocketIO] Received Data from Node: {" + e.name + " : " + e.data + "}");

		data = e.data.ToDictionary();

		string tmp;

		//딕셔너리로 변환한 값의 필드로 값을 찾아 출력한다.
		data.TryGetValue("name", out tmp);

		Debug.Log(tmp);

		if (e.data.ToDictionary().ContainsKey("name")) Debug.Log("name is here!!");
		else Debug.Log("name is not here!!");
	}

	public void GoMainScene() {
		SceneManager.LoadScene ("MainScene");
	}
	public void GoSignupScene() {
		SceneManager.LoadScene ("SignupScene");
	}
	public void GoLoginScene() {
		SceneManager.LoadScene ("LoginScene");
	}
	public void GoLevelScene() {
		SceneManager.LoadScene ("LevelScene");
	}
	public void GoShopScene() {
		SceneManager.LoadScene ("ShopStrucScene");
	}
	public void GoShopDecoScene() {
		SceneManager.LoadScene ("DecoScene");
	}
	public void GoShopToolScene() {
		SceneManager.LoadScene ("ShopToolScene");
	}
	public void GoEditScene() {
		SceneManager.LoadScene ("EditScene");
	}
	public void GoARScene() {
		SceneManager.LoadScene ("ARScene");
	}
}
