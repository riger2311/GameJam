using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RitualScript : MonoBehaviour {

	private List<GameObject> npcs;
	public GameObject npcPrefab;

	public float affiliation;

	// Use this for initialization
	void Start () {
		npcs = new List<GameObject>();

		for(int i = 0; i < 50; i++) {
			npcs.Add((GameObject) Instantiate(npcPrefab, new Vector3(0,0,0), Quaternion.identity));
		}

		//Debug.Log("List contains " + npcs.Count + " elements.");
		affiliation = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
			//Debug.Log("NPC with attribute: " + npcs[0].GetComponent<NPCAttributes>().funAttribute + " " 
			//	+ npcs[0].GetComponent<NPCAttributes>().fearAttribute + " " 
			//	+ npcs[0].GetComponent<NPCAttributes>().noMeatAttribute);

		if(Input.GetKeyDown(KeyCode.Space)) {
			foreach (GameObject npc in npcs) 
			{
				npc.GetComponent<NPCAttributes>().triggerAction(5.0f, 2.0f, 1.0f);
			}
		}

		if(Input.GetKeyDown(KeyCode.B)) {
			foreach (GameObject npc in npcs) 
			{
				npc.GetComponent<NPCAttributes>().triggerAction(-5.0f, 2.0f, 1.0f);
			}
		}
		updateStatusBars();
	
	}

	void updateStatusBars() {
		//TODO change to percentage and influence buttons with them
		//float sumOfAffiliations = 0.0f;
		int player1 = 0;
		int player2 = 0;
		foreach (GameObject npc in npcs) 
		{
			if(npc.GetComponent<NPCAttributes>().affiliatedToPlayer() == 1) {
				player1++;
			}
			else if (npc.GetComponent<NPCAttributes>().affiliatedToPlayer() == 2) {
				player2++;
			}
		}
		//affiliation = sumOfAffiliations / npcs.Count;

		//Debug.Log("Summed Affiliation is: " + affiliation);
		Debug.Log("npcs for player1: " + player1);
		Debug.Log("npcs for player2: " + player2);

	}
}
