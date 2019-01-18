using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah : MonoBehaviour
{
    public string isim;
    public int mermiSayisi;
    public int sarjor;
    public float atesHizi;
    float aktifSure;
    public bool atesEder = false;

    void Start()
    {
        aktifSure = atesHizi;
        atesEder = false;
    }

    // Update is called once per frame
    void Update()
    {
        aktifSure -= Time.deltaTime;

        //eger mouse ile o yani sol tusa basarsak
        if (Input.GetMouseButton(0))
        {
            if (aktifSure <= 0)
            {
                atesEder = true;

                //mermi sayisi azalsin
                mermiSayisi--;
                aktifSure = atesHizi;
            }
            //eger mermi sayisi 0 olursa yani biterse
            if (mermiSayisi <=0)
            {
                //burada sarjor animasyonu olabilir mermiyi yenileyecegiz
                //sonrada mermi sayisi sarjor sayisina esit olacak
                mermiSayisi = sarjor;
            }

        }
    }
}
