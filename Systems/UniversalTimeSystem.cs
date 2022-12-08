using Unity.Entities;
using UnityEngine;

[System.Serializable]
public class UniversalTimeSystem : ComponentSystem
{

	public static bool control = false;

	protected override void OnUpdate()
	{
		if(control) {
			Entities.ForEach((UniversalTimeComponent universalTime) => {
				universalTime.elapsedTime += Time.deltaTime;
				universalTime.updateTimeValues();
			});
		}
	}
}
