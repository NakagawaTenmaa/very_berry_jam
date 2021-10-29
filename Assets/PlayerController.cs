using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool stop_flag = false;
    BoxBase box_base = null;
    int point = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (box_base == null) {
            if(box_base.gimmick()) {
                point = box_base.addPoint();
            }
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
            transform.position += Vector3.up;
        }
        if (Input.GetKey(_left)) {
            transform.position += -Vector3.right;
        }
        if (Input.GetKey(_down)) {
            transform.position += -Vector3.up;
        }
        if (Input.GetKey(_right)) {
            transform.position += Vector3.right;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != BoxConst.NORMAL_BOX) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        // �����Ŕ��󂯂�(�|�C���g���Z)
        box_base = other.gameObject.GetComponent<BoxBase>();
    }
}
