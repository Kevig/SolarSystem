
using DataType;
using UnityEngine;

public class SpatialRotationComponent : SpatialRotation {

	public GameObject target { get; set; } = null;

	public void rotate() {
		if(this.target != null) { this.gameObject.transform.position = this.target.transform.position; }
		base.doRotate();
	}

}