using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private float vertical;
    private float horizontal;
    private void Update()
    {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;
    }
    public float GetVerticalInput()
    {
        return vertical;
    }
    public float GetHorizontalInput()
    {
        return horizontal;
    }
}
