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
	public GameObject playerA;
	public GameObject playerB;
	public Animator playerAAnimator;
	public Animator playerBAnimator;
	public AudioSource audioSource;
	public AudioClip beer;
	public AudioClip fire;
	public AudioClip dust;
	public AudioClip harvest;
	public AudioClip slaughter;
	public AudioClip sun;


	public float avgAffiliaton;
	public float minAffiliaton;
	public float maxAffiliaton;

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
		float x = -0f;
		float y = 0.0f;

		for(int i = 0; i < people; i++) {
			//lower x= -7.0
			//upper x= 4.0
 
			float tmpx = x + Random.Range(-3f, 3f);
			float tmpy = y + Random.Range(-0.7f, 0.7f);
			npcs.Add((GameObject) Instantiate(npcPrefab, new Vector3(tmpx, tmpy,-1f), Quaternion.identity));
//			x +=  (11.0f * ((float) rows) / ((float) people));
//			if(x > 4.0f) {
//				//
//				x = -7.0f + offset;
//				y -= 0.3f * ((float) rows);
//				offset += 0.4f;
//			}
		}

//		affiliationPlayer1 = 0.0f;
//		affiliationPlayer2 = 0.0f;
		playerModifier = -1.0f; //MUST be 1 or -1

		repeatModifier1 = 1.0f;
		repeatModifier2 = 1.0f;
		repeatModifier3 = 1.0f;
		repeatModifier4 = 1.0f;
		repeatModifier5 = 1.0f;
		repeatModifier6 = 1.0f;

		roundsPlayed = 0;
	
		playerAAnimator = playerA.GetComponent<Animator> ();
		playerBAnimator = playerB.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateStatusBars();

		if (roundsPlayed == (maxRounds * 2)) {
			string winText;
			if (avgAffiliaton < 0f) {
				winText = "Player 1 wins!";				
			} else if (avgAffiliaton > 0f) {
				winText = "Player 2 wins!";
			} else {
				winText = "Draw!";
			}

			gui.showWinText (winText);

			playerIndicator.GetComponent<Text> ().text = "";
			roundIndicator.GetComponent<Text> ().text = "";

		} else {
			string playerText = playerModifier < 0 ? "Player 1" : "Player 2";
			playerIndicator.GetComponent<Text> ().text = playerText;

			string roundText = "Round " + (roundsPlayed / 2 + 1);
			roundIndicator.GetComponent<Text> ().text = roundText;
		}
	
	}

	void updateStatusBars() {
		//		int player1 = 0;
		//int player2 = 0;
		//foreach (GameObject npc in npcs) 
		//{
		//	if(npc.GetComponent<NPCAttributes>().affiliatedToPlayer() == 1) {
		//		player1++;
		//	}
		//	else if (npc.GetComponent<NPCAttributes>().affiliatedToPlayer() == 2) {
		//		player2++;
		//	}
		//}

		//affiliationPlayer1 = (float)player1 / (float)npcs.Count;
		//affiliationPlayer2 = (float)player2 / (float)npcs.Count;

		//bars.givePointsToA(affiliationPlayer1);
		//bars.givePointsToB(affiliationPlayer2);

		averageNPCAffiliation ();
		float mapped = ConvertRange (-4f, 4f, 0f, 1f, avgAffiliaton);
		bars.setTo (mapped);
//		Debug.Log("percentage for player1: " + affiliationPlayer1);
//		Debug.Log("percentage for player2: " + affiliationPlayer2);
	}

	/*
	public static float ConvertRange(
		float originalStart, float originalEnd,
		float newStart, float newEnd,
		float value)
	{

		float originalDiff = originalEnd - originalStart;
		float newDiff = newEnd - newStart;
		float ratio = newDiff / originalDiff;
		float newProduct = (value - originalStart) * ratio;
		float finalValue = newProduct + newStart;
		return finalValue; 
	}*/
	public static float ConvertRange(
		float a, float b,
		float c, float d,
		float x)
	{
		return (x-a)/(b-a) * (d-c) + c; 
	}

	void averageNPCAffiliation(){
		float avg = 0;
		float min = 0;
		float max = 0;
		foreach(GameObject npc in npcs) {
			float aff = npc.GetComponent<NPCAttributes> ().affiliaton;
			avg += aff;
			if (aff < min) {
				min = aff;
			} else if (aff > max) {
				max = aff;
			}
		}
		avg = avg / npcs.Count;
		avgAffiliaton = avg;
		minAffiliaton = min;
		maxAffiliaton = max;
	}

	void repeatedRitual(ref float repeatModifier) {
		if(repeatModifier > 0.25f){
			repeatModifier -= 0.25f;
			Debug.Log("Modifier at " + repeatModifier);			
		}
	}

	void playAnimation(){
		if (playerModifier < 0) {
			playerAAnimator.Play ("action", -1, 0.0f);
		} else {
			playerBAnimator.Play ("action", -1, 0.0f);
		}
	}

	//----- Rituals ----- fun-fear-noMeat
	public void letBeerRain() {
		//fun++
		//fear--
		float funValue = playerModifier * repeatModifier1 * 1.8f; // between -2,-1 and 1,2
		float fearValue = playerModifier * repeatModifier1 * -1.2f; // between -2,-1 and 1,2
		float noMeatValue = playerModifier * 0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}

		repeatedRitual(ref repeatModifier1);
		roundsPlayed++;
		playAnimation ();
		playerModifier *= -1.0f;
		audioSource.clip = beer;
		audioSource.Play ();
	}
		
	public void slaughterLamb() {
		//noMeat--
		//fear++
		float funValue = playerModifier * 0f;
		float fearValue = playerModifier * repeatModifier2 * 1.2f; // between -2,-1 and 1,2
		float noMeatValue = playerModifier * repeatModifier2 * -1.8f; // between -2,-1 and 1,2
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}

		repeatedRitual(ref repeatModifier2);
		roundsPlayed++;
		playAnimation ();
		playerModifier *= -1.0f;
		audioSource.clip = slaughter;
		audioSource.Play ();

	}

	public void drought() {
		//fear++
		//noMeat-
		float funValue = playerModifier * 0f;
		float fearValue = playerModifier * repeatModifier3 *1.6f; // between -2,-1 and 1,2
		float noMeatValue = playerModifier * repeatModifier3 * -1.1f; // between -2,-1 and 1,2
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}

		repeatedRitual(ref repeatModifier3);
		roundsPlayed++;
		playAnimation ();
		playerModifier *= -1.0f;
		audioSource.clip = dust;
		audioSource.Play ();

	}

	public void sacrificePeople() {
		//fear++
		//fun-
		float funValue = playerModifier * repeatModifier4 * -1.2f; // between -2,-1 and 1,2
		float fearValue = playerModifier * repeatModifier4 * 1.5f; // between -2,-1 and 1,2
		float noMeatValue = playerModifier * 0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}

		repeatedRitual(ref repeatModifier4);
		roundsPlayed++;
		playAnimation ();
		playerModifier *= -1.0f;
		audioSource.clip = fire;
		audioSource.Play ();
	}

	public void praiseTheSun() {
		//fun++
		//fear-
		float funValue = playerModifier * repeatModifier5 * 1.9f; // between -2,-1 and 1,2
		float fearValue = playerModifier * repeatModifier5 * -1.2f; // between -2,-1 and 1,2
		float noMeatValue = playerModifier * 0f;
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}

		repeatedRitual(ref repeatModifier5);
		roundsPlayed++;
		playAnimation ();
		playerModifier *= -1.0f;
		audioSource.clip = sun;
		audioSource.Play ();

	}

	public void richHarvest() {
		//noMeat++
		//fear-
		float funValue = playerModifier * 0f;
		float fearValue = playerModifier * repeatModifier6 * -1.3f; // between -2,-1 and 1,2
		float noMeatValue = playerModifier * repeatModifier6 * 1.8f; // between -2,-1 and 1,2
		foreach (GameObject npc in npcs) 
		{		
			npc.GetComponent<NPCAttributes>().triggerAction(funValue, fearValue, noMeatValue);
		}

		repeatedRitual(ref repeatModifier6);
		roundsPlayed++;
		playAnimation ();
		playerModifier *= -1.0f;
		audioSource.clip = harvest;
		audioSource.Play ();

	}
}
