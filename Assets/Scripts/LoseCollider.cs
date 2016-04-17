using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    
    void Start(){
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    
    void OnTriggerEnter2D (Collider2D trigger){
        print("Trigger");
        levelManager.LoadLevel("Lose Screen");
    }
}
