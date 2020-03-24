/************************************************************
 * Script aplicable a todo aquello susceptible de morir
 * ***********************************************************/
 
using UnityEngine;
using System.Collections;
using System;



public class ScrControlVida : MonoBehaviour {

    public float vitalidad = 2f;
    public Transform explosion;

    public AudioClip tocado, hundido;
    public string[] nomProjectil;
    Renderer r;

    void Start()
     {
        r = GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (Array.IndexOf (nomProjectil, otro.tag) >-1 && r.EsVisibleDesde(Camera.main))
        {  // Es un disparo del player
            float danyo = otro.GetComponent<ScrDanyo>().danyo;  // qué daño causa?
            vitalidad -= danyo;     // disminuimos la fuerza
            if (vitalidad <= 0) Destruye(); // si fin de vida, lo destruye
            else AudioSource.PlayClipAtPoint(tocado, Camera.main.transform.position);
            // Destroy(otro.gameObject);       // destruimos el disparo
            otro.SendMessage("Destruye", SendMessageOptions.DontRequireReceiver);
        }
    }

    void Destruye()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(hundido, Camera.main.transform.position);
        Destroy(gameObject);
    }


}
