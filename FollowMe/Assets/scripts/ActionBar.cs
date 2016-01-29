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


	}
	
	void OnGUI ()
	{
      //set GUI skin and Background of inventory
	 GUI.skin = skin;
	 int offset_width = Screen.width/15;
	 int offset_height = Screen.height/30;
	 float width = Screen.width - (offset_width*2);
	 float height = Screen.height/8;
     
     float tile_size = (int)height*0.8f;
     float tile_offset_height = (int)height*0.1f;
     GUI.Box(new Rect(offset_width,offset_height,width,height),"",skin.GetStyle("ActionBack"));
     

     float tile_offset_width = (width-(tile_size*action_bar.Count))/(action_bar.Count+1);
     float begin = offset_width+tile_offset_width;

     for(int counter = 0; counter < action_bar.Count; counter++)
     {
     	if(counter != 0)
     	{
     		begin += tile_size;
     		begin += tile_offset_width;
     	}
     	GUI.Box(new Rect(begin,offset_height+tile_offset_height,tile_size,tile_size),"",skin.GetStyle("Tile"));
        GUI.DrawTexture(new Rect(begin,offset_height+tile_offset_height,tile_size,tile_size),Resources.Load<Texture2D>("action icons/fire"));
     }
     
	}

}
