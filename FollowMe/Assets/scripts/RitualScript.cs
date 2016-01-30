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
	public GameObject roundIndicator;

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
		int people = 50;
		int rows = 3;
		float x = -7.0f;
		float y = -1.5f;
		float offset = -0.2f;

		for(int i = 0; i < people; i++) {
			//lower x= -7.0
			//upper x= 4.0
 
			npcs.Add((GameObject) Instantiate(npcPrefab, new Vector3(x, y,0.0f), Quaternion.identity));
			x +=  (11.0f * ((float) rows) / ((float) people));
			if(x > 4.0f) {
				x = -7.0f + offset;
				y -= 0.3f * ((float) rows);
				offset += 0.4f;
			}
		}

		affiliationPlayer1 = 0.0f;
		affiliationPlayer2 = 0.0f;
		playerModifier = -1.0f; //MUST be 1 or -1

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

		if (roundsPlayed == (maxRounds * 2)) {
			string winText;
			if (affiliationPlayer1 > affiliationPlayer2) {
				winText = "Player 1 wins!";				
			} else if (affiliationPlayer1 < affiliationPlayer2) {
				winText = "Player 2 wins!";
			} else {
				winText = "Draw!";
			}

			gui.showWinText (winText);

			playerIndicator.GetComponent<Text> ().text = "";
			roundIndicator.GetComponent<Text> ().text = "";

		} else {
			string playerText = playerModifier < 0 ? "Player 2" : "Player 1";
			playerIndicator.GetComponent<Text> ().text = playerText;

			string roundText = "Round " + (roundsPlayed / 2 + 1);
			roundIndicator.GetComponent<Text> ().text = roundText;
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

//		Debug.Log("percentage for player1: " + affiliationPlayer1);
//		Debug.Log("percentage for player2: " + affiliationPlayer2);
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
		float funValue = playerModifier * repeatModifier1 * 1.6f;
		float fearValue = playerModifier * repeatModifier1 * -1.2f;
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
		float fearValue = playerModifier * repeatModifier2 * 1.6f;
		float noMeatValue = playerModifier * repeatModifier2 * -1.2f;
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
		float fearValue = playerModifier * repeatModifier3 *1.6f;
		float noMeatValue = playerModifier * repeatModifier3 * -1.2f;
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
		float funValue = playerModifier * repeatModifier4 * -1.2f;
		float fearValue = playerModifier * repeatModifier4 * 1.6f;
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
		float funValue = playerModifier * repeatModifier5 * 1.4f;
		float fearValue = playerModifier * repeatModifier5 * -1.3f;
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
		float fearValue = playerModifier * repeatModifier6 * -1.3f;
		float noMeatValue = playerModifier * repeatModifier6 * 1.6f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}
		playerModifier *= -1.0f;
		repeatedRitual(ref repeatModifier6);
		roundsPlayed++;
	}
}
