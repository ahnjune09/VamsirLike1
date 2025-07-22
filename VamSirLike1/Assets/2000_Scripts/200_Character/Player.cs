using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerStatus Status;

    private void Update()
    {
        PlayerMoveInput();
    }

    private void PlayerMoveInput()
    {
        // Å° ÀÔ·Â
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.position += (Vector3.up * Time.deltaTime) * Status.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.position += Vector3.down * Time.deltaTime * Status.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position += Vector3.left * Time.deltaTime * Status.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * Time.deltaTime * Status.MoveSpeed;
        }
    }
}
