using UnityEngine;
using System.Collections;

public class NPCAttributes : MonoBehaviour {

	public double funAttribute;
	public double fearAttribute;
	public double noMeatAttribute;

	public double affiliationThreshold;

	//should be between -1.0 and 1.0
	//-1.0 means, the npc belongs to player 1, 1.0 means to the other player
	private double affiliaton; 
	private bool actionTriggered;
	private double funValue;
	private double fearValue;
	private double noMeatValue;

	// Use this for initialization
	void Start () {
		affiliaton = 0.0;
		actionTriggered = false;

		funAttribute = Random.Range(1.0f, 1.5f);
		fearAttribute = Random.Range(1.0f, 1.5f);
		noMeatAttribute = Random.Range(1.0f, 1.5f);

		//Debug.Log("funAttribute: " + funAttribute);
		//Debug.Log("fearAttribute: " + fearAttribute);
		//Debug.Log("noMeatAttribute: " + noMeatAttribute);
	}
	
	// Update is called once per frame
	void Update () {
		if(actionTriggered) {
			actionTriggered = false;
			//TODO normalize!!!
			affiliaton = (funValue * funAttribute) + (fearValue * fearAttribute) + (noMeatValue * noMeatAttribute);
			Debug.Log("Affiliation is: " + affiliaton);
		} 
	
	}

	public void triggerAction(double funValueParam = 0.0, double fearValueParam = 0.0, double noMeatValueParam = 0.0) {
		actionTriggered = true;
		funValue = funValueParam;
		fearValue = fearValueParam;
		noMeatValue = noMeatValueParam;
	}

	public double getAffiliation() {
		return affiliaton;
	}

	//returns the number of the player this npc is currently affiliated to. 
	public int affiliatedToPlayer() {
		if(affiliaton < -0.25) {
			return 1;
		} else if (affiliaton > 0.25) {
			return 2;
		}
		else {
			return 0;
		}
	}

}
