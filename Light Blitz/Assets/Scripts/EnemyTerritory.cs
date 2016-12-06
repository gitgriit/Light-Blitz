using UnityEngine;
using System.Collections;

public class EnemyTerritory : MonoBehaviour {
	public BoxCollider2D territory;
	private GameObject thePlayer;
	private bool playerInSight;
	public GameObject enemy;
	private SlimeController theSlime;
	private PlayerHealthManager myHealth;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("Player");
		theSlime = enemy.GetComponent<SlimeController>();
		myHealth = thePlayer.GetComponent<PlayerHealthManager> ();
		playerInSight = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInSight == true)
		{
			theSlime.MoveToPlayer();

			if (myHealth.playerCurrentHealth <= 0){
				playerInSight = false;
			}
		}

		if (playerInSight == false)
		{
			theSlime.Rest();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == thePlayer)
		{
			playerInSight = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject == thePlayer) 
		{
			playerInSight = false;
		}
	}
}
