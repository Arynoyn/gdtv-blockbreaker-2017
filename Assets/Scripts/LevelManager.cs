using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
        Debug.Log(string.Format("Level load requested for: {0}", name));
        Brick.breakableCount = 0;
        Application.LoadLevel(name);
    }
    
    public void QuitRequest(){
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    
    public void BrickDestroyed(){
        if (Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }
}
