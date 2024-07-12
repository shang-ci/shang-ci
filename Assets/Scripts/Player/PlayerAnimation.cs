using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator; // Animator组件的引用

    void Start()
    {
        animator = GetComponent<Animator>(); // 获取Animator组件
    }

    // 设置isWalking参数
    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking); // 设置Animator中的isWalking参数
    }

    // 设置isRunning参数
    public void SetRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning); // 设置Animator中的isRunning参数
    }

    // 设置isJumping参数
    public void SetJumping(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping); // 设置Animator中的isJumping参数
    }

    // 触发isAttacking触发器
    public void TriggerAttack()
    {
        animator.SetTrigger("isAttacking"); // 触发Animator中的isAttacking触发器
    }
}
