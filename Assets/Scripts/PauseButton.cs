using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

	private Button pauseButton;

	[SerializeField]
	public GameObject menu;

	void Awake() {
		pauseButton = gameObject.GetComponent<Button>();
		pauseButton.onClick.AddListener(pauseGame);
		pauseButton.transform.GetComponentInChildren<Text>().text = "Pause";
	}

	public void pauseGame() {
		Time.timeScale = 0;
		menu.SetActive(true);
	}
}
