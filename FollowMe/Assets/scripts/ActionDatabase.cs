using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionDatabase : MonoBehaviour {

	public List<Action> actions = new List<Action>();

	void Start()
	{
	  //Beware actionName must be the same as the name of the actionIcon file!
	  //public Action(string name, int id, string desc, double fun, double fear, double noMeat)
	  actions.Add(new Action("beer",0,"Make people drunk and gain their trust",1.1f,2.1f,3.1f));
	  actions.Add(new Action("burningman",1,"Burn a witch and let satanists cheer",1.1f,2.1f,3.1f));
	  actions.Add(new Action("dust",2,"Cast a drought and be delighted by their fear",1.1f,2.1f,3.1f));
	  actions.Add(new Action("harvest",3,"Be good and don't let them starve ",1.1f,2.1f,3.1f));
	  actions.Add(new Action("pig",4,"Slaughter a pig",1.1f,2.1f,3.1f));
	  actions.Add(new Action("sun",5,"Let the sun shine",1.1f,2.1f,3.1f));
	  actions.Add(new Action("thunder",6,"Cast a mighty thunder",1.1f,2.1f,3.1f));
	}
}
