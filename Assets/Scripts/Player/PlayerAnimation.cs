using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator; // Animator���������

    void Start()
    {
        animator = GetComponent<Animator>(); // ��ȡAnimator���
    }

    // ����isWalking����
    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking); // ����Animator�е�isWalking����
    }

    // ����isRunning����
    public void SetRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning); // ����Animator�е�isRunning����
    }

    // ����isJumping����
    public void SetJumping(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping); // ����Animator�е�isJumping����
    }

    // ����isAttacking������
    public void TriggerAttack()
    {
        animator.SetTrigger("isAttacking"); // ����Animator�е�isAttacking������
    }
}
