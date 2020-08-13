using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	private Text timerText;
	private float startTime;

	private Button pauseButton;
	private Text scoreUI;
	private int score;
	private bool scoreIncreased;

	[SerializeField]
	public GameObject AsteroidManager;

	[SerializeField]
	public Ship ship;

	[SerializeField]
	public GameObject menu;
	
	void Awake() {
		startTime = 60f;
		timerText = gameObject.transform.Find("Timer").GetComponent<Text>();
		timerText.text = startTime.ToString();

		pauseButton = gameObject.transform.Find("Pause").GetComponent<Button>();
		pauseButton.onClick.AddListener(pauseGame);
		pauseButton.transform.GetComponentInChildren<Text>().text = "Pause";

		scoreUI = gameObject.transform.Find("Score").GetComponent<Text>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer();
		if(ship.ShipRouteCompleted()){
			updateScore();
			setUIScore();
			Debug.Log("before set ship to start");
			ship.SetShipToStart();
		}
		if(isGameOver()) {
			pauseGame();
		}
	}

	private bool isGameOver() {
		if(int.Parse(timerText.text) == 0) {
			return true;
		}
		return false;
	}

	public void pauseGame() {
		Time.timeScale = 0;
		menu.SetActive(true);
	}

	private void updateTimer()
	{
		startTime -= Time.deltaTime;
		timerText.text = startTime.ToString("0");
		if(isGameOver()) {
			Debug.Log("Game Over");
		}
	}

	private void updateScore() {
		score += 100;
	}

	private void setUIScore() {
		scoreUI.text = score.ToString();
	}
}
