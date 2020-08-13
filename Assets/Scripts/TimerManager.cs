using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {

	private Text timerText;
	private float startTime;
	// Use this for initialization
	void Awake() {
		startTime = 60;

		timerText = gameObject.GetComponent<Text>();
		timerText.text = startTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer();
	}

	public bool isGameOver() {
		if(int.Parse(timerText.text) == 0) {
			return true;
		}
		return false;
	}
	private void updateTimer()
	{
		startTime -= Time.deltaTime;
		timerText.text = startTime.ToString("0");
		if(isGameOver()) {
			Debug.Log("Game Over");
		}
	}
}
