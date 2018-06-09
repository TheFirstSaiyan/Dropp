using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnPlatformDown : MonoBehaviour 
{

	public GameObject player;
	public GameObject bottomWallPrefab;
	private List<GameObject> bottomWalls;
	private Vector3 start;
	private int count = 1;
	private float distance =29.9f;
	private Quaternion rotation;
	// Use this for initialization
	void Start () 
	{
		bottomWalls = new List<GameObject> ();
		bottomWalls.Add (gameObject);
		start = transform.position;
		rotation = transform.rotation;
	}

	// Update is called once per frame
	void Update () {


		if (player.transform.position.x>=bottomWalls[bottomWalls.Count-1].transform.position.x-20f) 
		{
			GameObject GO=Instantiate(bottomWallPrefab,new Vector3(start.x+count*distance,start.y,start.z),rotation);
			count += 1;
			bottomWalls.Add (GO);


		}
		if (bottomWalls.Count > 2) 
		{
			if (player.transform.position.x >= 10f + bottomWalls [2].transform.position.x) 
		{

			Destroy (bottomWalls [1]);
			bottomWalls.RemoveAt (1);

		}
		}

	}
}
