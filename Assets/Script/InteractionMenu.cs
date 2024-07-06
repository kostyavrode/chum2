using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class InteractionMenu : MonoBehaviour
{
    public GameObject menuObject;
    public Image[] images;
    public int[] rightPositions;
    public int gameType;
    public Image targetImage;
    public Image bgImage;
    public int currentImageNum;
    public GameObject completeButton;
    private GameObject DoorToOpen;
    private void OnEnable()
    {
        currentImageNum = 0;
        targetImage = images[currentImageNum];
        ShakeImages();
        completeButton.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (menuObject.activeSelf)
        CheckPositions();
    }
    public void TurnGameMenu(bool b)
    {
        menuObject.SetActive(b);
    }
    public void SetGameImage(Sprite sprite,Sprite bg,GameObject door)
    {
        foreach (Image item in images)
        {
            item.sprite = sprite;
        }
        bgImage.sprite = bg;
        DoorToOpen=door;
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
    public void CompleteButton()
    {
        menuObject.SetActive(false);
        DoorToOpen.transform.DOLocalRotate(new Vector3(0, -290, 0), 1f);
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
