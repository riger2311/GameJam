using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public void loadLevel(string levelToLoad){
		Debug.Log ("load");
		SceneManager.LoadScene (levelToLoad);
	}
}
