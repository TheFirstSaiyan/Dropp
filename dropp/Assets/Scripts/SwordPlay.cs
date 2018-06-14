using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlay : MonoBehaviour {



	public Transform player;
	public GameObject swordPrefab;
	private float angleToRotate1;
	private float angleToRotate2;
	private List<GameObject> swords;
	private List<Vector3> swordDirections;
	private float swordSpeed = 700f;
	private float timePassed=0f;
	private float totalTime;
	private float lookAhead =3f;


	// Use this for initialization
	void Start () {
		swords = new List<GameObject> ();
		swordDirections = new List<Vector3> ();
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
	
		if (!ObstacleManager.blockPhase) {
			timePassed += Time.deltaTime;
			if (timePassed > 0.5f) {
				// create swords
				GameObject sword1 = Instantiate (swordPrefab, new Vector3 (player.position.x + Random.Range (6f, 12f), Random.Range (4f, 12.8f), player.position.z), Quaternion.identity);
				GameObject sword2 = Instantiate (swordPrefab, new Vector3 (Random.Range (player.position.x - 10f, player.position.x - 4f), Random.Range (4f, 12.8f), player.position.z), Quaternion.identity);

				//find angle to rotate the swords toward the player
				angleToRotate1 = Vector3.Angle (sword1.transform.position - new Vector3(player.position.x+lookAhead,player.position.y,player.position.z), sword1.transform.up);
				angleToRotate2 = Vector3.Angle (sword2.transform.position -  new Vector3(player.position.x+lookAhead,player.position.y,player.position.z), sword2.transform.up);

				//rotate
				sword1.transform.Rotate (new Vector3 (180 + angleToRotate1, 90, 0));
				sword2.transform.Rotate (new Vector3 (-1 * angleToRotate2 + 180, 90, 0));
			
				//keep in store the direction to move for each sword
				Vector3 targetDirection1 = new Vector3(player.position.x+lookAhead,player.position.y,player.position.z) - sword1.transform.position;
				Vector3 targetDirection2 = new Vector3(player.position.x+lookAhead,player.position.y,player.position.z) - sword2.transform.position;

				swords.Add (sword1);
				swords.Add (sword2);

				swordDirections.Add (targetDirection1);
				swordDirections.Add (targetDirection2);

				//wait for sometime and throw the sword at the player
				StartCoroutine (MoveSwords (sword1, targetDirection1));
				StartCoroutine (MoveSwords (sword2, targetDirection2));

				timePassed = 0f;
		    
			}



			for (int i = swords.Count - 1; i >= 0; i--)
			{

				if (swords [i].transform.position.x <= player.position.x - 15f ||
				   swords [i].transform.position.y >= 15f ||
				   swords [i].transform.position.y <= 2f ||
				   swords [i].transform.position.x >= player.position.x + 50f)
				{

					Destroy (swords [i]);
					swords.RemoveAt (i);
					swordDirections.RemoveAt (i);

				}

			}

		}
	
	}

	IEnumerator MoveSwords(GameObject sword,Vector3 direction)
	{
		
		yield return new WaitForSeconds (Random.Range(0.02f,0.1f));
		sword.GetComponent<Rigidbody> ().AddForce (direction.normalized * swordSpeed * Time.deltaTime, ForceMode.Impulse);

	}
}
