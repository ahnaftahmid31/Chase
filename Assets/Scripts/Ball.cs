using UnityEngine;
public class Ball : MonoBehaviour {

	private Rigidbody2D rig;
	private bool isFrozen;
	private Animator animator;
	private Vector2 randomForce;

	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
		rig = GetComponent<Rigidbody2D> ();
		isFrozen = false;
		randomForce = new Vector2 (Random.Range (20f, 100f), Random.Range (50f, 150f));
		rig.AddForce (randomForce);
	}

	// Update is called once per frame
	void Update () {

	}
	public void Freeze () {
		rig.constraints = RigidbodyConstraints2D.FreezePosition;
		isFrozen = true;
		animator.SetBool ("isFrozen", true);
	}
	public void OnMouseDown () {
		if (!isFrozen) Freeze ();
		// GameObject[] objects = GameObject.FindGameObjectsWithTag ("ball");
		// foreach (var item in objects) {
		// 	item.GetComponent<Rigidbody2D>().mass *= 10;
		// }
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.CompareTag ("ball") && isFrozen) {
			// Here we calculated the impact force of collider
			var fc = collision.collider.attachedRigidbody.velocity.normalized; // direction vector (opposite)
			var mag = randomForce.magnitude;
			fc *= -mag;
			rig.constraints = RigidbodyConstraints2D.None;
			rig.AddForce (fc);
			isFrozen = false;
			animator.SetBool ("isFrozen", false);
		}
	}
}