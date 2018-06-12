﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using UnityEngine.Analytics;

public class ObstacleManager : MonoBehaviour {

	public static bool blockPhase=true;
	public GameObject blockPrefab;
	public Transform player;
	private List<GameObject> blocks;
	private List<Vector3> blockLocations;
	private const float XGAP = 6f;
	private const float YGAP= 1f;
	private float timePassed=0f;
	private float totalTime =0;
	private int flag=0;
	private float phaseTime;

	// Use this for initialization
	void Start () 
	{

		blocks = new List<GameObject> ();
		blockLocations = new List<Vector3> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (flag == 0) {
			phaseTime = Random.Range (5, 15);
			flag = 1;
		
		}
			timePassed += Time.deltaTime;
		    totalTime += Time.deltaTime;

			if (totalTime >=phaseTime )
		{
		
			blockPhase = !blockPhase;
			//SwordPlay.swordPhase = true;
			totalTime =0;
			flag = 0;
		
		}
		if (blockPhase) {
			if (timePassed >= 0.8f) {
				if (blocks.Count == 0) {
					GameObject GO = Instantiate (blockPrefab, new Vector3 (player.position.x + 7f, Random.Range (4f, 12.8f), player.position.z), Quaternion.identity);
					blocks.Add (GO);
					blockLocations.Add (GO.transform.position);
				} else {
					float Y = Mathf.Clamp (player.position.y, 3.2f, 12.8f);
					//GameObject GO = Instantiate (blockPrefab, new Vector3 (player.position.x + Random.Range(3,XGAP),Y, player.position.z), Quaternion.identity);

					GameObject GO = Instantiate (blockPrefab, new Vector3 (player.position.x + Random.Range (3, XGAP), Random.Range (player.position.y, 8f), player.position.z), Quaternion.identity);
					blocks.Add (GO);
					blockLocations.Add (GO.transform.position);


				}
				


				for (int i = blocks.Count - 1; i >= 0; i--) {
			
					if (player.position.x - blockLocations [i].x > 8f) {

						Destroy (blocks [i]);
						blocks.RemoveAt (i);
						blockLocations.RemoveAt (i);
					}
					timePassed = 0f;
			
				}
			}
		}
	}
}