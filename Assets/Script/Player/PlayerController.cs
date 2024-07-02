using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed;
    private InputManager inputManager;
    private void Start()
    {
        inputManager = ServiceLocator.GetService<InputManager>();
    }
    private void Update()
    {
        characterController.Move(new Vector3(inputManager.GetHorizontalInput(), -1, inputManager.GetVerticalInput()) *moveSpeed*Time.deltaTime);
        
    }

}
