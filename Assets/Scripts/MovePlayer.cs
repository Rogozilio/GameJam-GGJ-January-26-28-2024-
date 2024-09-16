using System;
using System.Collections;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = -9.8F;
    public Transform cameraTransform;

    [Space] public Animator animator;
    [Space] public GameObject punchCollider;

    [Space] public AudioSource audioSource;
    public AudioClip punch;
    public AudioClip step;
    [Space] public RectTransform inventory;

    private Vector3 velocity = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        // Get player input
        moveDirection = new Vector3(inputX, 0, inputY);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Add gravity to the move direction
        moveDirection.y = velocity.y;

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);

        Animation(inputX, inputY);

        transform.forward = LookFromCamera();

        ZoomCamera();
    }

    private Vector3 LookFromCamera()
    {
        var cameraForward = Camera.main.transform.forward;
        return new Vector3(cameraForward.x, 0, cameraForward.z);
    }

    private void Animation(float inputX, float inputY)
    {
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Right");
        animator.ResetTrigger("Forward");
        animator.ResetTrigger("Back");
        animator.ResetTrigger("Punch");

        var isLeft = inputX < -0.5f;
        var isRight = inputX > 0.5f;
        var isForward = inputY > 0.5f;
        var isBack = inputY < -0.5f;

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Punch");
            audioSource.loop = false;
            audioSource.clip = punch;
            audioSource.Play();
            StartCoroutine(DelayActivatePunchCollider());
        }

        if (isLeft)
            animator.SetTrigger("Left");
        if (isRight)
            animator.SetTrigger("Right");
        if (isBack)
            animator.SetTrigger("Back");
        if (isForward)
            animator.SetTrigger("Forward");

        if (isLeft || isRight || isBack || isForward)
        {
            audioSource.clip = step;
            if (!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else if (audioSource.clip == step)
        {
            audioSource.Stop();
        }
    }

    private IEnumerator DelayActivatePunchCollider()
    {
        yield return new WaitForSeconds(0.2f);
        punchCollider.SetActive(true);
    }

    private void ZoomCamera()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = 30;
        }
        else
        {
            Camera.main.fieldOfView = 60;
        }
    }
}