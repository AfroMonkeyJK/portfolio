using UnityEngine;
using System.Collections;

public class ScrPlayer : MonoBehaviour {

    public float velocidad = 5f;
    Vector2 movi = new Vector2();
    Rigidbody2D rb;
    float cadencia = 0.325f;
    float crono = 0f;

    public Transform disparo; // elemento a instanciar. Arrastramos bala 
    public Transform[] armas;    // De donde sale el proyectil
    AudioSource sonido;

    // márgenes del espacio de movimiento de la nave
    public int mLeft = 25, mRight = 225, mTop = 25, mBottom = 25;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Damos valor a rb
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        movi.x = ETCInput.GetAxis("Horizontal") * velocidad;  // Leemos joystick
        movi.y = ETCInput.GetAxis("Vertical") * velocidad;
        if (ETCInput.GetButton("Shot") && crono <=0) Dispara(); // Shot ha de coincidir amb el nom!
        // Si la siguiente linea activada permite disparo rapido con multiples clicks
        // en caso contrario tambien le afectara la cadencia
        //if (ETCInput.GetButtonUp("Shot")) crono = 0f;  

        crono -= Time.deltaTime;

        // Calculamos coordenada en pantalla
        Vector3 posi = Camera.main.WorldToScreenPoint(transform.position);
        // y restringimos movimiento
        if (posi.x < mLeft && movi.x < 0) movi.x = 0;
        if (posi.x > Screen.width - mRight && movi.x > 0) movi.x = 0;
        if (posi.y < mBottom && movi.y < 0) movi.y = 0;
        if (posi.y > Screen.height - mTop && movi.y > 0) movi.y = 0;
    }

    void FixedUpdate()
    {
        rb.velocity = movi; //Aplicamos velocidad. No usar Translate (usamos fisicas!)
    }

    void Dispara()
    {
        crono = cadencia;
        sonido.Play();
        foreach (Transform arma in armas)
        {
            if (arma.gameObject.activeSelf)
                Instantiate(disparo, arma.position, arma.rotation);

        }
    }

        void Destruye()
    {
        Destroy(gameObject);
    }


}
