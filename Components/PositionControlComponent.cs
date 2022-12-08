using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControlComponent : MonoBehaviour {

	public void setPosition(Vector3 position) {
		this.transform.position = position;
	}

}
