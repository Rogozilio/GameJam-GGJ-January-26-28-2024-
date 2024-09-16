using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    public Transform plantPositionBomb;
    public ParticleSystem effectWick;
    public Transform wick;
    [Space] 
    public AudioSource audioSource;
    public AudioClip clipFireWick;
    public AudioClip clipSharik;
    [Space]
    public UnityEvent actionAfterWick;
    public UnityEvent actionBoomMoment;
    [Space] 
    public Animator animator;
    
    public void StartBomb()
    {
        transform.position = plantPositionBomb.transform.position;
        transform.rotation = plantPositionBomb.transform.rotation;
        plantPositionBomb.gameObject.SetActive(false);
        StartCoroutine(StartWick());
    }

    private IEnumerator StartWick()
    {
        effectWick.Play();
        audioSource.clip = clipFireWick;
        audioSource.Play();

        while (wick.localScale.y > 0)
        {
            wick.localScale -= new Vector3(0, 0.005f, 0);
            yield return new WaitForFixedUpdate();
        }
        wick.gameObject.SetActive(false);
        audioSource.Stop();
        //Audio
        audioSource.clip = clipSharik;
        audioSource.loop = false;
        audioSource.Play();
        animator.enabled = true;
        
        actionAfterWick?.Invoke();
        yield return new WaitForSeconds(4.5f);
        actionBoomMoment?.Invoke();
    }
}