using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SocketIO;

public class GameManager : MonoBehaviour {

	private SocketIOComponent socket;
	Dictionary<string, string> data = new Dictionary<string, string>();
	int room = 0;
	public int PlayerSelect = 0;

	public GameObject PlayerOne, PlayerTwo;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("SocketIO");
    	socket = go.GetComponent<SocketIOComponent>();

		socektEvents();
	}

	public void socektEvents()
	{
		socket.On("socketID", getId);
		socket.On("room", getRoom);
		socket.On("movePlayer", MovePlayer);
	}

	public void MovePlayer(SocketIOEvent ev)
	{
		float x = float.Parse(ev.data["x"].ToString());
		float y = float.Parse(ev.data["y"].ToString());
		int lePlayer = int.Parse(ev.data["player"].ToString());
		Debug.Log("X: "+ x + "Y: " + y + "Player: " + lePlayer);

		if(lePlayer == 1)
		{
			PlayerOne.GetComponent<PlayerManager>().setTargetPos(x,y);
		}
		if(lePlayer == 2)
		{
			PlayerTwo.GetComponent<PlayerManager>().setTargetPos(x,y);
		}
	}

	public void getRoom(SocketIOEvent ev)
	{
		room = int.Parse(ev.data["room"].ToString());
		Debug.Log("MyRoom: " + room);
		Debug.Log("Ready!");
	}

	public void getId(SocketIOEvent ev)
	{
		Debug.Log("MyID: " + ev.data["id"].ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
		//Send Move
		if(Input.GetMouseButtonDown(0))
		{
			Vector2 tempPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

			data["x"] = string.Format("{0:N1}", tempPos.x);
			data["y"] = string.Format("{0:N1}", tempPos.y);
			data["player"] = PlayerSelect.ToString();
			socket.Emit("Pos", new JSONObject(data));
		}
	}
}
