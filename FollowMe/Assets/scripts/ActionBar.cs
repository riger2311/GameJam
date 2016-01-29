using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionBar : MonoBehaviour {

    public List<Action> action_bar = new List<Action>();
    public GUISkin skin;
    private ActionDatabase database;

    

	// Use this for initialization
	void Start ()
	{
	  
	database = GetComponent<ActionDatabase>();
	
    for(int counter = 0; counter < database.actions.Count; counter++)
    {
    	action_bar.Add(database.actions[counter]);
    }
    for(int inventoryCounter = 0; inventoryCounter < action_bar.Count; inventoryCounter++)
	{
	  print("Currently "+action_bar[inventoryCounter].actionName+" in databse");
	}


	}
	
	void OnGUI ()
	{
      //set GUI skin and Background of inventory
	 GUI.skin = skin;
     GUI.Box(new Rect(0,0,100,100),"",skin.GetStyle("ActionBack"));
    // GUI.DrawTexture(paper_count_icon_rect,Resources.Load<Texture2D>("inventory icons/paper"));
    //for(int i = 0; i < inventory.Count; i++)
    //{
     // tooltip = "<b>"+inventory[i].itemName +"</b>"+ "\n\n" +inventory[i].itemDesc+"\n\n"/*+ "<b><color=#ffd700>\t\t\t"+inventory[y].itemCost+" Paper"+"</color></b>"*/;
     // Rect labelRect = GUILayoutUtility.GetRect(new GUIContent(tooltip),skin.GetStyle("Slot"));
    //  if(labelRect.width > tooltip_rect.width)
     // {
     //   tooltip_rect.width = labelRect.width;
     // }
    //}
		//GUI.Box(inventory_background_rect,"",skin.GetStyle("Back"));
    
    //GUI.Box(paper_count_rect,"",skin.GetStyle("Back"));
    //GUI.DrawTexture(paper_count_icon_rect,Resources.Load<Texture2D>("inventory icons/paper"));    
	}

}
