﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionDatabase : MonoBehaviour {

	public List<Action> actions = new List<Action>();

	void Start()
	{
	  //Beware actionName must be the same as the name of the actionIcon file!
	  //public Action(string name, int id, string desc, double fun, double fear, double noMeat)
	  actions.Add(new Action("fire",0,"this is a test",1.1,2.1,3.1));
	  print("added new element to action database");
	}
}
