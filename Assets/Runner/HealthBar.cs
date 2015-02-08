using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public float maxhealth = 100;
	public float curhealth = 100;
	public int variable;
	public float healthbarlength;
	// Use this for initialization
	void Start () {
		healthbarlength=Screen.width/2;
	
	}
	
	// Update is called once per frame
	void Update () {
		Ajustcurrenthealth(0);
	
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, healthbarlength,20), curhealth + "/" + maxhealth);
	}
	
	public void Ajustcurrenthealth(int adj){
		curhealth-=Time.deltaTime*4;
		healthbarlength=(Screen.width/2)*(curhealth/(float)maxhealth);
		if(variable==1)
		{
			curhealth+=30;
			variable=0;
		}
		else if(variable==-1)
		{
			curhealth-=30;
			variable=0;
		}
		
		if(curhealth<0)
			curhealth=0;
		if(curhealth>maxhealth)
			curhealth=maxhealth;
}
}