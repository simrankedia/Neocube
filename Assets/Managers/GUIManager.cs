using UnityEngine;
using System.Collections;
public class GUIManager : MonoBehaviour {
	
 
	//public int multiplier;
	public int x;
	private static GUIManager instance;
	public GameObject go;
	public int numVal;
    
	public GUIText boostsText,gameOverText, instructionsText, runnerText,distanceText,Pattern,a;
		void Start () {

		instance = this;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
	//	distanceText.enabled=false;
		
	}
	private void GameStart () {
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		runnerText.enabled = false;
		enabled = false;
	//	distanceText.enabled=true;
	}
		
	private void GameOver () {
		gameOverText.enabled = true;
		instructionsText.enabled = true;
		enabled=true;
		//int.TryParse(distanceText,out numVal);
		//numVal=numVal*go.GetComponent<Runner>().multiplier;
		//print (numVal);
		//distanceText.guiText=numVal.ToString();
      //  distanceText.enabled=true;  
	}
	
	void Update () {
        foreach (Touch touch in Input.touches) {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
              GameEventManager.TriggerGameStart();
        }
    }
	
	public static void SetBoosts(int boosts){
		instance.boostsText.text = boosts.ToString();
	}


	public static void SetDistance(float distance){
		instance.distanceText.text = distance.ToString("f0");
	}
}
