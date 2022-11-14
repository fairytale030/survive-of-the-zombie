using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charctermove : MonoBehaviour
{
    public Transform cameratrans;

    public float movespeed = 10f; // �����̴� ���ǵ�
    public float jumpspeed = 10f; // ���� ���ǵ�
    public float gravity = -20f; // �߷�
    public float yVelocity = 0; // Velocity(���ν�Ƽ)�� �ӵ� ��� ��
    public CharacterController characterController; // rigidbody(������ٵ�)�� ��� �����ϼ� �ְ� ������ش�.


    void Start()
    {
        characterController = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ��� �÷��̾��� ĳ���� ��Ʈ�ѷ��� �ִ´�(�ڵ�����)
        cameratrans = transform.GetChild(0); // �ڽİ�ü�� 1��°�� �ִ� ������Ʈ�� Ʈ�������� ������(�ڵ�����)a
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // ó������ ���ý���� �Լ� ��� // ȣ����Ż(����)�� ������ ����
        float v = Input.GetAxis("Vertical"); // ó������ ���ý���� �Լ� ��� // ��ƼĮ(����)�� ������ ����

        Vector3 moveDirection = new Vector3(h, 0, v); // ���� �𷺼��̶�� �̸��� ����3�� ������ ������ ������ ����
        moveDirection = cameratrans.TransformDirection(moveDirection);
        moveDirection *= movespeed;// ���� �𷺼ǿ� ���� ���ǵ带 ����

        if (characterController.isGrounded) // isGrounded�� ���� �پ��ִ��� �ƴ��� �Ǵ���
        {
            yVelocity = 0; // Y���ν�Ƽ�� �ӵ��� 0����
            if (Input.GetKeyDown(KeyCode.Space)) // ���� �����̽��ٸ� �����ٸ�
            {
                yVelocity = jumpspeed; // Y���ν�Ƽ�� ���� ���ǵ带 �ִ´�.
            }
        }

        yVelocity += (gravity * Time.deltaTime); // Y���ν�Ƽ���� �߷�(gravity)�� ���� ��
        moveDirection.y = yVelocity; // ���� �𷺼ǿ� Y���ν�Ƽ�� �ִ´�.

        characterController.Move(moveDirection * Time.deltaTime); // ���� �𷺼ǿ� Time.deltaTime�� �־� ������ �ӵ��� ������

        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 20, 0);
        }
    }
}