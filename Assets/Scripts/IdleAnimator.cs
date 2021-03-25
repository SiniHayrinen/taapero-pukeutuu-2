using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimator : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnMouseDown()
    {
        myAnimationController.SetBool("IsIdle", false);

    }

    private void OnMouseUp()
    {
        myAnimationController.SetBool("IsIdle", true);

    }

}

//public class TapAnimator : MonoBehaviour
//{
//    [SerializeField] private Animator myAnimationController;

//    private void OnMouseUp()
//    {
//        myAnimationController.SetTrigger("PlayTapAnim");

//    }

//}
