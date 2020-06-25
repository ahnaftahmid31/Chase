using UnityEngine;
public class Ball : MonoBehaviour {

	private Rigidbody2D rig;
	private bool isFrozen;
	private Animator animator;
	private Vector2 randomVelocity;
	const float speed = 5.0f;
	// this is UI branch
	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
		rig = GetComponent<Rigidbody2D> ();
		isFrozen = false;
		randomVelocity = new Vector2 (Random.Range (20f, 100f), Random.Range (50f, 150f));
		rig.velocity = randomVelocity.normalized * speed;
	}

	void LateUpdate () {
		if (!isFrozen) rig.velocity = rig.velocity.normalized * speed;
	}
	public void Freeze () {
		rig.velocity = Vector2.zero;
		isFrozen = true;
		animator.SetBool ("isFrozen", true);
	}
	public void OnMouseDown () {
		if (!isFrozen) Freeze ();
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.CompareTag ("ball") && isFrozen) {
			isFrozen = false;
			animator.SetBool ("isFrozen", false);
		}
	}
}