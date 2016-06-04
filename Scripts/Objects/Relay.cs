using UnityEngine;
using System.Collections;

public class Relay : MonoBehaviour
{
	public void TouchDown(Vector3 pos)
	{
		transform.parent.SendMessage("TouchDown", pos);
	}

	public void TouchDrag(Vector3 pos)
	{
		transform.parent.SendMessage("TouchDrag", pos);
	}

	public void TouchUp(Vector3 pos)
	{
		transform.parent.SendMessage("TouchUp", pos);
	}
}
