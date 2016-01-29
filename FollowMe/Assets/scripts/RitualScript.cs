using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RitualScript : MonoBehaviour {

	private List<GameObject> npcs;
	public GameObject npcPrefab;

	// Use this for initialization
	void Start () {
		npcs = new List<GameObject>();

		for(int i = 0; i < 3; i++) {
			npcs.Add((GameObject) Instantiate(npcPrefab, new Vector3(0,0,0), Quaternion.identity));
		}

		Debug.Log("List contains " + npcs.Count + " elements.");
	
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
	
	}
}
