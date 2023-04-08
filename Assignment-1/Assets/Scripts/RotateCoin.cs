using UnityEngine;
using System.Collections;

public class RotateCoin : MonoBehaviour
{

	private int i = 5;
	public int maxframes = 45;
	private int frames = 0;
	void Update()
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		float t = (float)frames / maxframes;
		Vector3 rotate = transform.rotation.eulerAngles;
		rotate.y = (((rotate.y + i) % 360) + 360) % 360;
		Vector3 interpolatedRotation = Vector3.Lerp(transform.rotation.eulerAngles, rotate,t);
		transform.rotation = Quaternion.Euler(interpolatedRotation);
		frames = (frames + 1) % (maxframes + 1);
	}
}