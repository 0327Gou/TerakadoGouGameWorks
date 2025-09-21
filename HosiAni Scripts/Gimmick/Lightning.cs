using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField]
    GameObject s;
    [SerializeField]
    GameObject e;
    [SerializeField]
    GameObject e2;

    [SerializeField]
    bool chageflg;

    SpriteRenderer m_sr;

    // Start is called before the first frame update
    void Start()
    {
        m_sr = this.GetComponent<SpriteRenderer>();
        m_sr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var spos = s.transform.position;
        var epos1 = e.transform.position;
        var epos2 = e2.transform.position;
        var EPOS = epos1;
        if (chageflg)
        {
            EPOS = epos2;
        }

        // �X�^�[�g����G���h�̕������擾
        var lookDir = spos - EPOS;
        // ���W���_�̒��S��
        transform.position = Vector3.Lerp(spos, EPOS, 0.5f);
        // �T�C�Y���_�̋����Ɠ�����
        m_sr.size = new Vector2(Vector2.Distance(spos, EPOS), m_sr.size.y);
        // �������_�̊p�x�Ɠ�����
        transform.rotation = Quaternion.FromToRotation(Vector3.right, lookDir);

    }
}
