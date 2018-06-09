using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpawnPlatformUp : MonoBehaviour 
{
	public GameObject player;
	public GameObject upWallPrefab;
	private List<GameObject> upWalls;
	private Vector3 start;
	private float distance =29.9f;
	private int count=1;
	private Quaternion rotation;


	void Start () 
	{
		upWalls = new List<GameObject> ();
		upWalls.Add (gameObject);
		start = transform.position;
		rotation = transform.rotation;

	}
	


	void Update ()
	{
		//Debug.Log (upWalls.Count);

		if (player.transform.position.x>=upWalls[upWalls.Count-1].transform.position.x-20f) 
		{
			GameObject GO=Instantiate(upWallPrefab,new Vector3(start.x+count*distance,start.y,start.z),rotation);
			count+=1;
			upWalls.Add (GO);
		}
		if (upWalls.Count > 2) {
			if (player.transform.position.x >= 10f + upWalls [2].transform.position.x) {

				Destroy (upWalls [1]);
				upWalls.RemoveAt (1);

			}
		}

	}
}
