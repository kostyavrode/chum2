using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public UIManager uiManager;
    private bool isCanInteract;
    private void Start()
    {
        if (!uiManager)
        uiManager=ServiceLocator.GetService<UIManager>();
    }
    private void FixedUpdate()
    {
        Debug.Log(uiManager);
        //if (!uiManager)
        
        
        
        CheckIntercation();
        if (isCanInteract)
        {
            ServiceLocator.GetService<UIManager>().ShowInteractButton(true);
        }
        else
        {
            ServiceLocator.GetService<UIManager>().ShowInteractButton(false);
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
