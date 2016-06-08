using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();

    }

    void HandleInput()
    {
        //If right click
        if (Input.GetMouseButtonDown(1))
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //On Right mouse click
            if (Physics.Raycast(screenRay, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name + " RIGHT CLICK ");
            }

        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //On Left mouse click
            if (Physics.Raycast(screenRay, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name + " LEFT CLICK ");
            }
        }
    }
}