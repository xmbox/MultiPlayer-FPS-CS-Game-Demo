using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//network islemleri icin network sinifi ekliyorum
using UnityEngine.Networking;

public class Controller : NetworkBehaviour
{
    public float hiz;
    public float hassas;
    float xMouse;
    float yMouse;
    float sinir;
    public Camera kameram;

    Vector3 hareketVector;

    string id;

    public override void OnStartClient()
    {
        //oyun basladiginda kullanici idlerini aliyoruz
        id = GetComponent<NetworkIdentity>().netId.ToString();
        Debug.Log(id);
        OyunBilgisi.tumOyuncular.Add(id, this.gameObject);

        Debug.Log (OyunBilgisi.tumOyuncular[id]);
    }

    void Start()
    {
        //aktif oyuncunun kamerasi degilse false yap diyorum
        if (!isLocalPlayer)
        {
            kameram.enabled = false;
        }
        //degilse giris ekranindaki acilis kamerasini kapatiyorum
        else
        {
            GameObject.FindGameObjectWithTag("kapat").SetActive(false);
        }
    }


    void Update()
    {
        //isLocalPlayer = eger oynayan benim karakterimse bu islemleri yap diyorum
        if (isLocalPlayer)
        {
            HareketHiz();
            HareketYon();
        }

    }

    void HareketHiz()
    {
        // karakterin x ekseninde saga ve sola hareketini kontrol edelim
        float xyonu = Input.GetAxis("Horizontal");
        // karakterin z ekseninde ileri ve geri hareketini kontrol edelim
        float zyonu = Input.GetAxis("Vertical");

        //karakterin bulundugu pozisyondan yeni bir haraket verelim
        //ama karakterin onu nereye bakiyorsa oraya gitmesini istedigimiz icin bunu kullanmayalim
        //transform.position += new Vector3(xyonu, 0, zyonu) * hiz;

        //karakterimin sagi nereyse o yone gitsin
        Vector3 xVec = transform.right * xyonu;
        //karakterimin onu nereye bakiyorsae o yone gitsin
        Vector3 zVec = transform.forward * zyonu;

        hareketVector = (xVec + zVec) * hiz;
    }

    void HareketYon()
    {
        //kameramizin mouse haraketi ile yukari asagi saga sola bakmasini yapalim
        xMouse = Input.GetAxis("Mouse X") * hassas; // karakterin y rotasyonunu degistiriyoruz
        yMouse = Input.GetAxis("Mouse Y") * hassas; // burada ise kameranin x rotasyonunu degistiriyoruz
    }

    private void FixedUpdate()
    {
        transform.position += hareketVector * Time.fixedDeltaTime;
        transform.Rotate(new Vector3(0, xMouse, 0));
        //Camera.main.transform.Rotate(new Vector3(yMouse, 0, 0));
        kameram.transform.Rotate(new Vector3(yMouse * (-1), 0, 0));

        //kamera acisini yukari asagi harekette sinirlayalim
        sinir -= yMouse;
        sinir = Mathf.Clamp(sinir, -50f, 50f);
        kameram.transform.localEulerAngles = new Vector3(sinir, 0, 0);
    }
}
