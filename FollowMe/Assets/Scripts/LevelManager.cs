using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public void loadLevel(string levelToLoad){
		Application.LoadLevel (levelToLoad);
	}
}
