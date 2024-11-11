using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mannequin : MonoBehaviour
{
    // Variables publicas
    public NavigationComponent navigation;
    public GazeDetector detector;
    public Animator animator;
    public AudioSource audioSource;

    public Transform head;

    public float timeToStop, timeToMove, animationSpeed, attackDistance;

    public UnityEvent OnAttack;

    // Variables privadas
    private bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        CanMove();
        FollowPlayer();
    }

    void CanMove()
    {
        if (!detector.IsRendered())
        {
            if(!canMove)
            StartCoroutine(StartMovementCoroutine(timeToMove));
        }
        else
        {
            if(canMove)
            StartCoroutine(StopMovementCoroutine(timeToStop));
        }
    }

    void FollowPlayer()
    {
        if (canMove)
        {
            navigation.NavigationState(true);
            navigation.MoveToPosition(Player.Instance.transform.position);
            head.transform.LookAt(Player.Instance.transform.position);
            animator.speed = animationSpeed;
            audioSource.volume = 1.0f;

            if(Vector3.Distance(transform.position, Player.Instance.transform.position) < attackDistance)
            {
                OnAttack.Invoke();
            }
        }
        else
        {
            navigation.NavigationState(false);
            animator.speed = 0f;
            audioSource.volume = 0f;
        }
    }

    IEnumerator StopMovementCoroutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        canMove = false;
        animator.enabled = false;
    }

    IEnumerator StartMovementCoroutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        if (!detector.IsRendered())
        {
            canMove = true;
            animator.enabled = true;
        }
    }
}
