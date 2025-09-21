/*
* �t�@�C���FMyFunction C#
* �V�X�e���F���낢��ȃX�N���v�g�ő��l����֐����`����
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;

public class MyFunctions : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �p�u���b�N�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�����ړ�����֐�
    /// ����    �F_moveSpeed�F�ړ����x
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void StraightMove(float _moveSpeed)
    {
        // Rigidbody2D���擾
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // �ړ����x�𔽉f�i�I�u�W�F�N�g���猩�ď�����j
        rb.velocity = transform.up * _moveSpeed * Time.timeScale;
    }

    /// <summary>
    /// �V�X�e���F�^�[�Q�b�g��ǂ�������֐�
    /// ����    �F_target�F�ǂ�������Ώ�
    ///         �F_moveSpeed�F�ړ����x
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void ChaseToTarget(GameObject _target, float _moveSpeed)
    {
        //Rigidbody�̎擾
        Rigidbody2D _rb = gameObject.GetComponent<Rigidbody2D>();

        // �����̌v�Z�iZ�����̏����Ɛ��K���j
        Vector3 moveForward = Vector3.Scale((_target.transform.position - transform.position), new Vector3(1, 1, 0)).normalized;

        // �w��̏ꏊ�Ɉړ��Avelocity�ɑ��x��������
        _rb.velocity = moveForward * _moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// �V�X�e���F�^�[�Q�b�g�ւ̌��������߂�֐�
    /// ����    �F_target�F�Ώ�
    /// �߂�l�@�FQuaternion
    /// </summary>
    public Quaternion RotateTarget(GameObject _target)
    {
        // �߂�l
        Quaternion qResult = Quaternion.identity;

        // �^�[�Q�b�g�̕������擾
        Vector2 lookDir = _target.transform.position - transform.position;

        // �^�[�Q�b�g�̕������v�Z
        qResult = Quaternion.FromToRotation(Vector3.up, lookDir);

        // �l��Ԃ�
        return qResult;
    }

    /// <summary>
    /// �V�X�e���F�v���C���[�ւ̌��������߂�֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�FQuaternion
    /// </summary>
    public Quaternion RotatePlayer()
    {
        // �߂�l
        Quaternion Result = Quaternion.identity;

        // �v���C���[���擾
        GameObject player = GameObject.FindWithTag("Player");

        // �^�[�Q�b�g�̕������擾
        Vector2 lookDir = player.transform.position - transform.position;

        // �^�[�Q�b�g�̕������v�Z
        Result = Quaternion.FromToRotation(Vector3.up, lookDir);

        // �l��Ԃ�
        return Result;
    }

    /// <summary>
    /// �V�X�e���F�^�[�Q�b�g�֌����֐�
    /// ����    �F_target�F�Ώ�
    ///         �F_rotateSpeed�F��]���x
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void Homing(GameObject _target, float _rotateSpeed)
    {
        // �^�[�Q�b�g�̈ʒu���擾���Ēǔ�
        Vector3 pos = _target.transform.position;

        // Rigidbody�̎擾
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        // �����̐����iZ�����̏����Ɛ��K���j
        Vector3 moveForward = Vector3.Scale((pos - transform.position), new Vector3(1, 1, 0)).normalized;

        // �w��̏ꏊ�Ɉړ��Avelocity�ɑ��x��������
        rb.velocity = moveForward * _rotateSpeed * Time.deltaTime;
    }

    /// <summary>
    /// �V�X�e���Fparent�����̎q�I�u�W�F�N�g��for���[�v�Ŏ擾����֐�
    /// ����    �F_target�F�Ώ�
    /// �߂�l�@�FQuaternion
    /// </summary>
    public Transform[] GetChildren(Transform _parent)
    {
        // �q�I�u�W�F�N�g���i�[����z��쐬
        var children = new Transform[_parent.childCount];

        // 0�`��-1�܂ł̎q�����Ԃɔz��Ɋi�[
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = _parent.GetChild(i);
        }

        // �q�I�u�W�F�N�g���i�[���ꂽ�z��
        return children;
    }
}
