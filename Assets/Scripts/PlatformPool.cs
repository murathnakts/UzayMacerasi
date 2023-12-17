using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;
    [SerializeField]
    GameObject olumculPlatformPrefab = default;
    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPozision;
    Vector2 playerPozision;

    [SerializeField]
    float platformArasiMesafe = default;

    bool yon = true;

    // Start is called before the first frame update
    void Start()
    {
        PlatformUret();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }
    
    void PlatformUret()
    {
        platformPozision = new Vector2(0, 0);
        playerPozision = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab,playerPozision,Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefab,platformPozision,Quaternion.identity);
        player.transform.parent = ilkPlatform.transform;
        platforms.Add(ilkPlatform);
        SonrakiPlatformPozisyon();
        ilkPlatform.GetComponent<Platform>().Hareket = true;

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPozision, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true;
            if(i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatformPozisyon();
        }

        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozision, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiPlatformPozisyon();
    }

    void PlatformYerlestir()
    {
        for (int i = 0;i < 5;i++) 
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPozision;
            if(platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Altin>().AltiniKapat();   
                float rastAltin = Random.Range(0.0f, 1.0f);
                if(rastAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }
            SonrakiPlatformPozisyon();
        }
    }

    void SonrakiPlatformPozisyon()
    {
        platformPozision.y += platformArasiMesafe;
        SiraliPozisyon();
    }

    void KarmaPozisyon()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPozision.x = EkranHesaplayicisi.instance.Genislik / 2;
        }
        else
        {
            platformPozision.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }
    }

    void SiraliPozisyon()
    {
        if(yon)
        {
            platformPozision.x = EkranHesaplayicisi.instance.Genislik / 2;
            yon = false;
        } else
        {
            platformPozision.x = -EkranHesaplayicisi.instance.Genislik / 2;
            yon = true;
        }
    }
}
