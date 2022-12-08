using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action {
	public ActionType type;
	public RotateAround rotateAround;
	public RotateDirection rotateDirection;
	public ObjectSpace objectSpace;
	public int zoomDirection;

	public Action(ActionType type) {
		this.type = type;
		this.zoomDirection = 0;
		this.rotateAround = RotateAround.None;
		this.rotateDirection = RotateDirection.None;
	}

	public Action(ActionType type, ObjectSpace objectSpace) {
		this.type = type;
		this.objectSpace = objectSpace;
	}

	public Action(ActionType type, RotateAround around, RotateDirection direction) {
		this.type = type;
		this.rotateAround = around;
		this.rotateDirection = direction;
	}
	
	public bool checkRequirements(InputControl input) {
		switch(this.type) {
			case ActionType.CameraRotate:
				return ActionCameraRotate.checkRequirements(this.rotateDirection, input);
			case ActionType.CameraZoom:
				return ActionCameraZoom.checkRequirements(input);
			case ActionType.SelectObject:
				return ActionSelectObject.checkRequirements(input);
			default:
				return false;
		}
	}

	public void execute() {
		switch(this.type) {
			
			case ActionType.CameraRotate:
				new ActionCameraRotate(this.rotateAround, this.rotateDirection);
				break;
			
			case ActionType.CameraZoom:
				new ActionCameraZoom(this.zoomDirection);
				this.zoomDirection = 0;
				break;
			
			case ActionType.SelectObject:
				new ActionSelectObject(this.objectSpace);
				break;
			
			default: // No Action type, no action
				break;
		}
	}
}
