using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour
{
	public int number;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);

		if(FindObjectsOfType(GetType()).Length > 1)
			Destroy(gameObject);
	}
}
