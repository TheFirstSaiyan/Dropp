using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour {

	// Use this for initialization
	public int index;
	public void changeScene()
	{
	
		Application.LoadLevel (index);
	}
}
