using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuanKontrol : MonoBehaviour
{
    public Text kolayPuan;
    public Text kolayAltin;
    public Text ortaPuan;
    public Text ortaAltin;
    public Text zorPuan;
    public Text zorAltin;

    // Start is called before the first frame update
    void Start()
    {
        kolayPuan.text = "Puan: " + Secenekler.KolayPuanDegerOku();
        kolayAltin.text = " X " + Secenekler.KolayAltinDegerOku();
        ortaPuan.text = "Puan: " + Secenekler.OrtaPuanDegerOku();
        ortaAltin.text = " X " + Secenekler.OrtaAltinDegerOku();
        zorPuan.text = "Puan: " + Secenekler.ZorPuanDegerOku();
        zorAltin.text = " X " + Secenekler.ZorAltinDegerOku();
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
