using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour {
	public string levelToLoad;
	public string exitPoint;
	private PlayerController thePlayer;

	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}

	void Update () {

	}

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
			yield return StartCoroutine (sf.FadeToBlack ());

			Debug.Log ("An object Collide");
			SceneManager.LoadScene (levelToLoad);
			thePlayer.startPoint = exitPoint;

			yield return StartCoroutine (sf.FadeToClear ());
		} 
	}
}
