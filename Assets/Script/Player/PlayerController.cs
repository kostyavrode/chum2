using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed;
    private float smooth = 1;
    private AnimatorController animatorController;
    private InputManager inputManager;
    private void Start()
    {
        animatorController = GetComponentInChildren<AnimatorController>();
        inputManager = ServiceLocator.GetService<InputManager>();
    }
    private void Update()
    {
        Vector3 direction = new Vector3(inputManager.GetHorizontalInput(), -1, inputManager.GetVerticalInput());
        characterController.Move(direction *moveSpeed*Time.deltaTime);
        //animatorController.SetAnimatorParameters(System.Math.Max(System.Math.Abs(inputManager.GetHorizontalInput()), System.Math.Abs(inputManager.GetVerticalInput())));
        animatorController.SetAnimatorParameters(Mathf.Clamp(System.Math.Abs(inputManager.GetHorizontalInput()) + System.Math.Abs(inputManager.GetVerticalInput()),0,1));
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //animatorController.gameObject.transform.rotation = new Quaternion(0, rotation.y, 0,0.5f);
        //float rotationAngle=Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg*rotation.eulerAngles.y;
        //float angle = Mathf.SmoothDampAngle(animatorController.gameObject.transform.y, rotationAngle, ref smooth, 1f);
        animatorController.gameObject.transform.rotation =Quaternion.Euler(0, rotation.y*180, 0);
    }

}
