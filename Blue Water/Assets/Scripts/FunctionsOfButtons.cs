using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FunctionsOfButtons : MonoBehaviour
{

	public void Exit ()
	{
		Application.Quit ();
	}

	public void ChooseFunSortingGame()
	{
		SceneManager.LoadScene("SortingMenu");
	}
	public void ChooseSavingOfTurtleGame()
	{
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void PlayFunSortingGame()
	{
		SceneManager.LoadScene("Sorting");
	}
	public void ReturnMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}


}

