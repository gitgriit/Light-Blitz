using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {
	public int questNumber;
	public QuestManager theQm;
	public string startText;
	public string endText;
	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyKillCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnemyQuest) {
			if (theQm.enemyKilled == targetEnemy) {
				theQm.enemyKilled = null;
				enemyKillCount++;
			}

			if(enemyKillCount >= enemiesToKill) {
				EndQuest ();
			}
		}
	}

	public void StartQuest() {
		theQm.ShowQuestText (startText);

	}

	public void EndQuest() {
		theQm.ShowQuestText (endText);
		theQm.questCompleted [questNumber] = true;
		gameObject.SetActive (false);
	}
}
