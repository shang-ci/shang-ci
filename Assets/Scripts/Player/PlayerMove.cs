using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f; // 角色行走速度
    public float runSpeed = 5f; // 角色奔跑速度
    private Rigidbody2D rb; // Rigidbody2D组件的引用
    private PlayerAnimation playerAnimation; // PlayerAnimation组件的引用

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取Rigidbody2D组件
        playerAnimation = GetComponent<PlayerAnimation>(); // 获取PlayerAnimation组件
    }

    void Update()
    {
        Move(); // 调用Move方法控制角色移动
        Jump(); // 调用Jump方法控制角色跳跃
       //Attack(); // 调用Attack方法控制角色攻击
    }

    // 控制角色移动的方法
    void Move()
    {
        float move = Input.GetAxis("Horizontal"); // 获取水平输入

     // if (Input.GetKey(KeyCode.LeftShift)) // 如果按下左Shift键
     // {
     //     rb.velocity = new Vector2(move * runSpeed, rb.velocity.y); // 设置角色的水平速度为runSpeed
     //     playerAnimation.SetRunning(true); // 设置角色奔跑动画
     //     playerAnimation.SetJumping(false); // 关闭角色行走动画
     // }
     // else if (move != 0) // 如果有水平输入
     // {
     //     rb.velocity = new Vector2(move * walkSpeed, rb.velocity.y); // 设置角色的水平速度为walkSpeed
     //     playerAnimation.SetWalking(true); // 设置角色行走动画
     //     playerAnimation.SetRunning(false); // 关闭角色奔跑动画
     // }
     // else // 如果没有水平输入
     // {
     //     playerAnimation.SetWalking(false); // 关闭角色行走动画
     //     playerAnimation.SetRunning(false); // 关闭角色奔跑动画
     // }
        if(move != 0)
        {
            rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
            playerAnimation.SetRunning(true);
        }
        else
        {
            playerAnimation.SetRunning(false);
        }
    }

    // 控制角色跳跃的方法
    void Jump()
    {
        if (Input.GetButtonDown("Jump")) // 如果按下跳跃按钮
        {
            rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse); // 给角色添加向上的瞬时力
            playerAnimation.SetJumping(true); // 设置角色跳跃动画
        }
    }

    // 控制角色攻击的方法
    void Attack()
    {
        if (Input.GetButtonDown("Fire1")) // 如果按下攻击按钮
        {
            playerAnimation.TriggerAttack(); // 触发角色攻击动画
        }
    }

    // 碰撞检测方法，当角色与地面碰撞时调用
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 如果碰撞物体是地面
        {
            playerAnimation.SetJumping(false); // 关闭角色跳跃动画

            // 根据角色的水平速度设置isRunning状态
            if (Mathf.Abs(rb.velocity.x) > walkSpeed) // 如果水平速度大于walkSpeed
            {
                playerAnimation.SetRunning(true); // 设置角色奔跑动画
            }
            else // 如果水平速度小于或等于walkSpeed
            {
                playerAnimation.SetRunning(false); // 关闭角色奔跑动画
            }
        }
    }
}
