using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

	public int index;
	public Animator animator;
	// Use this for initialization

	// Update is called once per frame

	public void changeScene()
	{
		ObstacleManager.totalTime= 0f;
		//animator.SetTrigger("clickPlay");
		//StartCoroutine (PlayGame ());
		Application.LoadLevel (index);

	}

	public void Quit()
	{

		Application.Quit ();
	}


}
