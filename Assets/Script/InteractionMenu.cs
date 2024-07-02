using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionMenu : MonoBehaviour
{
    public Image[] images;
    public int[] rightPositions;
    public int gameType;
    public Image targetImage;
    public int currentImageNum;
    private void OnEnable()
    {
        currentImageNum = 0;
        targetImage = images[currentImageNum];
    }
    private void FixedUpdate()
    {
        CheckPositions();
    }
    private void CheckPositions()
    {
        int t = 0;
        for (int i = 0; i < rightPositions.Length; i++)
        {
            Debug.Log(Math.Round(images[i].transform.eulerAngles.z));
            if (rightPositions[i] == Math.Round(images[i].transform.eulerAngles.z))
            {
                t += 1;
                
            }
        }
        if (t==rightPositions.Length)
        {
            Debug.Log("RIGHT"+rightPositions.Length);
        }
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
