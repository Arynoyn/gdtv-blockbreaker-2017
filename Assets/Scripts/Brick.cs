using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    public AudioClip crackSound;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;
    
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    
	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }
	    timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();


	}
	
    void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(crackSound, transform.position, 0.1f);
        if (isBreakable) {
            HandleHits();  
        }              
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);            
        } else {
            LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites(){
        int spriteIndex = timesHit - 1;
        
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Brick sprite missing!!");
        }
    }

    //TODO: Remove this function once we can win the game
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }



    // Update is called once per frame
    void Update () {
	    
	}
}
