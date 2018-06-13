using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;
using System.Runtime.Serialization.Formatters;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


           // public Rigidbody rb;
            private Vector2 startPos;
            private Vector2 endPos;
            private float force=150;
	        private float speed =6f;
	        public GameObject cam;
	        public GameObject gameOverScreen;
            private float maxDragDistance = 65f;
	        public GameObject platformUp;
            public GameObject platformDown;
            public GameObject ObsManager;
		    private float timePassed=0f;
			public  Text scoreText;
			public Text endScreenScoreText;
			public Text endScreenBestText;
			private float score = 0;
			private int highScore;
			private int scoreMultiplier=10;
	 
    
	void Start()
	{
		gameOverScreen.SetActive (false);
		timePassed = 0f;
		highScore = PlayerPrefs.GetInt ("highscore", 0);
	}
	void FixedUpdate()
	{
		timePassed += Time.deltaTime;
		if (timePassed >= 10f) {
		
			scoreMultiplier += 3;
			timePassed = 0;
		}
		if (Input.GetMouseButtonDown (0) && timePassed>=0.2f) {
			Physics.gravity = new Vector3 (0, -1 * Physics.gravity.y, 0);
		}
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		score += Time.deltaTime * 10;

		scoreText.text= "SCORE :" + (int)score;

	}
	/*private void Update()
	{

		if (Input.GetMouseButton (0)) {
			float z = transform.position.z;
			transform.position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3 (transform.position.x, transform.position.y, z);
		}

	}*/


    private void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.gameObject.CompareTag("rockObstacle"))
        {
			//cam.GetComponent<Animation>().Play("gameOverAnimation");
			EndGame();
		}


        }
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("sword"))
		{
			EndGame ();
			//cam.GetComponent<Animation>().Play("gameOverAnimation");
		}
		}



	private void EndGame()
	{
		if ((int)score >= highScore) {
			PlayerPrefs.SetInt ("highscore", (int)score);
			endScreenBestText.text = "Best : " + (int)score;

		}
		else
			endScreenBestText.text = "Best : " + highScore;
		
		endScreenScoreText.text = "Score : " + (int)score;
		ObstacleManager.totalTime= 0f;
		gameOverScreen.SetActive(true);    
		cam.GetComponent<FollowPlayer> ().enabled = false;
		platformUp.GetComponent<SpawnPlatformUp> ().enabled = false;
		platformDown.GetComponent<SpawnPlatformDown> ().enabled = false;
		ObsManager.GetComponent<SwordPlay> ().enabled = false;
		ObsManager.GetComponent<ObstacleManager> ().enabled = false;
		GetComponent<PlayerController> ().enabled = false;



	}
    }
