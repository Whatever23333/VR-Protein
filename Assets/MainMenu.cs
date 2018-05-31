using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartProtein(){
        print(123);
		SceneManager.LoadScene ("Start");
	}

	public void QuitProtein(){
        print(456);
		Debug.Log ("QUIT!");
		Application.Quit ();
	}


}
