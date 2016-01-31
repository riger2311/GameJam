using UnityEngine;
using System.Collections;

public class NPCAttributes : MonoBehaviour {

	public float funAttribute;
	public float fearAttribute;
	public float noMeatAttribute;
	public float speed = 2.0f;
	public float affiliationThreshold;

	//should be between -1.0 and 1.0
	//-1.0 means, the npc belongs to player 1, 1.0 means to the other player
	public float affiliaton; 
	private bool actionTriggered;
	private float funValue;
	private float fearValue;
	private float noMeatValue;
	private float tmpy;


	// Use this for initialization
	void Start () {
		affiliaton = 0.0f;
		actionTriggered = false;

		Random.seed = Random.Range (0, 10000);
		funAttribute = Random.Range(0.0f, 1.0f);
		fearAttribute = Random.Range(0.0f, 1.0f);
		noMeatAttribute = Random.Range(0.0f, 1.0f);
		tmpy = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(actionTriggered) {
			actionTriggered = false;

			affiliaton = affiliaton +
			(funValue * funAttribute) +
			(fearValue * fearAttribute) +
			(noMeatValue * noMeatAttribute);
			if (affiliaton < -4f) {
				affiliaton = -4f;
			} else if (affiliaton > 4f) {
				affiliaton = 4f;
			}
			//this.transform.position = v;
			tmpy = Random.Range(-0.7f, 0.7f);
		} 
		float tmpAff = RitualScript.ConvertRange (-4f, 4f, -5.4f, 5.4f, affiliaton);
		Vector3 v = new Vector3(tmpAff, tmpy, this.transform.position.z);
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, v, step);
	
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
