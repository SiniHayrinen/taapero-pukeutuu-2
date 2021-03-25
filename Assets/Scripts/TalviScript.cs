using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TalviScript : MonoBehaviour
{
    public GameObject KokoHahmo;
    private Transform KokoHahmoTransform;

    void Awake()
    {
        KokoHahmoTransform = KokoHahmo.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        KokoHahmoTransform.DOMoveX(3.4f, 5, false);
        DOVirtual.DelayedCall(5, BackToScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void BackToScene () {
		SceneManager.LoadScene("VaatepeliKesa");
	}
}
