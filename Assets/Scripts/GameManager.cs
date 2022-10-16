using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start ()
	{
        // variable interna, 
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
        // si el juego se termina, no hace nada esta funcion
		if (GameIsOver)
			return;

        // si pierde las vidas, ejecuta EndGame
		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
        // activa la UI
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
        // activa UI de ganar
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
