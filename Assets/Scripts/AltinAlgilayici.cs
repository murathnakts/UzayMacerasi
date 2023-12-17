using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ayaklar")
        {
            GetComponentInParent<Altin>().AltiniKapat();
            FindObjectOfType<Puan>().AltinKazan();
        }
    }
}
