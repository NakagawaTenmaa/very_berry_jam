using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool stop_flag = false;
    BoxBase box_base = null;
    int point = 0;

    bool hide_status = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (box_base != null) {
            if(box_base.gimmick()) {
                point = box_base.addPoint();
                box_base = null;
            }
            return;
        }

        // ���͈ړ�
        InputMove();
    }

    /// <summary>
    /// ���͈ړ� �ꉞ�L�[�Ƃ��Ă���
    /// </summary>
    void InputMove(KeyCode _up = KeyCode.W, KeyCode _down = KeyCode.S, KeyCode _right = KeyCode.D, KeyCode _left = KeyCode.A)
    {
        if (Input.GetKey(_up)) {
            transform.position += Vector3.up * Time.deltaTime * 1.5f;
        }
        if (Input.GetKey(_left)) {
            transform.position += -Vector3.right * Time.deltaTime * 1.5f;
        }
        if (Input.GetKey(_down)) {
            transform.position += -Vector3.up * Time.deltaTime * 1.5f;
        }
        if (Input.GetKey(_right)) {
            transform.position += Vector3.right * Time.deltaTime * 1.5f;
        }
    }

    /// <summary>
    /// �B����
    /// </summary>
    public void HideAction()
    {
        hide_status = Input.GetKey(KeyCode.Z);
        if (!hide_status) return;

        // �B���A�j���[�V�����͂������
    }

    /// <summary>
    /// �B���Ԃ̎擾
    /// </summary>
    /// <returns></returns>
    public bool getHideStatus()
    {
        return hide_status;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != BoxConst.NORMAL_BOX) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        // �����Ŕ��󂯂�(�|�C���g���Z)
        box_base = other.gameObject.GetComponent<BoxBase>();
    }
}
