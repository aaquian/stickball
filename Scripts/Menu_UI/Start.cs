using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Start : MonoBehaviour
{
	public void StartScene()
	{
		SceneManager.LoadScene("hitotsu");
	}
}
