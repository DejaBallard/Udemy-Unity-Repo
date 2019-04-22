using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoplay = false;
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	// Update is called once per frame
	void Update () {
		if (!autoplay) {
			MoveWithMouse();
		}
		else {
			AutoPlayGame();
		
		}
	}
	void AutoPlayGame(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballpos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballpos.x,1.0F,15.0F);
		this.transform.position = paddlePos;
	}
	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,1.0F,15.0F);
		this.transform.position = paddlePos;
	
	}
}