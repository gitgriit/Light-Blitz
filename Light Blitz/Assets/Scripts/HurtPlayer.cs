using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HurtPlayer : MonoBehaviour {
	public int damageToGive;
	public GameObject damageNumber;
	public GameObject damageBurst;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer(damageToGive);
			Instantiate (damageBurst, other.transform.position, other.transform.rotation);
			var clone = (GameObject) Instantiate (damageNumber, other.transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}
