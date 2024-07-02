using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float trackingSpeed = 2f;
    [SerializeField] private float offsetZ = 3f;
    [SerializeField] private float offsetY = 3f;
    [SerializeField] private float offsetX = 0.66f;
    [SerializeField] private Transform target;
    private bool isSeconsShowed;
    private void Start()
    {
        GameManager.onGameStateChange += CheckStartFollow;
    }
    private void OnDisable()
    {
        GameManager.onGameStateChange -= CheckStartFollow;
    }
    public void CheckStartFollow(GameState state)
    {
        if (state==GameState.PLAYING)
        {
            isSeconsShowed = true;
        }
        else
        {
            isSeconsShowed= false;
        }
    }
    private void Update()
    {
        if (isSeconsShowed)
        {
            Vector3 tempPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z - offsetZ);
            transform.position = Vector3.Lerp(transform.position, tempPosition, trackingSpeed * Time.deltaTime);
        }
    }
}
