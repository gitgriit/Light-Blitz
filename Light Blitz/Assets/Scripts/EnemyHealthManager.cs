using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {
	public int MaxHealth;
	public int CurrentHealth;
	public string enemyQuestName;
	private QuestManager theQm;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		theQm = FindObjectOfType<QuestManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			theQm.enemyKilled = enemyQuestName;
			gameObject.SetActive (false);
		}
	}

	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}
}
