using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionBar : MonoBehaviour {

    public List<Action> action_bar = new List<Action>();
    public GUISkin skin;
    public RitualScript ritualScript;
    private ActionDatabase database;
    string tooltip;

    

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
        Rect action_Rect = new Rect(begin,offset_height+tile_offset_height,tile_size,tile_size);
     	GUI.Box(action_Rect,"",skin.GetStyle("Tile"));
        GUI.DrawTexture(action_Rect,action_bar[counter].actionIcon);
      
      //check if mouse is hovering over action
       if(action_Rect.Contains(Event.current.mousePosition))
       {


            tooltip = "<color=#000000><b>"+action_bar[counter].actionName.ToUpper() +"</b>"+ "\n\n" +action_bar[counter].actionDesc+"\n\n</color>";
            Rect labelRect = GUILayoutUtility.GetRect(new GUIContent(tooltip),skin.GetStyle("ActionBack"));
            Rect tooltip_rect = new Rect(begin,(offset_height+height+tile_offset_height),30,30);
            if(tooltip_rect.width < labelRect.width)
            {
                tooltip_rect.width = labelRect.width+(2*(tile_offset_height));
            }
            if(tooltip_rect.height < labelRect.height)
            {
                tooltip_rect.height = labelRect.height;
            }
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            Rect text_rect = new Rect(tooltip_rect.x+tile_offset_height, tooltip_rect.y+tile_offset_height,tooltip_rect.width,tooltip_rect.height);
            GUI.Box(tooltip_rect,"",skin.GetStyle("ActionBack"));
            GUI.Label(text_rect,tooltip);

        //check if action is clicked on
        if(Event.current.isMouse && Event.current.type == EventType.mouseDown && Event.current.button == 0)
        {
          switch(counter) {
          case 0: ritualScript.letBeerRain(); break;
          case 1: ritualScript.slaughterLamb(); break;
          case 2: ritualScript.drought(); break;
          case 3: ritualScript.sacrificePeople(); break;
          case 4: ritualScript.praiseTheSun(); break;
          case 5: ritualScript.richHarvest(); break;
          default: break;
          }
       }
     }
    } 
	}

}
