using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string startLevel;

    public void Play()
    {
        Application.LoadLevel(startLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
	
}
