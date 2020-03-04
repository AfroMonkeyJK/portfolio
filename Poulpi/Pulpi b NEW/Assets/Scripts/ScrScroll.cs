using UnityEngine;
using System.Collections;

public class ScrScroll : MonoBehaviour {

    public float scrollSpeed = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
	
	}
}
