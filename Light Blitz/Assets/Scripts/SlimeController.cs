using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {
	public float moveSpeed;
	private Rigidbody2D myRigidBody;
	private bool isMoving;
	public float walkTime;
	private float walkTimeCounter;
	public float waitTime;
	private float waitTimeCounter;
	private int walkDirection;
	public Collider2D walkZone;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool hasWalkZone = false;
	public Transform target;
	public float speed;
	public float minDistance;
	private float range;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		waitTimeCounter = waitTime;
		walkTimeCounter = walkTime;

		ChooseDirection ();

		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}

		target = FindObjectOfType<PlayerController> ().transform;

		Rest ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToPlayer() {
		range = Vector2.Distance (transform.position, target.position);
		float movementDistance = speed * Time.deltaTime;

		if (range > minDistance) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, movementDistance);
		}
	}
		
	public void Rest ()
	{
		if (isMoving) {
			walkTimeCounter -= Time.deltaTime;

			switch (walkDirection) {
			case 0: 
				myRigidBody.velocity = new Vector2 (0, moveSpeed);
				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;

			case 1: 
				myRigidBody.velocity = new Vector2 (moveSpeed, 0);
				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;

			case 2: 
				myRigidBody.velocity = new Vector2 (0, -moveSpeed);
				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;

			case 3: 
				myRigidBody.velocity = new Vector2 (-moveSpeed, 0);
				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;
			}


			if (walkTimeCounter < 0) {
				isMoving = false;
				waitTimeCounter = waitTime;
			}


		} else {
			waitTimeCounter -= Time.deltaTime;

			myRigidBody.velocity = Vector2.zero;

			if (waitTimeCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection(){
		walkDirection = Random.Range (0, 4);
		isMoving = true;
		walkTimeCounter = walkTime;
	}

}
