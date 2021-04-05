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

					FoodBehaviour.foodEaten += 1;
					Debug.Log("foodEaten is " + FoodBehaviour.foodEaten);
				}
			}
		}
    }
}