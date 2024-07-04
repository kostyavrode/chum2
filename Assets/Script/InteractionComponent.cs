using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractionComponent : MonoBehaviour
{
    public Sprite gameSprite;
    public void SetInteractSprite()
    {
        ServiceLocator.GetService<InteractionMenu>().SetGameImage(gameSprite);
    }
}
