using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour {
  
	public RotationControlComponent cameraRotationControl;
	public Vector3 cursorPosition;	
	public float holdThreshold;
	public List<InputControl> inputs;

	public void Start()	{
		InputControl.inputComponent = this;
		InputControl.holdThreshold = this.holdThreshold;
		this.cameraRotationControl = GameObject.Find("CameraRotationObject").GetComponent("RotationControlComponent") as RotationControlComponent;
		
		InputControl leftMouse = this.gameObject.AddComponent<InputControl>();
		leftMouse.set(InputType.Key, "mouse 0", new Action(ActionType.CameraRotate,
									RotateAround.Target, RotateDirection.Cursor));

		InputControl leftMouseClick = this.gameObject.AddComponent<InputControl>();
		leftMouseClick.set(InputType.Key, "mouse 0", new Action(ActionType.SelectObject,
									ObjectSpace.World));

		InputControl rightMouse = this.gameObject.AddComponent<InputControl>();
		rightMouse.set(InputType.Key, "mouse 1", new Action(ActionType.CameraRotate,
									RotateAround.Self, RotateDirection.Cursor));

		InputControl mouseScroll = this.gameObject.AddComponent<InputControl>();
		mouseScroll.set(InputType.Axis, "mouse scroll", new Action(ActionType.CameraZoom));

		this.inputs.Add(leftMouse);
		this.inputs.Add(leftMouseClick);
		this.inputs.Add(rightMouse);
		this.inputs.Add(mouseScroll);
	}

	public void getInput() {
		foreach(InputControl input in this.inputs) {
			input.listen();
		}
	}

}
