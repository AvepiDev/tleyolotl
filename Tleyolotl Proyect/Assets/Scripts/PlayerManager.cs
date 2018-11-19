using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	float speed = 3f;
	Vector2 targetPos;

	// Use this for initialization
	void Start () {
		targetPos = (Vector2)this.transform.position;
	}

	public void setTargetPos(float x, float y)
	{
		targetPos.x = x;
		targetPos.y = y;
	}
	
	// Update is called once per frame
	void Update () {
		if((Vector2)this.transform.position != targetPos)
		{
			this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, speed * Time.deltaTime);
		}
	}
}
