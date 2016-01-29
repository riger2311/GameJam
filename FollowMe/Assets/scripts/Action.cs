using UnityEngine;
using System.Collections;

[System.Serializable]

//Beware actionName must be the same as the name of the actionIcon file!
public class Action{

	public string actionName;
	public int actionID;
	public string actionDesc;
	public Texture2D actionIcon;
	public double funStat;
	public double fearStat;
	public double noMeatStat;


	public Action(string name, int id, string desc, double fun, double fear, double noMeat)
	{
       actionName = name;
       actionID = id;
       actionDesc = desc;
       actionIcon = Resources.Load<Texture2D>("action icons/" + name);
       funStat = fun;
       fearStat = fear;
       noMeatStat = noMeat;

	}

}
