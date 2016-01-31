using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ActionBar : MonoBehaviour {

    public List<Action> action_bar = new List<Action>();
    public GUISkin skin;
    public RitualScript ritualScript;
    public Button retryButton;
    public Button exitButton;
    public ActionDatabase database;
    private string tooltip;

    private bool showActionBar;
    private string winText;
	private bool gameFinished = false;

    

	// Use this for initialization
	void Start ()
	{
	gameFinished = false;
	showActionBar = true;
	database = GetComponent<ActionDatabase>();
	
	    for(int counter = 0; counter < database.actions.Count; counter++)
	    {
	    	action_bar.Add(database.actions[counter]);
	    }

  retryButton.gameObject.SetActive(false);
  exitButton.gameObject.SetActive(false);
	}
		
	void OnGUI ()
	{
      //set GUI skin and Background of inventory
	 GUI.skin = skin;
   if(showActionBar) {
    drawActionBar();
   }
   else {
    showWinningPlayer();
   } 
	}

  void drawActionBar(){
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


            tooltip = ""+action_bar[counter].actionName.ToUpper() +""+ "\n\n" +action_bar[counter].actionDesc+"\n\n";
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

				Rect fun_rect = new Rect(begin+tooltip_rect.width-30,(offset_height+height+tile_offset_height+10),10,10);
				GUI.Box(fun_rect,"",skin.GetStyle("FunColor"));
				string funtext = ""+action_bar[counter].funText();
				Rect funtext_rect = new Rect(begin+tooltip_rect.width-20, (offset_height+height+tile_offset_height+2),25,20);
				GUI.Label(funtext_rect,funtext);

				Rect fear_rect = new Rect(begin+tooltip_rect.width-50,(offset_height+height+tile_offset_height+10),10,10);
				GUI.Box(fear_rect,"",skin.GetStyle("FearColor"));
				string feartext = ""+action_bar[counter].fearText();
				Rect feartext_rect = new Rect(begin+tooltip_rect.width-40, (offset_height+height+tile_offset_height+2),25,20);
				GUI.Label(feartext_rect,feartext);

				Rect meat_rect = new Rect(begin+tooltip_rect.width-70,(offset_height+height+tile_offset_height+10),10,10);
				GUI.Box(meat_rect,"",skin.GetStyle("MeatColor"));
				string meattext = ""+action_bar[counter].noMeatText();
				Rect meattext_rect = new Rect(begin+tooltip_rect.width-60, (offset_height+height+tile_offset_height+2),25,30);
				GUI.Label(meattext_rect,meattext);

        //check if action is clicked on
        if(Event.current.isMouse && Event.current.type == EventType.mouseDown && Event.current.button == 0)
        {
          switch(counter) {
          case 0: ritualScript.letBeerRain(); break;
          case 1: ritualScript.sacrificePeople(); break;
          case 2: ritualScript.drought(); break;
          case 3: ritualScript.richHarvest(); break;
          case 4: ritualScript.slaughterLamb(); break;
          case 5: ritualScript.praiseTheSun(); break;
          default: break;
          }
       }
     }
    }
  }

  void showWinningPlayer() {
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            int startX = Screen.width / 4;
            int startY = Screen.height / 4;
            int width = 2 * startX;
            int height = startY;

            GUI.Box(new Rect(startX, startY, width, height),"",skin.GetStyle("ActionBack"));
            GUI.Label(new Rect(startX, startY, width, height), "<size=40>" + winText + "</size>");
            retryButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);

            }

  public void showWinText(string wintext) {
    winText = wintext;
    showActionBar = false;
	 gameFinished = true;
  }

}
