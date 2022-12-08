using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCameraZoom {

	public ActionCameraZoom(int direction) {
		if(direction != 0) {
			ZoomControlComponent control = GameObject.Find("Main Camera").GetComponent("ZoomControlComponent") as ZoomControlComponent;
			control.zoom(direction);
		}
	}

	public static bool checkRequirements(InputControl input) {
		return (input.state != InputState.None);
	}

}
