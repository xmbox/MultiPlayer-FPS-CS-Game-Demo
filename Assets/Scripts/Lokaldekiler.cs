using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// localplayer degerine ulasmak icin networkbehaviour yaziyoruz
public class Lokaldekiler : NetworkBehaviour
{
    public GameObject[] lokalde;

    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (var item in lokalde)
            {
                item.SetActive(false);
            }
        }
    }

}
