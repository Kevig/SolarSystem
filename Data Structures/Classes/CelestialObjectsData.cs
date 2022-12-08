using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


public static class CelestialObjectsData {
	
	private static UniversalTimeComponent timeManager;
	private const float degrees = 360f;
	public static Dictionary<string, CelestialObject> celestialObjects;

	static CelestialObjectsData() {
		timeManager = GameObject.Find("Test_Manager").GetComponent("UniversalTimeComponent") as UniversalTimeComponent;
		
		CelestialDataObjects celestialDataObjects = CelestialDataObjects.load();
		
		celestialObjects = new Dictionary<string, CelestialObject>();
		
		foreach(DataCelestialObject item in celestialDataObjects.objects) {
			
			float rotationX = 0f, rotationY = 0f, rotationZ = 0f;
			if(item.rotationUnit != "null") {
				float rotationValue = getUnitValue(item.rotationUnit);
				rotationX = getStepValue(item.rotationDirectionX, rotationValue, item.rotationStepX);
				rotationY = getStepValue(item.rotationDirectionY, rotationValue, item.rotationStepY);
				rotationZ = getStepValue(item.rotationDirectionZ, rotationValue, item.rotationStepZ);
			}

			Dictionary<string, AxisRotation> rotation = new Dictionary<string, AxisRotation>();
			rotation.Add("x", new AxisRotation(item.rotationDirectionX, rotationX, item.rotationScalarX));
			rotation.Add("y", new AxisRotation(item.rotationDirectionY, rotationY, item.rotationScalarY));
			rotation.Add("z", new AxisRotation(item.rotationDirectionZ, rotationZ, item.rotationScalarZ));

			float orbitX = 0f, orbitY = 0f, orbitZ = 0f;
			if(item.orbitUnit != "null") {
				float orbitValue = getUnitValue(item.orbitUnit);
				orbitX = getStepValue(item.orbitDirectionX, orbitValue, item.orbitStepX);
				orbitY = getStepValue(item.orbitDirectionY, orbitValue, item.orbitStepY);
				orbitZ = getStepValue(item.orbitDirectionZ, orbitValue, item.orbitStepZ);
			}

			Dictionary<string, AxisRotation> orbit = new Dictionary<string, AxisRotation>();
			orbit.Add("x", new AxisRotation(item.orbitDirectionX, orbitX, item.orbitScalarX));
			orbit.Add("y", new AxisRotation(item.orbitDirectionY, orbitY, item.orbitScalarY));
			orbit.Add("z", new AxisRotation(item.orbitDirectionZ, orbitZ, item.orbitScalarZ));

			CelestialObject obj = new CelestialObject("Materials/" + item.material, item.getInitialRotation(),
																								item.getPosition(), item.getScale(), rotation, orbit );
			obj.orbitTarget = item.orbitTarget == "null" ? null : item.orbitTarget;
			celestialObjects.Add(item.name, obj);
		}
	}

	private static float getUnitValue(string unit) {
		switch(unit) {
			case "second": return timeManager.second;
			case "minute": return timeManager.minute;
			case "hour": return timeManager.hour;
			case "day": return timeManager.day;
			case "week": return timeManager.week;
			case "month": return timeManager.month;
			case "year": return timeManager.year;
			default: return timeManager.day;
		}
	}

	private static float getStepValue(int direction, float unit, float step) {
		return 	(direction == 0) ? 0 : degrees / (unit * step);
	}

}
