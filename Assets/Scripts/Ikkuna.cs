using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ikkuna : MonoBehaviour
{

	private void OnMouseUpAsButton()
	{
		// Return the current Active Scene in order to get the current Scene name.
		Scene scene = SceneManager.GetActiveScene();

		if (scene.name == "Vaatepeli")
		{
			SceneManager.LoadScene("VaatepeliKesa");
		}

		if (scene.name == "VaatepeliKesa")
		{
			SceneManager.LoadScene("VaatepeliSade");
		}

		if (scene.name == "VaatepeliSade")
		{
			SceneManager.LoadScene("Vaatepeli");
		}
		
		if (scene.name == "FeedTheCat")
		{
			SceneManager.LoadScene("VaatepeliKesa");
		}
	}

}
