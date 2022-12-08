using Unity.Entities;
using UnityEngine;

public class SpatialRotationSystem : ComponentSystem {

	public static bool control = false;

	protected override void OnUpdate()
	{
		if(control) {
			Entities.ForEach((SpatialRotationComponent spatialRotation) => {
				spatialRotation.rotate();
			});
		}
	}
}
