using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DragAndDrop : MonoBehaviour
{
	
	bool moveAllowed;
	Collider2D col;
	public Transform goalPlace;
	public AudioSource crunch;
	public Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
		FoodBehaviour.foodEaten = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
			
			if (touch.phase == TouchPhase.Began)
			{
				Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
				if (col == touchedCollider)
				{
					moveAllowed = true;
				}
			}
			
			if (touch.phase == TouchPhase.Moved)
			{
				if (moveAllowed)
				{
					transform.position = new Vector2(touchPosition.x, touchPosition.y);
				}
			}
			
			if (touch.phase == TouchPhase.Ended)
			{
				moveAllowed = false;

				// If the cat food is on top of cat's face
				if (Mathf.Abs(transform.position.x - goalPlace.position.x) <= 1.5f && Mathf.Abs(transform.position.y - goalPlace.position.y) <= 1.5f) 
				{
					// Hides the cat food that was eaten
					this.gameObject.SetActive(false);

					crunch.Play();
					anim.SetTrigger("StartsToEat");

					FoodBehaviour.foodEaten += 1;
					Debug.Log("foodEaten is " + FoodBehaviour.foodEaten);

					// Change the scene when every piece is eaten
					if (FoodBehaviour.foodEaten >= 8) {
						// 
						DOVirtual.DelayedCall(1, SleepyCat);
					}
				}
			}
		}
    }

	void SleepyCat() {
		//kavelyUlos.Play();
		//KokoHahmoTransform.DOMoveX(15, 4, false);
		DOVirtual.DelayedCall(1, GoToNextScene);
	}

	void GoToNextScene()
	{
		SceneManager.LoadScene("VaatepeliKesa");
	}
}