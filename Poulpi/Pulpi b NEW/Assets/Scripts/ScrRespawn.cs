using UnityEngine;
using System.Collections;

public class ScrRespawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool respawnable = true; // hay que generarlo de nuevo?
    public float minX = 50f, maxX = 65f, minY = -9, maxY = 9;
    void OnBecameInvisible()
    {
        if (respawnable)
        {
            float x = Random.Range(minX, maxX); // Cuanto tiramos hacia atras
            float y = Random.Range(minY, maxY); // A que altura
            Vector3 posi = new Vector3(transform.position.x + x, y,
            transform.position.z);
            transform.position = posi;
        }
        else Destroy(gameObject);
    }
}
