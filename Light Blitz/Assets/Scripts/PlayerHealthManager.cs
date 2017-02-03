using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {
	public int playerMaxHealth;
	public int playerCurrentHealth;
	private Animator anim;
	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
		anim = GetComponent<Animator> ();
		thePlayer = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			anim.SetBool("death", true);
			thePlayer.moveSpeed = 0f;
			playerCurrentHealth = 0;
		}

		if (playerCurrentHealth > playerMaxHealth) {
			playerCurrentHealth = playerMaxHealth;
		}
	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}
}
