using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AtesEt : NetworkBehaviour
{
    public GameObject kameram;
    public Silah silah;
    public GameObject kanak;

    //[SyncVar] // bu ifade ile sunucu bu degeri tum clientlarda guncel tutulmasini sagliyor
    //public float can;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && silah.atesEder)
        {
            RaycastHit hit;

            if (Physics.Raycast(kameram.transform.position, kameram.transform.forward, out hit, 30f))
            {
                if (hit.collider.tag == "Player")
                {

                    Debug.Log("Vuruldu");
                    //dusman kim = hit.transform.gameObject yani mermi kime carptiysa onun oyun objesi
                    CmdHasar(hit.transform.gameObject);
                    CmdKanEfekt(hit.point);
                }
            }
        }
    }

    [Command] // yazinca fonksiyona da Cmd_ eklememiz lazim

    void CmdHasar(GameObject dusman)
    {
        dusman.GetComponent<Oyuncu>().can /= 2;
    }

    [Command]

    void CmdKanEfekt(Vector3 position)
    {
        RpcKanEfekt(position);
    }

    
    [ClientRpc]

    void RpcKanEfekt(Vector3 position)
    {
        //kan efekti olusturuyorum
        GameObject yeniKanak = Instantiate(kanak, position, Quaternion.identity);
        Destroy(yeniKanak, 1.5f);
    }

    //[Command] // islemlerin sadece sunucu tarafinda gerceklesmesini istiyorsak kullaniyoruz.
    //[ClientRpc] //tum clientlerde kullanicilarda calistirmak icin kullaniyoruz
    //[SyncVar] //uygulamak istedigimiz degiskenden once yaziyoruz
}
