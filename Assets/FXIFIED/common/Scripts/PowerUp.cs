using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int type;
    public GameObject pickupEffect;
    public GameObject thingToOpen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        ServiceLocator.GetService<VibrationManager>().MakeVibration(0.2f);
        if (type == 0)
        {
            ServiceLocator.GetService<GameInfoHandler>().AddMoney();
        }
        else
        {
            thingToOpen.SetActive(true);
        }
        Destroy(gameObject);
    }
}
