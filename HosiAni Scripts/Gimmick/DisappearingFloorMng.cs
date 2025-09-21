using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloorMng : MonoBehaviour
{
    // �؂�ւ�鎞��
    [SerializeField]
    float m_fChangeTime;

    // A�z��
    Transform[] m_obA;

    // B�z��
    Transform[] m_obB;

    float m_fTimer;
    bool m_bChange;

    // Start is called before the first frame update
    void Start()
    {
        // ������
        m_fTimer = 0.0f;

        // �q�I�u�W�F�N�g�̐����擾
        int childCountA = transform.GetChild(0).transform.childCount;
        int childCountB = transform.GetChild(1).transform.childCount;

        // �q�I�u�W�F�N�g�B������z��̏�����
        m_obA = new Transform[childCountA];
        m_obB = new Transform[childCountB];

        // ���I�u�W�F�N�g��z��ɓ����
        for (int i = 0; i < childCountA; ++i)
        {
            m_obA[i] = transform.GetChild(0).transform.GetChild(i);
            Debug.Log(m_obA[i].name);
        }

        for (int i = 0; i < childCountB; ++i)
        {
            m_obB[i] = transform.GetChild(1).transform.GetChild(i);
            Debug.Log(m_obB[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_fTimer += Time.deltaTime;

        if(m_fTimer >= m_fChangeTime)
        {
            // �t���O��؂�ւ���
            m_bChange = FlgChanger(m_bChange);

            if (m_bChange)
            {
                for (int i = 0; i < m_obA.Length; ++i)
                {
                    m_obA[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        0.25f);
                    m_obA[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
                for (int i = 0; i < m_obB.Length; ++i)
                {
                    m_obB[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        1f);
                    m_obB[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < m_obA.Length; ++i)
                {
                    m_obA[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        1.0f);
                    m_obA[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
                for (int i = 0; i < m_obB.Length; ++i)
                {
                    m_obB[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        0.25f);
                    m_obB[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            // ���Ԃ����Z�b�g����
            m_fTimer = 0.0f;
        }
    
    }

    // �t���O�𔽓]������֐�
    bool FlgChanger(bool _flg)
    {
        // ���]������
        if (_flg)
        {
            _flg = false;
        }
        else
        {
            _flg = true;
        }

        // �߂�l��Ԃ�
        return _flg;
    }
}
