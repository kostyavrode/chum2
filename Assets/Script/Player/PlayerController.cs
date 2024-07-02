using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed;
    private AnimatorController animatorController;
    private InputManager inputManager;
    private void Start()
    {
        animatorController = GetComponentInChildren<AnimatorController>();
        inputManager = ServiceLocator.GetService<InputManager>();
    }
    private void Update()
    {
        characterController.Move(new Vector3(inputManager.GetHorizontalInput(), -1, inputManager.GetVerticalInput()) *moveSpeed*Time.deltaTime);
        animatorController.SetAnimatorParameters(System.Math.Max(System.Math.Abs(inputManager.GetHorizontalInput()), System.Math.Abs(inputManager.GetVerticalInput())));
    }

}
