using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {
	public float speed;
	public int damageNumber;
	public Text displayNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		displayNumber.text = "" + damageNumber;
		transform.position = new Vector3 (transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);

	
	}
}
