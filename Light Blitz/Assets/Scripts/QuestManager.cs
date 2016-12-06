using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour {
	public QuestObject[] quests;
	public bool[] questCompleted;
	public DialogueManager theDm;
	public string enemyKilled;

	// Use this for initialization
	void Start () {
		questCompleted = new bool[quests.Length];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowQuestText(string questText){
		theDm.dialogueLines = new string[1];
		theDm.dialogueLines [0] = questText;
		theDm.currentLine = 0;
		theDm.ShowDialogue ();
	}
}
