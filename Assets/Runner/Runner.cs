using UnityEngine;

public class Runner : MonoBehaviour {
	private static float boosts;
	public static float distanceTraveled;
	GameObject[] gos;
	public int multiplier=2;
	public float acceleration;
	private System.Random rand = new System.Random();
	private bool touchingPlatform;
        public Vector3 jumpVelocity;
        public float gameOverY;
        private Vector3 startPosition;
		public int[] cube=new int[3];
	public int jumpflag=0;
	void Update () {
               foreach (Touch touch in Input.touches) {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled && jumpflag<3){
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
                        touchingPlatform = false;
				        jumpflag++;
			
		}
		}
	// 	distanceTraveled = 0f;
		
		distanceTraveled = transform.localPosition.x;
		GUIManager.SetDistance(distanceTraveled);
		                if(transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}

	void FixedUpdate () {
		if(touchingPlatform){
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}
        void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}

	private void GameStart () {
		boosts = 0;
		GUIManager.SetBoosts((int)boosts);
	for(int i=0;i<3;i++)
		{
			cube[i] = rand.Next(0, 3);
		}
		gos = GameObject.FindGameObjectsWithTag("box1");
		  foreach (GameObject go in gos) {
			if(cube[0]==0)
			go.renderer.material.color=Color.red;
			else if(cube[0]==1)
			go.renderer.material.color=Color.green;
			else if(cube[0]==2)
			go.renderer.material.color=Color.blue;
			else if(cube[0]==3)
			go.renderer.material.color=Color.cyan;
			}
		
		  gos = GameObject.FindGameObjectsWithTag("box2");
		  foreach (GameObject go in gos) {
			if(cube[1]==0)
			go.renderer.material.color=Color.red;
			else if(cube[1]==1)
			go.renderer.material.color=Color.green;
			else if(cube[1]==2)
			go.renderer.material.color=Color.blue;
			else if(cube[1]==3)
			go.renderer.material.color=Color.cyan;
			}
		
		
		gos = GameObject.FindGameObjectsWithTag("box3");
		  foreach (GameObject go in gos) {
			if(cube[2]==0)
			go.renderer.material.color=Color.red;
			else if(cube[2]==1)
			go.renderer.material.color=Color.green;
			else if(cube[2]==2)
			go.renderer.material.color=Color.blue;
			else if(cube[2]==3)
			go.renderer.material.color=Color.cyan;
			}
		
		
		
		distanceTraveled = 0f;
		GUIManager.SetDistance(distanceTraveled);
		transform.localPosition = startPosition;
		renderer.enabled = true;
		
		rigidbody.isKinematic = false;
		enabled = true;
	}
	
	public static void AddBoost(){
		boosts += 1000;
		GUIManager.SetBoosts((int)boosts);
	}
	
	private void GameOver () {
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}

	void OnCollisionEnter (Collision col) {
		//print (cube[0]);
		//print (cube[1]);
		//print (cube[2]);
		if(col.gameObject.tag == "Player")
		{
		if(col.gameObject.renderer.material.color==Color.red && cube[0]==0 )
		{
				print ("LANDED ON RED");
				cube[0]=cube[1];
				cube[1]=cube[2];
				cube[2]= Random.Range(0, 3);
			distanceTraveled = transform.localPosition.x;
				boosts = boosts + 1000 + transform.localPosition.x;
		GUIManager.SetBoosts((int)boosts);
				GUIManager.SetDistance(distanceTraveled); 

		}
			else
		if(col.gameObject.renderer.material.color==Color.green && cube[0]==1 )
		{
				print ("LANDED ON GREEN");
				cube[0]=cube[1];
				cube[1]=cube[2];
				cube[2]= Random.Range(0, 3);

			distanceTraveled = transform.localPosition.x;	
				boosts = boosts + 1000+  transform.localPosition.x;
		GUIManager.SetBoosts((int)boosts);
				GUIManager.SetDistance(distanceTraveled);
		}else
		if(col.gameObject.renderer.material.color==Color.blue && cube[0]==2 )
		{
				print ("LANDED ON BLUE");
				cube[0]=cube[1];
				cube[1]=cube[2];
				cube[2]= Random.Range(0, 3);
			distanceTraveled = transform.localPosition.x;
				boosts = boosts + 1000  + transform.localPosition.x;
		GUIManager.SetBoosts((int)boosts);
				GUIManager.SetDistance(distanceTraveled);
		}else
		if(col.gameObject.renderer.material.color==Color.cyan && cube[0]==3 )
		{
				print ("LANDED ON cyan");
				cube[0]=cube[1];
				cube[1]=cube[2];
				cube[2]= Random.Range(0, 3);
			distanceTraveled = transform.localPosition.x;
				boosts = boosts + 1000  + transform.localPosition.x;
		GUIManager.SetBoosts((int)boosts);
				GUIManager.SetDistance(distanceTraveled);
		}else
		multiplier/=2;		
		GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("box1");
		  foreach (GameObject go in gos) {
			if(cube[0]==0)
			go.renderer.material.color=Color.red;
			else if(cube[0]==1)
			go.renderer.material.color=Color.green;
			else if(cube[0]==2)
			go.renderer.material.color=Color.blue;
			else if(cube[0]==3)
			go.renderer.material.color=Color.cyan;
			}
		
		gos = GameObject.FindGameObjectsWithTag("box2");
		  foreach (GameObject go in gos) {
			if(cube[1]==0)
			go.renderer.material.color=Color.red;
			else if(cube[1]==1)
			go.renderer.material.color=Color.green;
			else if(cube[1]==2)
			go.renderer.material.color=Color.blue;
			else if(cube[1]==3)
			go.renderer.material.color=Color.cyan;
			}
		
		
		gos = GameObject.FindGameObjectsWithTag("box3");
		  foreach (GameObject go in gos) {
			if(cube[2]==0)
			go.renderer.material.color=Color.red;
			else if(cube[2]==1)
			go.renderer.material.color=Color.green;
			else if(cube[2]==2)
			go.renderer.material.color=Color.blue;
			else if(cube[2]==3)
			go.renderer.material.color=Color.cyan;
			}
	}
		touchingPlatform = true;
	}

	void OnCollisionExit () {
		jumpflag=0;
		touchingPlatform = false;
	}
}