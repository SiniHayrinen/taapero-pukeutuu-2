using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour
{
    public Image splashImage;
    public Image nimiImage;
    public string loadLevel;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        nimiImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(0.5f);
        FadeInName();
        yield return new WaitForSeconds(2.0f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 2.0f, false);
    }

    void FadeInName()
    {
        nimiImage.CrossFadeAlpha(1.0f, 2.0f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.0f, false);
        nimiImage.CrossFadeAlpha(0.0f, 2.0f, false);
    }

}
