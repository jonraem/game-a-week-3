using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {

	public float threshold1 = 13.5f;
	public float cameraSpeed;

	public GameObject player;
	bool followPlayer = false;

	void Start()
	{
		transform.position = new Vector3 (7f, 2f, -10f);
	}
	
	void LateUpdate()
	{
		if (player.transform.position.x > threshold1)
		{
			PanCamera(22f);
			if ((player.transform.position.x > 22f) && (player.transform.position.x > transform.position.x))
			{
				followPlayer = true;
			}
		}
		if (player.transform.position.x < threshold1)
		{
			followPlayer = false;
			PanCamera(7f);
		}

		if (followPlayer)
		{
			transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		}
	}

	void PanCamera(float x)
	{
		float step = cameraSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (x, 2f, -10f), step);
	}
}