using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

	public int index;

	// Use this for initialization

	// Update is called once per frame

	public void changeScene()
	{
		ObstacleManager.totalTime= 0f;
		Application.LoadLevel (index);

	}

	public void Quit()
	{

		Application.Quit ();
	}
}
