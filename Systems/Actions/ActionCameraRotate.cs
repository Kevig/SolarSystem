using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCameraRotate {
  
	static ActionCameraRotate() {
		
	}

	public ActionCameraRotate(RotateAround around, RotateDirection direction) {
		
		Vector3 axis;

		switch(direction) {
			case RotateDirection.Up: axis = new Vector3(1,0,0); break;
			case RotateDirection.Down: axis = new Vector3(-1,0,0); break;
			case RotateDirection.Left: axis = new Vector3(0,1,0); break;
			case RotateDirection.Right: axis = new Vector3(0,-1,0); break;
			case RotateDirection.Cursor: axis = this.getCursorMovementAxis(around); break;
			default: axis = Vector3.zero; break;
		}

		GameObject rotationPoint;
		if(around == RotateAround.Target) {
			rotationPoint = GameObject.Find("CameraRotationObject");
		} else {
			rotationPoint = GameObject.Find("Main Camera");
		}

		RotationControlComponent control = rotationPoint.GetComponent("RotationControlComponent") as RotationControlComponent;
		control.rotate(axis);
	}

	public static bool checkRequirements(RotateDirection direction, InputControl input) {
		if(direction == RotateDirection.Cursor) {
			if(input.state == InputState.Hold) {
				Cursor.lockState = CursorLockMode.Locked;
				return true;
			} else {
				Cursor.lockState = CursorLockMode.None;
				return false;
			}
		} else {
			return (input.state == InputState.Up && input.previousState == InputState.Down);
		}
	}

	private Vector3 getCursorMovementAxis(RotateAround rotateAround) {
		Vector3 axis;
		if(rotateAround == RotateAround.Target) {
			axis = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		} else if(rotateAround == RotateAround.Self) {
			axis = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		} else {
			axis = Vector3.zero;
		}
		return axis;
	}
}
