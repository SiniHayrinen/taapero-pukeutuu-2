using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableCatFood : MonoBehaviour
{
	private float startPosX;
	private float startPosY;
	private bool moving = false;

    // Update is called once per frame
    void Update()
    {
		if (moving) 
		{
			Vector3 mousePos;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			
			this.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.transform.localPosition.z);
		}
    }
	
	private void OnMouseDown() 
	{
		if (Input.GetMouseButton(0)) // left click
		{
			Vector3 mousePos;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			
			startPosX = mousePos.x - this.transform.localPosition.x;
			startPosY = mousePos.y - this.transform.localPosition.y;
			
			moving = true;
		}
	}
	
	private void OnMouseUp()
	{
		moving = false;
		Debug.Log("mouse up");
	}
}
