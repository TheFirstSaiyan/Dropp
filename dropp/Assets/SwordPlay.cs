using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SwordPlay : MonoBehaviour {



	public Transform player;
	public GameObject swordPrefab;
	private float angleToRotate1;
	private float angleToRotate2;
	private List<GameObject> swords;
	//private List<Vector3> swordTargets;
	private List<Vector3> swordDirections;
	private float swordSpeed = 700f;
	private float timePassed=0f;
	private float totalTime;
	//public static bool swordPhase =false;


	// Use this for initialization
	void Start () {
		swords = new List<GameObject> ();
		//	swordTargets = new List<Vector3> ();
		swordDirections = new List<Vector3> ();
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
	
		if (!ObstacleManager.blockPhase) {
			timePassed += Time.deltaTime;
			if (timePassed > 1.5f) {
				//Vector3 target = player.position;
				GameObject sword1 = Instantiate (swordPrefab, new Vector3 (player.position.x + Random.Range (5f, 12f), Random.Range (4f, 12.8f), player.position.z), Quaternion.identity);

				GameObject sword2 = Instantiate (swordPrefab, new Vector3 (Random.Range (player.position.x - 10f, player.position.x - 3f), Random.Range (4f, 12.8f), player.position.z), Quaternion.identity);

				angleToRotate1 = Vector3.Angle (sword1.transform.position - player.position, sword1.transform.up);
				angleToRotate2 = Vector3.Angle (sword2.transform.position - player.position, sword2.transform.up);

				sword1.transform.Rotate (new Vector3 (180 + angleToRotate1, 90, 0));
				sword2.transform.Rotate (new Vector3 (-1 * angleToRotate2 + 180, 90, 0));
			
				Vector3 targetDirection1 = player.position - sword1.transform.position;
				Vector3 targetDirection2 = player.position - sword2.transform.position;

				swords.Add (sword1);
				swords.Add (sword2);
				//swordTargets.Add (target);
				//swordTargets.Add (target);
				swordDirections.Add (targetDirection1);
				swordDirections.Add (targetDirection2);
				StartCoroutine (MoveSwords (sword1, targetDirection1));
				StartCoroutine (MoveSwords (sword2, targetDirection2));

				timePassed = 0f;
		    
			}
			for (int i = swords.Count - 1; i >= 0; i--) {

				if (swords [i].transform.position.x <= player.position.x - 15f ||
				   swords [i].transform.position.y >= 15f ||
				   swords [i].transform.position.y <= 2f ||
				   swords [i].transform.position.x >= player.position.x + 50f) {

					Destroy (swords [i]);
					swords.RemoveAt (i);
					swordDirections.RemoveAt (i);
					//swordTargets.RemoveAt (i);

				}

			}

		}
	
		//sword.transform.rotation *=Quaternion.Euler(0,0,20);
	}

	IEnumerator MoveSwords(GameObject sword,Vector3 direction)
	{
		yield return new WaitForSeconds (0.1f);
		/*for (int i = 0; i < swords.Count; i++) {

			//swords [i].GetComponent<Rigidbody> ().MovePosition (swordTargets [i]);
			//swords [i].transform.position -= new Vector3 (0.3f, 0.3f, 0);
			swords[i].GetComponent<Rigidbody>().AddForce(swordDirections[i].normalized * swordSpeed * Time.deltaTime,ForceMode.Impulse);



		}*/
		sword.GetComponent<Rigidbody> ().AddForce (direction.normalized * swordSpeed * Time.deltaTime, ForceMode.Impulse);

	}
}
