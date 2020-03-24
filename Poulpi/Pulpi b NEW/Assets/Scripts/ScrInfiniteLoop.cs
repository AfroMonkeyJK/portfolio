using UnityEngine;
using System.Collections;

public class ScrInfiniteLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        // la imagen mide 2048 pixels, y hay 3
        transform.Translate(20.48f * 3, 0f, 0f);
    }
}
