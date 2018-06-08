using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = GameObject.Find("player").transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.Find("player").transform.position - offset;
	}
}
