using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectObject {

	public ActionSelectObject(ObjectSpace objectSpace) {
		if(objectSpace == ObjectSpace.World) {
			ClickData clickData = ClickData.get();
			GameObject target = null;
			if(clickData != null) { target = clickData.gameObject; }
			(GameObject.Find("Test_Manager").GetComponent<CelestialBodyTesting>()).selected = target;
		}
	}

	public static bool checkRequirements(InputControl input) {
		return (input.state == InputState.Up && input.previousState != InputState.Hold);
	}

}
