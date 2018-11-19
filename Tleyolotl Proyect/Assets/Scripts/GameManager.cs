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
	}

	public void getRoom(SocketIOEvent ev)
	{
		room = int.Parse(ev.data["room"].ToString());
		Debug.Log("MyRoom: " + room);
	}

	public void getId(SocketIOEvent ev)
	{
		Debug.Log("MyID: " + ev.data["id"].ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
