using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	
	bool moveAllowed;
	Collider2D col;
	public Transform goalPlace;
	public AudioSource crunch;
	
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
		Debug.Log("start");
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
				Debug.Log("ended");

				// If the cat food is on top of cat's face
				if (Mathf.Abs(transform.position.x - goalPlace.position.x) <= 1.5f && Mathf.Abs(transform.position.y - goalPlace.position.y) <= 1.5f) 
				{
					Debug.Log("maali");

					// Hides the cat food that was eaten
					this.gameObject.SetActive(false);

					crunch.Play();
				}
			}
		}
    }
}


/* -----
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

				if (gameBehaviourScript.vaatteet1==4) {

					//vaatteet2Transform.position = new Vector3(2.42f,1.1f,0);
					vaatteet2Transform.DOMove(new Vector3(2.42f, 1.1f, 0), 1);
				}
				// Skene vaihtuu
				if (gameBehaviourScript.vaatteet1==8) {
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
 */