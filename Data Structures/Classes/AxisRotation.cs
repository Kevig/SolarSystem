using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AxisRotation {
 public int direction;
 public float step;
 public float scalar;

	public AxisRotation(int direction, float step, float scalar) {
		this.direction = direction;
		this.step = step;
		this.scalar = scalar;
	}

}
