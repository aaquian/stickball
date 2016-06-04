using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Draggable : MonoBehaviour
{
	Vector3 offset;
	bool dragging;
	bool colliding;
	SpriteRenderer sprite;
	Rigidbody2D body;
	BoxCollider2D col;

	List<GameObject> collisions = new List<GameObject>();

	public void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		body = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
	}

	public void TouchDown(Vector3 pos)
	{
		offset = transform.position - pos;
		sprite.color = Color.white;
		body.isKinematic = true;
		col.isTrigger = true;
		dragging = true;
	}

	public void TouchDrag(Vector3 pos)
	{
		transform.position = pos + offset;
	}
		
	public void TouchUp(Vector3 delta)
	{
		if(!colliding)
		{
			body.isKinematic = false;
			col.isTrigger = false;
		}
		dragging = false;

		// Maybe try to apply a force to keep it on its natural path
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(delta.x, delta.y));
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(!(other.tag == "Drag Only"))
		{
			collisions.Add(other.gameObject);
			colliding = true;
			sprite.color = Color.red;
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if(collisions.Contains(other.gameObject))
		{
			collisions.Remove(other.gameObject);
			if(collisions.Count == 0)
			{
				colliding = false;
				sprite.color = Color.white;
				if(!dragging)
				{
					body.isKinematic = false;
					col.isTrigger = false;
				}
			}
		}
	}
}
