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
    public GameObject completeButton;
    private void OnEnable()
    {
        currentImageNum = 0;
        targetImage = images[currentImageNum];
        ShakeImages();
    }
    private void FixedUpdate()
    {
        CheckPositions();
    }
    public void SetGameImage(Sprite sprite)
    {
        foreach (Image item in images)
        {
            item.sprite = sprite;
        }
    }
    private void ShakeImages()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].transform.Rotate(new Vector3(0, 0, 1), (10 * UnityEngine.Random.Range(1,35)));
        }
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
            completeButton.SetActive(true);
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
