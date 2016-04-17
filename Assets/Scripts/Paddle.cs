using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
    public float minX, maxX;
    
    private Ball ball;
    // Use this for initialization
	void Start () {
	    ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!autoPlay) {
             MoveWithMouse();
        } else {
            AutoPlay();
        }       
	}

    private void AutoPlay() {
        Vector3 ballPos = ball.transform.position;
        var paddlePos = new Vector3(Mathf.Clamp(ballPos.x, minX, maxX), this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse(){
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
        var paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, minX, maxX), this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePos;
    }
}
