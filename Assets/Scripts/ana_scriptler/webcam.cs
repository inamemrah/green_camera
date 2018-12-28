using UnityEngine;
using System.Collections;

public class webcam : MonoBehaviour {
	public WebCamTexture wct;
	public GameObject cube;

	void Start () {
		wct = new WebCamTexture ();
		GetComponent<Renderer> ().material.mainTexture = wct;
		wct.Play ();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				Debug.Log ("Click position: " + hit.point);

				Color color = wct.GetPixel ((int)hit.textureCoord.x, (int)hit.textureCoord.y);
				Debug.Log ("Color x/y: " + color);
				cube.GetComponent<Renderer> ().material.color = color;
			}
		}
	}
}