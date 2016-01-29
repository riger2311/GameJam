using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionBar : MonoBehaviour {

    public List<Action> action_bar = new List<Action>();
    //public GUISkin skin;

    private ActionDatabase database;

    

	// Use this for initialization
	void Start ()
	{
	  
	database = GetComponent<ActionDatabase>();
	
    for(int counter = 0; counter < database.actions.Count; counter++)
    {
      print("Curently "+database.actions[counter].actionName+" in databse");
    }
    /*for(int inventoryCounter = 0; inventoryCounter < database.items.Count; inventoryCounter++)
	{
	  inventory.Add(new Item());
	}*/

	}
	
	void OnGUI ()
	{
      //set GUI skin and Background of inventory
	  //GUI.skin = skin;    
	}

}
