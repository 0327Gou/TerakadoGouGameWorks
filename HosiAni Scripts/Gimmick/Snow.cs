using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snow : MonoBehaviour
{
    // �N�[���^�C���i���̓�𑫂����l���傫�����āj
    public float CoolTime = 0.0f;
    // �������鎞��
    public float ActiveTime = 0.0f;
    // ����̗\������
    public float OmenTime = 0.0f;


    // �������鎞�Ԃ��v������ϐ�
    private float ActiveTimer = 0.0f;
    // �N�[���^�C�����v������ϐ�
    private float CoolTimer = 0.0f;
    // ����̗\�����Ԃ��v������ϐ�
    private float OmenTimer = 0.0f;

    bool omenflg = false;

    bool snowflg = false;

    // �v���C���[�i�[�p
    GameObject Player;
    // ����i�[�p
    public GameObject snow;
    // ����̗\���i�[�p
    public GameObject omen;

    void Start()
    {
        // �v���C���[��T��
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        // �N�[���^�C�����v��
        CoolTimer += Time.deltaTime;

        // �N�[���^�C������������
        if(CoolTimer >= CoolTime)
        {   
            // �v���C���[�̕����������悤�ɂ���
            // �Ώە��ւ̃x�N�g�����Z�o
            Vector2 toDirection = Player.transform.position - transform.position;
            // �Ώە��։�]����
            transform.rotation = Quaternion.FromToRotation(Vector2.down, toDirection);

            // ����𔭓�����t���O�𗧂Ă�
            omenflg = true;

            // �N�[���^�C�������Z�b�g����
            CoolTimer = 0.0f;
        }

        // �N�[���^�C�����������������̗\���𔭓�
        if(omenflg)
        {
            // �\�����Ԃ��v��
            OmenTimer += Time.deltaTime;

            // ����̗\�����o��
            omen.SetActive(true);

            // �\�����Ԃ���������
            if (OmenTimer >= OmenTime)
            {
                snowflg = true;
                // ����̗\�����\���ɂ���
                omen.SetActive(false);
            }
        }
        // ����𔭓�
        if(snowflg)
        {
            // �������Ԃ��v��
            ActiveTimer += Time.deltaTime;

            // ����𔭓�����
            snow.SetActive(true);

            // �������Ԃ���������
            if (ActiveTimer >= ActiveTime)
            {
                // ������\���ɂ���
                snow.SetActive(false);

                // �������Ԃ����Z�b�g����
                ActiveTimer = 0.0f;

                snowflg = false;
            }
            OmenTimer = 0.0f;
        }
    }
}
