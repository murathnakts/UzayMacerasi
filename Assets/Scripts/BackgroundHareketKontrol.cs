using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHareketKontrol : MonoBehaviour
{
    float backgroundKonum;
    float mesafe = 10.24f;

    // Start is called before the first frame update
    void Start()
    {
        backgroundKonum = transform.position.y;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(backgroundKonum);
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundKonum + mesafe < Camera.main.transform.position.y)
        {
            BackgroundYerlestir();
        }
    }

    void BackgroundYerlestir()
    {
        backgroundKonum += (mesafe * 2);
        FindObjectOfType<Gezegenler>().GezegenYerlestir(backgroundKonum);
        Vector2 newPos = new Vector2(0,backgroundKonum);
        transform.position = newPos;
    }
}
