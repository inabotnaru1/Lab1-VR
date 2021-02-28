using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEvent : MonoBehaviour
{
	private Color wasColor;
	bool collision;
	int count;
	GameObject mixedObject;
	GameObject sphere1, sphere2, sphere3, sphere4;
	string colorPallete;
	Color32 color1;



	void Start()
	{
		color1 = new Color32(127, 127, 127, 255);
		wasColor = GetComponent<Renderer>().material.color;
		collision = false;
		count = 0;

		mixedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		mixedObject.active = false;

		sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere1.active = true;
		sphere1.transform.position = new Vector3(-2, 2, -3);
       	var sphere1Render = sphere1.GetComponent<Renderer>();
		sphere1Render.name = "Sphere1";
       	sphere1Render.material.SetColor("_Color", Color.blue);

		sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere2.active = true;
		sphere2.transform.position = new Vector3(2, 2, -3);
       	var sphere2Render = sphere2.GetComponent<Renderer>();
		sphere2Render.name = "Sphere2";
       	sphere2Render.material.SetColor("_Color", Color.yellow);

		sphere3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere3.active = true;
		sphere3.transform.position = new Vector3(-4, 2, -3);
       	var sphere3Render = sphere3.GetComponent<Renderer>();
		sphere3Render.name = "Sphere3";
       	sphere3Render.material.SetColor("_Color", Color.black);

		sphere4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere4.active = true;
		sphere4.transform.position = new Vector3(4, 2, -3);
       	var sphere4Render = sphere4.GetComponent<Renderer>();
		sphere4Render.name = "Sphere4";
       	sphere4Render.material.SetColor("_Color", Color.white);
		

	}

	void Update()
	{
		mixedObject.transform.position = new Vector3(0, 2, -3);
		var mixedSphere = mixedObject.GetComponent<Renderer>();
		
		if(Input.GetButtonDown ("Fire1")){
        	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        	RaycastHit hit;
         	if(Physics.Raycast (ray, out hit)){
             	Debug.Log (hit.collider.gameObject.name);
				GetComponent<PlayerLog>().AddEvent("Hit " + hit.collider.gameObject.name);
					switch (hit.collider.gameObject.name)
					{
					case "Sphere1":
						colorPallete = colorPallete + "blue";
						break;
					case "Sphere2":
						colorPallete = colorPallete  + "yellow";
						break;
					case "Sphere3":
						colorPallete = colorPallete  + "black";
						break;
					case "Sphere4":
						colorPallete = colorPallete  + "white";
						break;
					default:
						// print ("Mai incearca.");
						break;
					} 
			// Debug.Log(colorPallete); 
			count++;
			if (count == 2){
				switch (colorPallete)
					{
					case "blueyellow":
						// gameObject.GetComponent<Renderer>().material.color new Color(233, 79, 55);
						mixedSphere.material.SetColor("_Color", Color.green);
						// Debug.Log("A new color was created: " +  mixedSphere.material.color + "\n");
						mixedObject.active = true;
						break;
					case "yellowblue":
						mixedSphere.material.SetColor("_Color", Color.green);
						mixedObject.active = true;
						break;
					case "blackwhite":
						mixedSphere.material.SetColor("_Color", Color.gray);
						mixedObject.active = true;
						break;
					case "whiteblack":
						mixedSphere.material.SetColor("_Color", Color.gray);
						mixedObject.active = true;
						break;
					case "yellowblack":
						mixedSphere.material.SetColor("_Color", Color.green);
						mixedObject.active = true;
						break;
					case "blackyellow":
						mixedSphere.material.SetColor("_Color", Color.green);
						mixedObject.active = true;
						break;
					case "bluewhite":
						mixedSphere.material.SetColor("_Color", Color.cyan);
						mixedObject.active = true;
						break;
					case "whiteblue":
						mixedSphere.material.SetColor("_Color", Color.cyan);
						mixedObject.active = true;
						break;
					case "whiteyellow":
						mixedSphere.material.SetColor("_Color", Color.clear);
						mixedObject.active = true;
						break;
					case "yellowwhite":
						mixedSphere.material.SetColor("_Color", Color.clear);
						mixedObject.active = true;
						break;
					default:
						print ("Imposible to make such a pallete");
						break;
					} 
				count = 0;
				colorPallete ="";
			}
				
			}
         }
     
		
	
		// if (Input.GetButtonDown("Fire1"))
		// {
		// 	GetComponent<PlayerLog>().AddEvent("Fire2");
		// 	RaycastHit hitInfo = new RaycastHit();
        //  	bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
		// 	if (hit){
		// 		GetComponent<PlayerLog>().AddEvent("Hit " + hitInfo.transform.gameObject.name);
		// 		if (hitInfo.transform.gameObject.name == "Sphere"){
		// 			Debug.Log(gameObject.material.SetColor("_Color"));
		// 			count++;	
		// 		}	
		// 	}
		// 	if(count == 2) {
		// 		mixedObject.transform.position = new Vector3(0, 2, -3);
		// 		mixedObject.active = true;
       	// 		var mixedSphere = mixedObject.GetComponent<Renderer>();
       	// 		//Call SetColor using the shader property name "_Color" and setting the color to red
      	// 		 mixedSphere.material.SetColor("_Color", Color.green);
		// 		GetComponent<PlayerLog>().AddEvent("Counted");
		// 	}
		// 	if (collision){
		// 		ChangeClickColor();
		// 	}
			
		// }	
	}

	public void ChangeColor()
	{
		GetComponent<Renderer>().material.color = Color.blue;
		collision = true;
	}

	public void ChangeBackColor()
	{
		GetComponent<Renderer>().material.color = wasColor;
		collision = false;
	}

	public void ChangeClickColor()
	{
		GetComponent<Renderer>().material.color = Color.green;
	}
}
