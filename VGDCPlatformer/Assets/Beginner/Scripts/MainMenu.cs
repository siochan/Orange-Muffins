using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame (){
		SceneManager.LoadScene("Level #1");
	}
	public void CreditSelect(){
		SceneManager.LoadScene("Credits");
	}
	public void BackButton(){
		SceneManager.LoadScene("Main Menu");
	}
	public void ControlsButton(){
		SceneManager.LoadScene("Controls");
	}
}
