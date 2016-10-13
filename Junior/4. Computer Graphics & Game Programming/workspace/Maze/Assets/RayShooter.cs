using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

	private Camera camera;

	// Locks to camera view
	void Start () {
		camera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Shoots bullet upon click
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 origin = new Vector3 (camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
			Ray ray = camera.ScreenPointToRay (origin);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				StartCoroutine (Shoot (hit.point));    
			}
		}
	}

	// Bullets disappear after 1 second
	private IEnumerator Shoot(Vector3 position){
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = position;
		sphere.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
		yield return new WaitForSeconds (1);
		Destroy (sphere);
	}

//	Ray ray = new Ray(transform.position, transform.forward);
//	RaycastHit hit;
//	if (Physics.RayCast(ray, out hit)){
//		GameObject target = hit.transform.gameObject;
//	}
}