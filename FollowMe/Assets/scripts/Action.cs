using UnityEngine;
using System.Collections;

[System.Serializable]

//Beware actionName must be the same as the name of the actionIcon file!
public class Action{

	public string actionName;
	public int actionID;
	public string actionDesc;
	public Texture2D actionIcon;
	public float funStat;
	public float fearStat;
	public float noMeatStat;


	public Action(string name, int id, string desc, float fun, float fear, float noMeat)
	{
       actionName = name;
       actionID = id;
       actionDesc = desc;
       actionIcon = Resources.Load<Texture2D>("action icons/" + name +"-01");
       funStat = fun;
       fearStat = fear;
       noMeatStat = noMeat;

	}

	public string funText(){
		if (funStat > 0) {
			return "+";
		} else if (funStat < 0) {
			return "-";
		} else {
			return "₀";
		}
	}
	public string fearText(){
		if (fearStat > 0) {
			return "+";
		} else if (fearStat < 0) {
			return "-";
		} else {
			return "₀";
		}
	}
	public string noMeatText(){
		if (noMeatStat > 0) {
			return "+";
		} else if (noMeatStat < 0) {
			return "-";
		} else {
			return "₀";
		}
	}

}
