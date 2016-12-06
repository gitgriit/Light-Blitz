using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	private Camera myCam;
	public float m_speed = 0.1f;
	private static bool cameraExist;

	// Use this for initialization
	void Start () {
		myCam = GetComponent<Camera> ();

		if (!cameraExist) {
			cameraExist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		myCam.orthographicSize = (Screen.height / 100f) / 4f;

		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, m_speed) + new Vector3(0, 0, -10);
		}
	}
}
