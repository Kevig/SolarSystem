using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
	protected override void OnUpdate()
	{
		Entities.ForEach((InputComponent inputComponent) => {
			this.inputListener(inputComponent);
		});
	}

	private void inputListener(InputComponent inputComponent) {
		inputComponent.getInput();
		//inputComponent.trackCursorMove();

		//if(Input.GetMouseButtonDown(0)) { inputComponent.mouseButtonDown(0); }
		//if(Input.GetMouseButtonDown(1)) { inputComponent.mouseButtonDown(1); }
		//if(Input.GetMouseButtonDown(2)) { inputComponent.mouseButtonDown(2); }

		//if(Input.GetMouseButtonUp(0)) { inputComponent.mouseButtonUp(0); }
		//if(Input.GetMouseButtonUp(1)) { inputComponent.mouseButtonUp(1); }
		//if(Input.GetMouseButtonUp(2)) { inputComponent.mouseButtonUp(2); }

	}
}
