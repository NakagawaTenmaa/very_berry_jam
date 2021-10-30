using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // “ü—ÍˆÚ“®
        InputMove();
    }

    /// <summary>
    /// “ü—ÍˆÚ“® ˆê‰ƒL[‚Æ‚Á‚Ä‚¨‚­
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
}
