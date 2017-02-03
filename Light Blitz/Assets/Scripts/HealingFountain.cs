using UnityEngine;
using System.Collections;

public class HealingFountain : MonoBehaviour {
	public int healthToGive;

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer(-healthToGive);
		} else {
			return;
		}
	}
}
