using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[System.Serializable]
public class InputControl : MonoBehaviour {

	public static InputComponent inputComponent;
	public static float holdThreshold;
	
	public InputType type;
	public string id;
	public InputState state, previousState;
	public Action action;
	public Coroutine holdTimer;
	
	public bool stateChanged = false;

	public void set(InputType type, string id, Action action) {
		this.type = type;
		this.id = id;
		this.state = InputState.None;
		this.action = action;
		this.holdTimer = null;
	}

	public void listen() {
		
		if(this.type == InputType.Axis) {
			if(this.id.Equals("mouse scroll")) {
				float mouseScrollDirection = Input.mouseScrollDelta.y;
				if(mouseScrollDirection != 0) {
					this.action.zoomDirection = (int) mouseScrollDirection;
					this.action.execute();
				}
			}
		}

		if(this.type == InputType.Key) {
			if(Input.GetKeyDown(this.id) && this.state != InputState.Down) {
				this.stateChanged = true;
				this.previousState = this.state;
				this.state = InputState.Down;
				if(this.holdTimer != null) { StopCoroutine(this.holdTimer); }
				this.holdTimer = StartCoroutine(this.hold());
			}

			if(Input.GetKeyUp(this.id) && this.state != InputState.Up) {
				this.stateChanged = true;
				this.previousState = this.state;
				this.state = InputState.Up;
				if(this.holdTimer != null) { StopCoroutine(this.holdTimer); }
				this.holdTimer = null;
			}

			if(this.stateChanged || this.state == InputState.Hold) {
				this.stateChanged = false;
				if(this.checkActionRequirements()) {
					this.action.execute();
				}
			}
		}
	}

	private IEnumerator hold() {
		yield return new WaitForSeconds(InputControl.holdThreshold);
		if(this.state == InputState.Down) {
			this.state = InputState.Hold;
		}
	}

	private bool checkActionRequirements() {
		return this.action.checkRequirements(this);
	}
}
