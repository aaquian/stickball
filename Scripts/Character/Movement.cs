using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float movespeed = 0.05f;
	Vector3 start;
	float lastPos;
	Rigidbody2D rb;
	float lastTime;
	Animator walk;

	void Start()
	{
		start = transform.position;
		lastPos = transform.position.x;
		rb = GetComponent<Rigidbody2D>();
		walk = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		transform.position += new Vector3(1,0,0) * movespeed;
		if((transform.position.x == lastPos || transform.position.x < lastPos) && (Time.time - lastTime) > 0.1f)
		{
			lastTime = Time.time;
			rb.AddForce(new Vector2(1, 5), ForceMode2D.Impulse);
		}
		walk.speed = slowDown();
		lastPos = transform.position.x;
	}

	public void startover()
	{
		transform.position = start + new Vector3(0,1,0);
		lastPos = start.x - 1;
	}

	float slowDown()
	{
		return 1 - (((1 * movespeed) - Mathf.Abs(transform.position.x - lastPos)) * 10);
	}
}
