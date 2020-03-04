using UnityEngine;
using System.Collections;

public class ScrDevelopment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioListener.pause = !AudioListener.pause;
        }


    }
}
