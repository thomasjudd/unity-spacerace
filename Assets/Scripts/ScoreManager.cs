using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    private int score;
	private Text scoreUI;
	public bool scoreIncreased = false;

	void Awake() {
		score = 0;
		scoreUI = gameObject.GetComponent<Text>();
	}

	void Update() {
	}

	public void UpdateScore() {
		score += 100;
	}

	public void SetUIScore() {
		scoreUI.text = score.ToString();
	}
}
