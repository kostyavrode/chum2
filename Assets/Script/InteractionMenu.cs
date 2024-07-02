using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionMenu : MonoBehaviour
{
    public Image[] images;
    public int gameType;
    public Image targetImage;
    public int currentImageNum;
    private void OnEnable()
    {
        currentImageNum = 0;
        targetImage = images[currentImageNum];
        Debug.Log("GameStarted");
    }
    public void NextImage()
    {
        if (currentImageNum+2<=images.Length)
        {
            currentImageNum+=1;
            targetImage = images[currentImageNum];
        }
    }
    public void PreviousImage()
    {
        if (currentImageNum>=1)
        {
            currentImageNum-=1;
            targetImage = images[currentImageNum];
        }
    }
    public void RotateLeft()
    {
        targetImage.transform.Rotate(new Vector3(0,0,1), 10);
    }
    public void RotateRight()
    {
        targetImage.transform.Rotate(new Vector3(0, 0, -1), 10);
    }
}
