using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RitualScript : MonoBehaviour {

	private List<GameObject> npcs;
	public GameObject npcPrefab;
	public WorshipIndicators bars;

	private float affiliationPlayer1;
	private float affiliationPlayer2;

	// Use this for initialization
	void Start () {
		npcs = new List<GameObject>();

		for(int i = 0; i < 100; i++) {
			npcs.Add((GameObject) Instantiate(npcPrefab, new Vector3(0,0,0), Quaternion.identity));
		}

		affiliationPlayer1 = 0.0f;
		affiliationPlayer2 = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

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

		affiliationPlayer1 = (float)player1 / (float)npcs.Count;
		affiliationPlayer2 = (float)player2 / (float)npcs.Count;

		bars.givePointsToA(affiliationPlayer1);
		bars.givePointsToB(affiliationPlayer2);

		//Debug.Log("percentage for player1: " + affiliationPlayer1);
		//Debug.Log("percentage for player2: " + affiliationPlayer2);

	}
}
