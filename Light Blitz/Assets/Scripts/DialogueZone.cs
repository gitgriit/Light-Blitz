using UnityEngine;
using System.Collections;

public class DialogueZone : MonoBehaviour {
	private DialogueManager dMan;
	public string[] dialogueLines;
	public GameObject dialogueArea;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			if (!dMan.dialogueActive) {
				dMan.dialogueLines = dialogueLines;
				dMan.currentLine = 0;
				dialogueArea.SetActive (false);
				dMan.ShowDialogue ();
			}
		}
	}
}
