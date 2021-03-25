using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class VaateKesa : MonoBehaviour
{
	private Vector2 initialPosition;
	public Transform goalPlace;
	public AudioSource audioSource;
	public bool locked;

	public AudioSource kavelyUlos;

	private float startPosX;
	private float startPosY;
	private bool isBeingHeld = false;
	
	public GameObject vaatepeli_hahmo;
	private GameBehaviourScript gameBehaviourScript;

	public GameObject KokoHahmo;
	private Transform KokoHahmoTransform;

	// public GameObject Vaatteet2;
	// private Transform vaatteet2Transform;

	void Awake ()
	{
		gameBehaviourScript = vaatepeli_hahmo.GetComponent<GameBehaviourScript>();
		// vaatteet2Transform = Vaatteet2.GetComponent<Transform>();
		initialPosition = transform.position;
		KokoHahmoTransform = KokoHahmo.GetComponent<Transform>();
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
		// Päällivaatteet siirretään pois näkyvistä
		// vaatteet2Transform.position = new Vector3(-12,0,0);
    }

    // Update is called once per frame
    void Update()
    {
		if(isBeingHeld == true)
		{
			Vector3 mousePos;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			
			this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
		}
        
    }
	
	private void OnMouseDown()
	{
		if (!locked && Input.GetMouseButtonDown(0))
		{
		
			Vector3 mousePos;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			
			startPosX = mousePos.x - this.transform.localPosition.x;
			startPosY = mousePos.y - this.transform.localPosition.y;
			
			isBeingHeld = true;
		}
	}
	
	
	private void OnMouseUp()
	{
		isBeingHeld = false;
		
		if (Mathf.Abs(transform.position.x - goalPlace.position.x) <= 1.5f && Mathf.Abs(transform.position.y - goalPlace.position.y) <= 1.5f) 
		{
			if (!locked) {
				transform.position = new Vector2(goalPlace.position.x, goalPlace.position.y);
				audioSource.Play();
				locked = true;
				gameBehaviourScript.vaatteet1 = gameBehaviourScript.vaatteet1 + 1;
				//Debug.Log(gameBehaviourScript.vaatteet1);


				if (gameBehaviourScript.vaatteet1==3) {

					//Hahmo siirtyy ovesta ulos
					DOVirtual.DelayedCall(1, WalkOut);
				}
			}
			
		}
		else {

			transform.DOMove(new Vector2(initialPosition.x, initialPosition.y), 1);
			//transform.position = new Vector2(initialPosition.x, initialPosition.y);
		}
	}

	void WalkOut()
	{
		kavelyUlos.Play();
		KokoHahmoTransform.DOMoveX(15, 4, false);
		DOVirtual.DelayedCall(5, GoToNextScene);
	}

	void GoToNextScene()
	{
		SceneManager.LoadScene("Vaatepeli_kesa");
	}
}
