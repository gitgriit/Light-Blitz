using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rBody;
	private Animator anim;
	public float moveSpeed;
	public Vector2 lastMove;
	private bool playerMoving;
	private bool attacking;
	public float attackTime;
	public float magicAttackTime;
	private float attackTimeCounter;
	private float earthAttackTimeCounter;
	private float airAttackTimeCounter;
	private float fireAttackTimeCounter;
	private bool cooldown = false;
	public GameObject Firemagic;
	public GameObject Earthmagic;
	public GameObject Airmagic;
	private static bool playerExist;
	public string startPoint;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	public bool canMove;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		if (!playerExist) {
			playerExist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove) {
			rBody.velocity = Vector2.zero;
			return;
		}

		if (!attacking) {
			playerMoving = false;

			if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				rBody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * currentMoveSpeed, rBody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			{
				rBody.velocity = new Vector2 (rBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				rBody.velocity = new Vector2 (0f, rBody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				rBody.velocity = new Vector2 (rBody.velocity.x, 0f);
			}

			if (Input.GetKeyDown (KeyCode.K)) {
				attackTimeCounter = attackTime; 
				attacking = true;
				rBody.velocity = Vector2.zero;
				anim.SetBool ("swordAttack", true);
			}

			if (Input.GetKeyDown (KeyCode.J) && cooldown == false) {
				cooldown = true;
				StartCoroutine ("Cooldown");
				fireAttackTimeCounter = magicAttackTime; 
				attacking = true;
				rBody.velocity = Vector2.zero;
				anim.SetBool ("fireMagicAttack", true);
				Firemagic.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.H) && cooldown == false) {
				cooldown = true;
				StartCoroutine ("Cooldown");
				earthAttackTimeCounter = magicAttackTime; 
				attacking = true;
				rBody.velocity = Vector2.zero;
				anim.SetBool ("earthMagicAttack", true);
				Earthmagic.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.G) && cooldown == false) {
				cooldown = true;
				StartCoroutine ("Cooldown");
				airAttackTimeCounter = magicAttackTime; 
				attacking = true;
				rBody.velocity = Vector2.zero;
				anim.SetBool ("windMagicAttack", true);
				Airmagic.SetActive (true);
			}

			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;	
			} else {
				currentMoveSpeed = moveSpeed;
			}
		}		

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
			rBody.velocity = Vector2.zero;
		}

		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("swordAttack", false);	
		}

		if (fireAttackTimeCounter > 0) {
			fireAttackTimeCounter -= Time.deltaTime;
			rBody.velocity = Vector2.zero;
		}

		if (fireAttackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("attack", false);	
			anim.SetBool ("fireMagicAttack", false);
			Firemagic.SetActive (false);
		}


		if (earthAttackTimeCounter > 0) {
			earthAttackTimeCounter -= Time.deltaTime;
			rBody.velocity = Vector2.zero;
		}

		if (earthAttackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("attack", false);	
			anim.SetBool ("earthMagicAttack", false);
			Earthmagic.SetActive (false);
		}

		if (airAttackTimeCounter > 0) {
			airAttackTimeCounter -= Time.deltaTime;
			rBody.velocity = Vector2.zero;
		}

		if (airAttackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("attack", false);	
			anim.SetBool ("windMagicAttack", false);
			Airmagic.SetActive (false);
		}

		anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
		anim.SetFloat("lastMoveX", lastMove.x);
		anim.SetFloat("lastMoveY", lastMove.y);
		anim.SetBool("isWalking", playerMoving);
	}

	IEnumerator Cooldown(){
		Debug.Log ("cooldown started");

		for (var x = 1; x < 2; x++) {
			yield return new WaitForSeconds (2);
		}

		Debug.Log ("cooldown ended");

		cooldown = false;
	}

}
