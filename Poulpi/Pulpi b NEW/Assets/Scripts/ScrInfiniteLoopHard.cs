using UnityEngine;
using System.Collections;

public class ScrInfiniteLoopHard : MonoBehaviour {
    bool visible;
    Renderer render;
    void Start()
    {
        render = GetComponent<Renderer>();
        if (render.EsVisibleDesde(Camera.main)) visible = true; // inicialmente visible?
        else visible = false;
    }
    void Update()
    {
        // si desaparece por la izquierda…
        if (visible && render.EsVisibleDesde(Camera.main) == false)
        { // lo trasladamos a la derecha
            transform.Translate(20.48f * 3, 0f, 0f);
            visible = false;
        }
        // si aparece por la derecha
        if (!visible && GetComponent<Renderer>().EsVisibleDesde(Camera.main) == true)
            visible = true; // lo marcamos como visible
    }
}
