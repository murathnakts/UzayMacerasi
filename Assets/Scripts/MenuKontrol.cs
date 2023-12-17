using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] muzikIkonlar = default;
    [SerializeField]
    Button muzikButton = default;
    // Start is called before the first frame update
    void Start()
    {
        if(Secenekler.KayitVarmi() == false)
        {
            Secenekler.KolayDegerAta(1);
        }

        if (Secenekler.MuzikKayitVarmi() == false)
        {
            Secenekler.MuzikDegerAta(1);
        }

        MuzikAyarlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    } 
    
    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }
    
    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if (Secenekler.MuzikDegerOku() == 1 )
        {
            Secenekler.MuzikDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            muzikButton.image.sprite = muzikIkonlar[0];
        } else
        {
            Secenekler.MuzikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButton.image.sprite = muzikIkonlar[1];
        }
    }

    void MuzikAyarlariniDenetle()
    {
        if(Secenekler.MuzikDegerOku() == 1)
        {
            muzikButton.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        }
        else
        {
            muzikButton.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }
}
 