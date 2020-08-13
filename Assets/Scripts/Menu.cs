using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {
	public Button playButton;

	// Use this for initialization
	void Awake() {
		Time.timeScale = 0;
		playButton = gameObject.transform.Find("PlayButton").GetComponent<Button>();
		playButton.onClick.AddListener(playGame);
		playButton.transform.GetComponentInChildren<Text>().text = "Play!";
	}

	void playGame() {
		//toggle ui
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	void pauseGame() {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
