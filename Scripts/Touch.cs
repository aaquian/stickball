using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour
{
	Vector3 pos;
	RaycastHit2D hit;
	RuntimePlatform platform;
	GameObject lastHit;
	Vector3 lastPosition;
	Vector3 delta;
	UnityEngine.Touch touch;
	bool paused = false;

	public GameObject globalControl;

	enum MouseState
	{
		Down,
		Drag,
		Up
	};

	void Start ()
	{
		globalControl.GetComponent<Menu>().pauseControl += pause;
		platform = Application.platform;
		lastPosition = Vector3.zero;
	}

	void Update()
	{
		if(!paused)
		{
			if(platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer)
			{
				if(Input.GetMouseButtonDown(0))
					GetObject(Input.mousePosition, MouseState.Down);
				else if(Input.GetMouseButton(0))
					GetObject(Input.mousePosition, MouseState.Drag);
				else if(Input.GetMouseButtonUp(0))
					GetObject(Input.mousePosition, MouseState.Up);
			}else if(platform == RuntimePlatform.Android) {
				if(Input.touchCount > 0)
				{
					touch = Input.GetTouch(0);
					if(touch.phase == TouchPhase.Began)
						GetObject(touch.position, MouseState.Down);
					else if(touch.phase == TouchPhase.Moved)
						GetObject(touch.position, MouseState.Drag);
					else if(touch.phase == TouchPhase.Ended)
						GetObject(touch.position, MouseState.Up);
				}
			}
		}
	}

	void pause()
	{
		paused = !paused;
	}

	void GetObject(Vector3 pos, MouseState state)
	{
		pos = Camera.main.ScreenToWorldPoint(pos);
		if(state == MouseState.Down)
		{
			hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), Vector2.zero);
			if(hit.collider != null)
			{
				lastHit = hit.collider.gameObject;
				lastHit.SendMessage("TouchDown", pos, SendMessageOptions.DontRequireReceiver);
			}
		}else if(state == MouseState.Drag && lastHit != null) {
			lastHit.SendMessage("TouchDrag", pos, SendMessageOptions.DontRequireReceiver);
			lastPosition = pos;
		}else if(state == MouseState.Up && lastHit != null) {
			delta = pos - lastPosition;
			lastHit.SendMessage("TouchUp", delta, SendMessageOptions.DontRequireReceiver);
			lastHit = null;
		}
	}
}