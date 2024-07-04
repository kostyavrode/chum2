using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private UIManager uiManager;
    private bool isCanInteract;
    private void Start()
    {
        uiManager=ServiceLocator.GetService<UIManager>();
    }
    private void Update()
    {
        CheckIntercation();
        if (isCanInteract)
        {
            uiManager.ShowInteractButton(true);
        }
        else
        {
            uiManager.ShowInteractButton(false);
        }
    }
    private void CheckIntercation()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, 2f))
        {
            if (hit.collider.tag == "Interaction")
            {
                isCanInteract = true;
                hit.collider.SendMessage("SetInteractSprite");
                hit.collider.GetComponent<InteractionComponent>().SetInteractSprite();
            }
            else
            {
                isCanInteract = false;
            }
        }
        else
        {
            isCanInteract=false;
        }
    }
}
