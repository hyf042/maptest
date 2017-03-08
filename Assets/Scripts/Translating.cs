using UnityEngine;
using System.Collections;

public class Translating : MonoBehaviour {

	public float speed = 10.0f;
	public Vector3 startPoint = Vector3.zero;
	public Vector3 endPoint = Vector3.zero;
	public Vector3 lookAt = Vector3.zero;
	public bool pingpong = true;

  private bool isEnabled = false;
	private Vector3 curEndPoint = Vector3.zero;

	// Use this for initialization
	void Start () {
		transform.position = startPoint;
		curEndPoint = endPoint;
	}
	
	// Update is called once per frame
	void Update () {
    if (isEnabled) {
      return;
    }
		transform.position = Vector3.Slerp(transform.position, curEndPoint, Time.deltaTime * speed);
		transform.LookAt(lookAt);
		if (pingpong) {
			if (Vector3.Distance(transform.position, curEndPoint) < 0.001f) {
				curEndPoint = Vector3.Distance(curEndPoint, endPoint) < Vector3.Distance(curEndPoint, startPoint) ? startPoint : endPoint;
			}
		}
	}

  void OnGUI() {
    if (GUI.Button(new Rect(10, 10, 100, 50), "Pingpong")) {
      isEnabled = !isEnabled;
    }
  }
}
