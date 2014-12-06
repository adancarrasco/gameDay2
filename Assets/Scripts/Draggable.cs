using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            var pos = Input.mousePosition;
            pos.z = 1;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = pos;
        }
	}
}
