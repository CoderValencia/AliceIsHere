using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public GameObject blackScreen;

    public void StartFade()
    {
        StartCoroutine(FadeBlackOutSquare());
    }

    public void EndFade()
    {
        StartCoroutine(FadeBlackOutSquare(false));
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 3)
    {

        Color objectColor = blackScreen.GetComponent<SpriteRenderer>().color;
        float fadeamount;

        if (fadeToBlack)
        {
            while (blackScreen.GetComponent<SpriteRenderer>().color.a < 1)

            {
                fadeamount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeamount);
                blackScreen.GetComponent<SpriteRenderer>().color = objectColor;
                yield return null;


            }
        }
        else
        {

            while (blackScreen.GetComponent<SpriteRenderer>().color.a > 0)

            {
                fadeamount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeamount);
                blackScreen.GetComponent<SpriteRenderer>().color = objectColor;
                yield return null;
            }


        }
    }
}
