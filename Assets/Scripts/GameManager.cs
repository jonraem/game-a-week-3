using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int tokenCount;
	public int totalTokenCount;
	public GameObject tokenParent;
	public bool readyToGo = false;

	// Use this for initialization
	void Start () {
		totalTokenCount = tokenParent.transform.childCount;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void AddToken()
	{
		tokenCount++;
	}

	public void ReadyToGo()
	{
		readyToGo = true;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (50, 50, 200, 200), "Press F to toggle flashlight.");
		if (readyToGo)
		{
			GUI.Label (new Rect (250, 100, 200, 200), "Coins collected: " + tokenCount.ToString() + "/" + totalTokenCount.ToString());
			GUI.Label (new Rect (250, 50, 200, 200), "NOW COLLECT SOME COINS, MOTHERF#@*%R!!!");
		}

		if (tokenCount == totalTokenCount)
		{
			GUI.Label (new Rect (Screen.width/2 + 100, 50, 250, 250), "You are wizard.");
		}
	}
}
