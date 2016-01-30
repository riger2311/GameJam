using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RitualScript : MonoBehaviour {

	private List<GameObject> npcs;
	public GameObject npcPrefab;
	public WorshipIndicators bars;
	public int maxRounds;
	public ActionBar gui;
	public GameObject playerIndicator;

	private float affiliationPlayer1;
	private float affiliationPlayer2;

	private float playerModifier;

	private float repeatModifier1;
	private float repeatModifier2;
	private float repeatModifier3;
	private float repeatModifier4;
	private float repeatModifier5;
	private float repeatModifier6;

	private int roundsPlayed;


	// Use this for initialization
	void Start () {
		npcs = new List<GameObject>();

		for(int i = 0; i < 100; i++) {
			npcs.Add((GameObject) Instantiate(npcPrefab, new Vector3(0,0,0), Quaternion.identity));
		}

		affiliationPlayer1 = 0.0f;
		affiliationPlayer2 = 0.0f;
		playerModifier = 1.0f; //MUST be 1 or -1

		repeatModifier1 = 1.0f;
		repeatModifier2 = 1.0f;
		repeatModifier3 = 1.0f;
		repeatModifier4 = 1.0f;
		repeatModifier5 = 1.0f;
		repeatModifier6 = 1.0f;

		roundsPlayed = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		updateStatusBars();

		string playerText = playerModifier < 0 ? "Player 2" : "Player 1";
		playerIndicator.GetComponent<Text> ().text = playerText;

		if(roundsPlayed == (maxRounds * 2)) {
			string winText;
			if(affiliationPlayer1 > affiliationPlayer2) {
				winText = "Player 1 wins!";				
			} else if (affiliationPlayer1 < affiliationPlayer2) {
				winText = "Player 2 wins!";
			} else {
				winText = "Draw!";
			}

			gui.showWinText(winText);

		}
	
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

	void repeatedRitual(ref float repeatModifier) {
		if(repeatModifier > 0.25f){
			repeatModifier -= 0.25f;
			Debug.Log("Modifier at " + repeatModifier);			
		}
	}

	//----- Rituals ----- fun-fear-noMeat
	public void letBeerRain() {
		//fun++
		//fear--
		float funValue = playerModifier * repeatModifier1 * 3.0f;
		float fearValue = playerModifier * repeatModifier1 * -2.0f;
		float noMeatValue = playerModifier * 1.0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier1);
		roundsPlayed++;
	}

	public void slaughterLamb() {
		//noMeat--
		//fear++
		float funValue = playerModifier * 1.0f;
		float fearValue = playerModifier * repeatModifier2 * 3.0f;
		float noMeatValue = playerModifier * repeatModifier2 * -2.0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier2);
		roundsPlayed++;
	}

	public void drought() {
		//fear++
		//noMeat-
		float funValue = playerModifier * 1.0f;
		float fearValue = playerModifier * repeatModifier3 *2.5f;
		float noMeatValue = playerModifier * repeatModifier3 * -1.5f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier3);
		roundsPlayed++;
	}

	public void sacrificePeople() {
		//fear++
		//fun-
		float funValue = playerModifier * repeatModifier4 * -2.0f;
		float fearValue = playerModifier * repeatModifier4 * 3.0f;
		float noMeatValue = playerModifier * 1.0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier4);
		roundsPlayed++;
	}

	public void praiseTheSun() {
		//fun++
		//fear-
		float funValue = playerModifier * repeatModifier5 * 2.5f;
		float fearValue = playerModifier * repeatModifier5 * -1.5f;
		float noMeatValue = playerModifier * 1.0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier5);
		roundsPlayed++;
	}

	public void richHarvest() {
		//noMeat++
		//fear-
		float funValue = playerModifier * 1.0f;
		float fearValue = playerModifier * repeatModifier6 * -2.0f;
		float noMeatValue = playerModifier * repeatModifier6 * 3.0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier6);
		roundsPlayed++;
	}
}
