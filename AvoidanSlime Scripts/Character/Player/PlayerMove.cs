/*
* �t�@�C���FPlayerMove C#
* �V�X�e���F�v���C���[�̈ړ�����
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float moveSpeed;    // �����\�Ȉړ����x

    bool canMove;       // �ړ��ł��邩
    Vector2 moveInput;  // �C���v�b�g�p

    SpriteRenderer _groundSprite = null;    // �ړ��͈͂̃I�u�W�F�N�g�̃X�v���C�g
    Rigidbody2D _rb;                        // Rigidbody2D�̊i�[�p

    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �C���X�^���X���ǂݍ��܂��Ƃ��̏���
    private void Awake()
    {
        // ������
        canMove = true;

        // �R���|�[�l���g�̎擾
        _rb = gameObject.GetComponent<Rigidbody2D>();

        // �ړ��͈͂̃I�u�W�F�N�g���擾
        GameObject _groundObj = GameObject.Find("PlayGround");

        // �ړ��͈̓I�u�W�F�N�g�̃X�v���C�g���擾
        if (_groundObj != null)
        {
            // �ړ��͈̓I�u�W�F�N�g�̃X�v���C�g���擾
            _groundSprite = _groundObj.GetComponent<SpriteRenderer>();
        }
    }

    // ���t���[���̏���
    void Update()
    {
        // �ړ�
        Move();

        // �ړ�����
        MoveClamp();
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // �T�u�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�ړ�����
    /// �����@�@�F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    void Move()
    {
        // �ړ��ł��Ȃ��ꍇ�͏I��
        if (!canMove) { return; }

        //�ړ��̔��f
        _rb.position += moveInput * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// �V�X�e���F�v���C���[�̍s���͈͐���
    /// �����@�@�F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    void MoveClamp()
    {
        // �s���͈͂��Ȃ��Ȃ�I��
        if (_groundSprite == null) { return; }

        // �␳�p�̕ϐ�
        Vector2 ClampVec = transform.position;

        // ��ʉE��̍��W���擾
        Vector2 max = _groundSprite.bounds.max;

        // ��ʍ����̍��W���擾
        Vector2 min = _groundSprite.bounds.min;

        // �v���C���[�̃T�C�Y���擾
        Vector2 scl = transform.localScale / 2;

        // �g����o�Ȃ��悤�ɕ␳
        ClampVec.x = Mathf.Clamp(ClampVec.x, min.x + scl.x, max.x - scl.x);
        ClampVec.y = Mathf.Clamp(ClampVec.y, min.y + scl.y, max.y - scl.y);

        // �␳�𔽉f
        transform.position = ClampVec;
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�ړ��L�[�̔���
    /// �����@�@�FIA context
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void IA_Move(InputAction.CallbackContext context)
    {
        // �ړ��ł��Ȃ��ꍇ�͏I��
        if (!canMove) { return; }

        // Move�A�N�V�����̓��͎擾
        moveInput = context.ReadValue<Vector2>();
        // Debug.Log("���͂��ꂽ�l��" + _moveInputValue);

        // �l��␳
        moveInput.Normalize();
    }
}