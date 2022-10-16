using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// los niveles se guardan como strigns
	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
		// sceneFader es una animacion antes de cargar nuevo nivel a un nuevo nivel
		sceneFader.FadeTo(levelToLoad);
	}

	public void Quit ()
	{
		Debug.Log("Saliendo de la app...");
		Application.Quit();
	}

}
