using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreKeeper : MonoBehaviour {

	// Use this for initialization
	public Text bestText;
	void Start () {
		bestText.text = "Best : " + PlayerPrefs.GetInt ("highscore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
