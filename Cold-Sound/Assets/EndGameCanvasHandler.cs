using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCanvasHandler : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] float FadeInSpeed = 0.1f;

    [SerializeField] GameObject WinText;
    [SerializeField] GameObject LooseText;
    [SerializeField] GameObject Hint1;
    [SerializeField] GameObject Hint2;
    [SerializeField] GameObject JumpScare;

    AudioManager audioManager;


    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        audioManager = FindObjectOfType<AudioManager>();

        if (!audioManager) Debug.LogError("Audio manager pas trouvé");
    }

    private void Update()
    {
        if (Player_Movement_Law.isAlive == false)
        {
            if (Input.GetButton("Jump"))
            {
                Player_Movement_Law.isAlive = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
        }

    }

    public void Win()
    {
        WinText.SetActive(true);
        StartCoroutine(FadeIn());
    }

    bool alreadyDead = false;

    public void Loose(int HintIndex)
    {
        //Evite la superposition des canvas
        if (alreadyDead) return;

        alreadyDead = true;

        if (HintIndex == 1)
        {
            Hint1.SetActive(true);
        }
        else if (HintIndex == 2)
        {
            Hint2.SetActive(true);
            audioManager.PlayDeathSound();
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
