 using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	bool flashlightOn=false;

	void Start()
	{
		FlashlightOn (flashlightOn);
	}
	
	// Update is called once per frame
	void Update () {

		// This code sets the F button to toggle the flashlight
		if(Input.GetKeyDown(KeyCode.F))
		{
			if (flashlightOn == true)
			{
				FlashlightOn(true);
				flashlightOn = false;
			} 
			else
			{
				FlashlightOn(false);
				flashlightOn = true;
			}
		}
	}

	void FlashlightOn(bool value)
	{
		GameObject.Find ("FlashlightLight").light.enabled = value;
	}
}
