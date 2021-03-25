using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCatGame : MonoBehaviour
{
	
	private void OnMouseUpAsButton()
	{
		
		// Go to the FeedTheCat game.
		SceneManager.LoadScene("FeedTheCat");
		
	}
}