using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Video;

public class Book : MonoBehaviour
{
    public RaycastFeedback RaycastFeedbackOpen;
    public RaycastFeedback RaycastFeedbackClose;
    [Space]
    public Animator animatorController;

    public AudioSource audioSource;
    public AudioClip clipOpen;
    public AudioClip clipClose;
    public VideoPlayer VideoPlayer1;
    public VideoPlayer VideoPlayer2;

    public void CloseBook()
    {
        animatorController.SetBool("isClose", true);
        animatorController.SetBool("isOpen", false);
        RaycastFeedbackOpen.enabled = true;
        RaycastFeedbackClose.enabled = false;
        VideoPlayer1.enabled = false;
        VideoPlayer2.enabled = false;
        audioSource.clip = clipClose;
        audioSource.Play();
    }

    public void StartVideo()
    {
        animatorController.SetBool("isOpen", true);
        animatorController.SetBool("isClose", false);
        StartCoroutine(PlayVideo());
        RaycastFeedbackOpen.enabled = false;
        audioSource.clip = clipOpen;
        audioSource.Play();
    }

    private IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(5.8f);

        VideoPlayer1.enabled = true;
        VideoPlayer2.enabled = true;

        RaycastFeedbackClose.enabled = true;
    }
}