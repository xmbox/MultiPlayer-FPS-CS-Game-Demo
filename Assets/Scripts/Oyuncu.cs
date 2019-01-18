using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Oyuncu : NetworkBehaviour
{
    [SyncVar] // bi alttaki degiskenin bilgisini tutuyor
    public int can = maxCan;

    //degisitirilemez bir yapi olarak degeri const ile sabitliyoruz
    public const int maxCan = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
