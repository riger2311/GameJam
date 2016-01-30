﻿using UnityEngine;
using System.Collections;

public class NPCAttributes : MonoBehaviour {

	public float funAttribute;
	public float fearAttribute;
	public float noMeatAttribute;

	public float affiliationThreshold;

	//should be between -1.0 and 1.0
	//-1.0 means, the npc belongs to player 1, 1.0 means to the other player
	private float affiliaton; 
	private bool actionTriggered;
	private float funValue;
	private float fearValue;
	private float noMeatValue;

	// Use this for initialization
	void Start () {
		affiliaton = 0.0f;
		actionTriggered = false;

		funAttribute = Random.Range(1.0f, 1.25f);
		fearAttribute = Random.Range(1.0f, 1.25f);
		noMeatAttribute = Random.Range(1.0f, 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if(actionTriggered) {
			actionTriggered = false;

			affiliaton = affiliaton + (((funValue * funAttribute) + 
				(fearValue * fearAttribute) + 
				(noMeatValue * noMeatAttribute)) % 1);
			
			if(affiliaton > 1.0f) {
				affiliaton = 1.0f;
			} else if (affiliaton < -1.0f) {
				affiliaton = -1.0f;
			}

		} 
	
	}

	public void triggerAction(float funValueParam = 0.0f, float fearValueParam = 0.0f, float noMeatValueParam = 0.0f) {
		actionTriggered = true;
		funValue = funValueParam;
		fearValue = fearValueParam;
		noMeatValue = noMeatValueParam;
	}

	public float getAffiliation() {
		return affiliaton;
	}

	//returns the number of the player this npc is currently affiliated to. 
	public int affiliatedToPlayer() {
		if(affiliaton < -affiliationThreshold) {
			return 1;
		} else if (affiliaton > affiliationThreshold) {
			return 2;
		}
		else {
			return 0;
		}
	}

}