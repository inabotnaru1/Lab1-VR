using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton1))
	{
		//Debug.Log("Space");
		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}   

    	if (Input.GetKey(KeyCode.X))
	{
		//Debug.Log("");
		transform.Translate(Vector3.up * -Time.deltaTime, Space.World);
	}   

    	if (Input.GetButtonDown("Fire1"))
	{
		//Debug.Log(Selection.activeObject);
		//transform.Translate(Vector3.left * Time.deltaTime, Space.World);
	}   

	float Horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * 90;
	float Vertical = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

	transform.Rotate(0, Horizontal, 0);

	//var forward = transform.TransformDirection(Vector3.forward);
	//float curSpeed = Vertical;
	transform.Translate(Vector3.forward * Vertical, Space.World);
    }
}
