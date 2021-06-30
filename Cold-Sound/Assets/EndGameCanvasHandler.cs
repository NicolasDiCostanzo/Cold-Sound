using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGameCanvasHandler : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] float FadeInSpeed = 0.1f;

    [SerializeField] GameObject WinText;
    [SerializeField] GameObject LooseText;
    [SerializeField] GameObject Hint1;
    [SerializeField] GameObject Hint2;
    [SerializeField] GameObject JumpScare;


    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Loose(1);
    }

    public void Win()
    {
        WinText.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void Loose(int HintIndex)
    {

        if (HintIndex == 1)
        {
            Hint1.SetActive(true);
        }
        else if (HintIndex == 2)
        {
            Hint2.SetActive(true);
        }
        JumpScare.SetActive(true);
        LooseText.SetActive(true);

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += FadeInSpeed;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
