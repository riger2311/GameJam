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


	public Action(string name, int id, string desc, Texture2D icon, float fun, float fear, float noMeat)
	{
       actionName = name;
       actionID = id;
       actionDesc = desc;
       actionIcon = icon;
       funStat = fun;
       fearStat = fear;
       noMeatStat = noMeat;

	}

}
