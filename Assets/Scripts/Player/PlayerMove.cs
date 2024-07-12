using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f; // ��ɫ�����ٶ�
    public float runSpeed = 5f; // ��ɫ�����ٶ�
    private Rigidbody2D rb; // Rigidbody2D���������
    private PlayerAnimation playerAnimation; // PlayerAnimation���������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��ȡRigidbody2D���
        playerAnimation = GetComponent<PlayerAnimation>(); // ��ȡPlayerAnimation���
    }

    void Update()
    {
        Move(); // ����Move�������ƽ�ɫ�ƶ�
        Jump(); // ����Jump�������ƽ�ɫ��Ծ
       //Attack(); // ����Attack�������ƽ�ɫ����
    }

    // ���ƽ�ɫ�ƶ��ķ���
    void Move()
    {
        float move = Input.GetAxis("Horizontal"); // ��ȡˮƽ����

     // if (Input.GetKey(KeyCode.LeftShift)) // ���������Shift��
     // {
     //     rb.velocity = new Vector2(move * runSpeed, rb.velocity.y); // ���ý�ɫ��ˮƽ�ٶ�ΪrunSpeed
     //     playerAnimation.SetRunning(true); // ���ý�ɫ���ܶ���
     //     playerAnimation.SetJumping(false); // �رս�ɫ���߶���
     // }
     // else if (move != 0) // �����ˮƽ����
     // {
     //     rb.velocity = new Vector2(move * walkSpeed, rb.velocity.y); // ���ý�ɫ��ˮƽ�ٶ�ΪwalkSpeed
     //     playerAnimation.SetWalking(true); // ���ý�ɫ���߶���
     //     playerAnimation.SetRunning(false); // �رս�ɫ���ܶ���
     // }
     // else // ���û��ˮƽ����
     // {
     //     playerAnimation.SetWalking(false); // �رս�ɫ���߶���
     //     playerAnimation.SetRunning(false); // �رս�ɫ���ܶ���
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

    // ���ƽ�ɫ��Ծ�ķ���
    void Jump()
    {
        if (Input.GetButtonDown("Jump")) // ���������Ծ��ť
        {
            rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse); // ����ɫ������ϵ�˲ʱ��
            playerAnimation.SetJumping(true); // ���ý�ɫ��Ծ����
        }
    }

    // ���ƽ�ɫ�����ķ���
    void Attack()
    {
        if (Input.GetButtonDown("Fire1")) // ������¹�����ť
        {
            playerAnimation.TriggerAttack(); // ������ɫ��������
        }
    }

    // ��ײ��ⷽ��������ɫ�������ײʱ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �����ײ�����ǵ���
        {
            playerAnimation.SetJumping(false); // �رս�ɫ��Ծ����

            // ���ݽ�ɫ��ˮƽ�ٶ�����isRunning״̬
            if (Mathf.Abs(rb.velocity.x) > walkSpeed) // ���ˮƽ�ٶȴ���walkSpeed
            {
                playerAnimation.SetRunning(true); // ���ý�ɫ���ܶ���
            }
            else // ���ˮƽ�ٶ�С�ڻ����walkSpeed
            {
                playerAnimation.SetRunning(false); // �رս�ɫ���ܶ���
            }
        }
    }
}
