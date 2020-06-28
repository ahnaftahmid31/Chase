using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	// Start is called before the first frame update
	private Text scoreText;
	private int score = 0;
	public int scoreMultiplier = 1;
	void Start () {
		scoreText = GetComponent<Text> ();
		scoreText.text = score.ToString ();
	}

	public void ballStopped () {
		score += 50 * scoreMultiplier;
		scoreText.text = score.ToString ();
	}
	public void ballFreed () {
		score -= 55 * scoreMultiplier;
		scoreText.text = score.ToString ();
	}
}