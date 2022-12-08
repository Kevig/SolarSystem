using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CelestialDataObjects {

	public DataCelestialObject[] objects;

	public static CelestialDataObjects load() {
		TextAsset dataFile = Resources.Load("Data/CelestialBodyData") as TextAsset;
		return JsonUtility.FromJson<CelestialDataObjects>(dataFile.text);
	}

}
