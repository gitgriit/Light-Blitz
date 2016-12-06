using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {
	private DialogueManager dMan;
	public string[] dialogueLines;
	public GameObject dialogueArea;
	private bool playerInZone;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Player") {
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.name == "Player") {
			playerInZone = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.Space) && playerInZone) {
				if (!dMan.dialogueActive) {
					dMan.dialogueLines = dialogueLines;
					dMan.currentLine = 0;
					dialogueArea.SetActive (false);
					dMan.ShowDialogue ();
				}
			}
		}
	}
}
