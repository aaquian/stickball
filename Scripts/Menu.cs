using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
	public GameObject menugui;
	public delegate void PauseControl();
	public PauseControl pauseControl;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pauseControl();
			Time.timeScale = Time.timeScale > 0 ? 0 : 1;
			menugui.SetActive(!menugui.activeSelf);
		}
	}

	public void BackMenu()
	{
		if(Time.timeScale == 0)
			Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}
}
