using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class colorPicker : MonoBehaviour {
	public WebCamTexture wct;

	public GameObject Plane; 
	public GameObject Color_asd;
	public Material shader;
	Camera cam;
	public bool look = false;
	public RawImage rawimage;






	void Start () {

	/*	cam = Camera.main;
		wct = new WebCamTexture ();
		GetComponent<Renderer> ().material.mainTexture = wct;
		wct.Play ();
*/
		cam = Camera.main;
		wct = new WebCamTexture();
		rawimage.texture = wct;
		rawimage.material.mainTexture = wct;
		wct.Play(); 

		Plane.GetComponent<Material> ().SetColor("_keyingColor", new Color(0,255,55,255));
		shader.SetColor ("_keyingColor", new Color(0,255,55,255));

	/*	if (PlayerPrefs.HasKey("_threshold"))
		{
			Plane.GetComponent<Material> ().SetFloat("_thresh", PlayerPrefs.GetFloat("_threshold"));
		}                                                               

		*/

	}



	public void Click()  // color select
	{
		if (look == false) {
			look = true;
		}
		else {
			look = false;
		}
	}



	void Update () {
		if (Input.GetMouseButtonDown(0) && look == true) {
			RaycastHit hit = new RaycastHit ();

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){

				GameObject hitobj = hit.transform.gameObject;
				Vector3 screenPos = cam.WorldToScreenPoint(hit.point);

				 //map coordinates to display resolution (e. g. 1920 x 1080)
				Debug.Log ("Click position relative to the screen size (e. g. 1920 x 1080) " + screenPos);

				Vector2 screenRatio = new Vector2(screenPos.x / Screen.width, screenPos.y / Screen.height);
				Color color = wct.GetPixel ( (int)(screenRatio.x * wct.width), (int)(screenRatio.y * wct.height) );
				Debug.Log ("Color x/y: " + color);

				Color_asd.GetComponent<Renderer> ().material.color = color;
			

				shader.SetColor ("_keyingColor", color);
				Plane.GetComponent<Material> ().SetColor("_keyingColor", color);
			

			}

		}


	}








	/*
	public void ColorSelect ()
	{
		if (look == false) {
			look = true;
		}
		if ( look == true) {
			look = false;
		}

		if (look = true) {

			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit = new RaycastHit ();

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {

					GameObject hitobj = hit.transform.gameObject;
					Vector3 screenPos = cam.WorldToScreenPoint (hit.point);

					// map coordinates to display resolution (e. g. 1920 x 1080)
					Debug.Log ("Click position relative to the screen size (e. g. 1920 x 1080) " + screenPos);

					Vector2 screenRatio = new Vector2 (screenPos.x / Screen.width, screenPos.y / Screen.height);
					Color color = wct.GetPixel ((int)(screenRatio.x * wct.width), (int)(screenRatio.y * wct.height));
					Debug.Log ("Color x/y: " + color);
					cube.GetComponent<Renderer> ().material.color = color;


					shader.SetColor ("_keyingColor", color);



				}
			}
		}
	}

	*/





}