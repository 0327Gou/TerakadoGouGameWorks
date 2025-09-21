// �w�i���X�V���鏈��

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundMng : MonoBehaviour
{
    // �J�����̏��
    [SerializeField]
    Camera m_cam;
    public GameObject bgObj;
    public float scrollspeed;

    [SerializeField]
    int m_OiL;

    GameObject[] bg;

    // �w�i�̉��T�C�Y������ϐ�
    float m_fSidesize;

    // Start is called before the first frame update
    void Start()
    {
        // �w�i�̉��T�C�Y���擾
        m_fSidesize = bgObj.GetComponent<SpriteRenderer>().bounds.size.x;

        bg = new GameObject[3];

        // �w�i�i�[
        for(int i = 0; i < bg.Length; ++i)
        {
            // �v���n�u���猾�z��ɃC���X�^���X��
            bg[i] = Instantiate(bgObj, new Vector3((float)(i - 1) * m_fSidesize, transform.position.y, transform.position.z),Quaternion.identity);

            // �e���uBG�v�ɂ���
            bg[i].transform.SetParent(transform);
            bg[i].GetComponent<SpriteRenderer>().sortingOrder = m_OiL;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �X�N���[������
        this.transform.position = new Vector2(m_cam.transform.position.x * scrollspeed, m_cam.transform.position.y);

        // �X�V���X���W
        float fPosX;

        for (int i = 0; i < bg.Length; ++i)
        {

            if (bg[i].transform.position.x < m_cam.transform.position.x - 30f)
            {
                fPosX = bg[i].transform.localPosition.x + m_fSidesize * 3.0f;
            }
            else if (bg[i].transform.position.x > m_cam.transform.position.x + 30f)
            {
                fPosX = bg[i].transform.localPosition.x - m_fSidesize * 3.0f;
            }
            else
            {
                fPosX = bg[i].transform.localPosition.x;
            }

            // �X�V�𔽉f
            bg[i].transform.localPosition = new Vector2(fPosX, 0.0f);
        }
    }
}
