using UnityEngine;
using System.Collections;

public class ScrPulpi : MonoBehaviour {

    public float velX = -5f;
    Vector2 movimiento = new Vector2();
    Rigidbody2D rb;
    bool inicializado = false;

    public Transform arma; // desde d´´onde disparamos
    public Transform bala;

    public float cadenciaMin = 1, cadenciaMax = 3; // tiempo entre disparos
    float crono = 0f;
    Renderer render;



    public int tipoIA = 1; // determina tipo de movimiento. Si es 0, lo hará aleatoriamente
    int totalIA = 4;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
        if (tipoIA == 0) tipoIA = Random.Range(1, totalIA + 1);
        crono = Random.Range(cadenciaMin, cadenciaMax); // Preparamos primer disparo
    }

    void Update()
    {
        if (render.EsVisibleDesde(Camera.main))
        { // Empieza a disparar si visible
            if (crono <= 0) Dispara();
            crono -= Time.deltaTime;

        }
    }

    void Dispara()
    {
        Transform b = Instantiate(bala, arma.position, arma.rotation) as Transform;
        b.Rotate(0, 0, Random.Range(-10, 10)); // modificamos trayectoria aleatoriamente
        crono = Random.Range(cadenciaMin, cadenciaMax); // Siguiente disparo
    }

    void FixedUpdate()
    {
        CalculoMovimiento(tipoIA);
        rb.velocity = movimiento;
       
    }

    void CalculoMovimiento(int metodo)
    {
        switch (metodo)
        {
            case 1:
                movimiento.x = velX;
                movimiento.y = 0;
                break;
            case 2:
                movimiento.x = velX / 2;
                movimiento.y = 0;
                break;
            case 3:
                if (!inicializado)
                {
                    movimiento.x=Random.Range(-10, -1); // establecemos velocidad la primera vez
                    inicializado = true;
                }
                movimiento.y = 1;
                break;
            case 4:
                float freq = 3f;
                float amplitud = 10f;
                movimiento.x = velX;
                movimiento.y = Mathf.Sin(Time.time * freq) * amplitud;

                break;
        }
    }

}
