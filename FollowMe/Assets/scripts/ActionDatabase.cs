using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionDatabase : MonoBehaviour {

	public List<Action> actions = new List<Action>();
	public Texture2D icon1;
	public Texture2D icon2;
	public Texture2D icon3;
	public Texture2D icon4;
	public Texture2D icon5;
	public Texture2D icon6;
	public Texture2D icon7;

	void Start()
	{
	  //Beware actionName must be the same as the name of the actionIcon file!
	  //public Action(string name, int id, string desc, double fun, double fear, double noMeat)
	  actions.Add(new Action("fire",0,"this is a test", icon1,1.1f,2.1f,3.1f));
	  actions.Add(new Action("fire",0,"this is a test",icon2,1.1f,2.1f,3.1f));
	  actions.Add(new Action("fire",0,"this is a test",icon3,1.1f,2.1f,3.1f));
	  actions.Add(new Action("fire",0,"this is a test",icon4,1.1f,2.1f,3.1f));
	  actions.Add(new Action("fire",0,"this is a test",icon5,1.1f,2.1f,3.1f));
	  actions.Add(new Action("fire",0,"this is a test",icon6,1.1f,2.1f,3.1f));
	  actions.Add(new Action("fire",0,"this is a test",icon7,1.1f,2.1f,3.1f));
	}
}
