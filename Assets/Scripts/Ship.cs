using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    private static float SpeedFactor = 5f;

	[SerializeField]
    private Vector3 startPosition = new Vector3(0, -6.5f, 0);
	private Vector3 goalPosition = new Vector3(0, 6.5f, 0);

	void Awake() {
		SetShipToStart();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
		{
			gameObject.transform.position += new Vector3(0,1*SpeedFactor,0) * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			gameObject.transform.position += new Vector3(0,-1*SpeedFactor,0) * Time.deltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D coll){
		Debug.Log("collision detected");
		SetShipToStart();
	}

	public bool ShipRouteCompleted()
	{
		if(gameObject.transform.position.y > goalPosition.y)
		{
			return true;
		}
		return false;
	}

	private void setShipPosition(Vector3 position)
	{
		gameObject.transform.position = position;
	}

	public void SetShipToStart()
	{
		setShipPosition(startPosition);
	}
}
