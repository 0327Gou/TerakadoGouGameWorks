using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyPlanet : MonoBehaviour
{
    // �J������؂�ւ���t���O
    [HideInInspector]
    public bool _fCamChange = false;

    // �����̘f���̍��W
    private Vector3 _PosPlanet;

    //���C���J�����i�[�p
    private Camera m_camMain;

    //���f���J�����i�[�p
    private Camera m_camMyPlanet;

    // �I�u�W�F�N�g�̃����_���[
    private SpriteRenderer _ren;

    // Texture�ۑ��p�̕ϐ�
    private Sprite _MyPlanet_Piace;
    
    // �摜�t�H���_�̖��O
    //private string _TexName; 

    // �v���l�b�g�s�[�X�̐�
    private int _iNumPiece = 0;

    // ���j���[�L�����o�X
    public Canvas MenuCanvas;

    Menu MenuScripts;

    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J���������ꂼ��擾
        m_camMain = GameObject.Find("Camera_Main").GetComponent<Camera>();
        m_camMyPlanet = GameObject.Find("Camera_MyPlanet").GetComponent<Camera>();

        m_camMain.depth = 1;

        // �����̘f���̈ʒu���擾
        _PosPlanet = GameObject.Find("MyPlanet").transform.position;

        // ���j���[�̃X�N���v�g�������Ă���
        MenuScripts = MenuCanvas.GetComponent<Menu>();
    }

    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        if (_fCamChange)
        {
            PlanetSystem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _fCamChange = true;

            Time.timeScale = 0;  // ���Ԓ�~

            // �J�����̐؂�ւ�
            m_camMain.depth *= -1;
            m_camMyPlanet.depth *= -1;
            Debug.Log("CamChange_Planet");

            // �C���x���g����\������
            MenuScripts.inventry.SetActive(true);
        } 
    }

    private void PlanetSystem()
    {
        // Debug.Log("Menu");

        if (_iNumPiece < 6)
        {
            // �J�����̐؂�ւ�
            if (Input.GetKeyDown("space"))
            {
                // ���j���[�����
                _fCamChange = false;

                Time.timeScale = 1;  // �ĊJ

                //���C���J�������A�N�e�B�u�ɐݒ�
                //_Camera_MyPlanet.SetActive(false);
                //mainCamera.SetActive(true);
                m_camMain.depth *= -1;
                m_camMyPlanet.depth *= -1;

                Debug.Log("CamChange_Player");

                // �C���x���g�����\���ɂ���
                MenuScripts.inventry.SetActive(false);
            }
        }
        else
        {
            // �Q�[���N���A�̏���
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}
