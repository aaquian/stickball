using UnityEngine;
using System.Collections;

public class StartOver : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "guy")
			other.gameObject.GetComponent<Movement>().startover();
	}
}
