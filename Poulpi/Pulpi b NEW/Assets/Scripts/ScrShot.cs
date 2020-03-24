using UnityEngine;
using System.Collections;

public class ScrShot : MonoBehaviour {

    public float vel = 20f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
    
   void Destruye()
    {
        Destroy(gameObject);
    }


}
