using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    private Vector3 offset;
	private float startY;
	// Use this for initialization
	void Start () {
        offset = GameObject.Find("player").transform.position - transform.position;
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.Find("player").transform.position - offset;
		transform.position = new Vector3 (transform.position.x,startY,transform.position.z);
	}
}
