using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlComponent : MonoBehaviour {

	public float scale;
	public bool animate = false;
	public Vector3 targetRotation;

	public void rotate(Vector3 direction) {
		direction = direction * this.scale;
		this.gameObject.transform.Rotate(direction * Time.deltaTime, Space.Self);
	}

	public void zeroRotation() {
		this.targetRotation = Vector3.zero;
		StartCoroutine(this.animatedRotation());
	}

	public void Update() {
		//if(animate) {
		//	this.transform.localEulerAngles = Vector3.Lerp(this.transform.localEulerAngles,
		//																								 this.targetRotation,
		//																								 Time.deltaTime * 2f);
		//	if(this.transform.localEulerAngles == (this.targetRotation + new Vector3(0.1f, 0.1f, 0.1f))) {
		//		this.animate = false;
		//	}
		//}
	}

	public IEnumerator animatedRotation() {
		if(this.transform.eulerAngles != this.targetRotation) {
			this.transform.eulerAngles = Vector3.Slerp(this.transform.eulerAngles,
																										 this.targetRotation,
																										 Time.deltaTime * 2f);
			yield return null;
		}
	}

}
