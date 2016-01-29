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
			//Debug.Log("NPC with attribute: " + npcs[i].GetComponent<NPCAttributes>().funAttribute + " " 
			//	+ npcs[i].GetComponent<NPCAttributes>().fearAttribute + " " 
			//	+ npcs[i].GetComponent<NPCAttributes>().noMeatAttribute);
		}

		Debug.Log("List contains " + npcs.Count + " elements.");
	
	}
	
	// Update is called once per frame
	void Update () {
			//Debug.Log("NPC with attribute: " + npcs[0].GetComponent<NPCAttributes>().funAttribute + " " 
			//	+ npcs[0].GetComponent<NPCAttributes>().fearAttribute + " " 
			//	+ npcs[0].GetComponent<NPCAttributes>().noMeatAttribute);
	
	}
}
