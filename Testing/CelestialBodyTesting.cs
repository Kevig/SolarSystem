using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBodyTesting : MonoBehaviour {

	public GameObject prefab;
	public GameObject orbitControlPrefab;

	public GameObject orbitalPathPrefab;

	public const float degrees = 360f;

	public bool run = false;
	private bool _run = false;

	private GameObject _selected;
	public GameObject selected {
		get => this._selected;
		set { 
			this._selected = value;
			onSelectedChange(this.selected);
		}
	}
	public delegate void SelectedChange(GameObject selectedObject);
	public static event SelectedChange onSelectedChange;

	// Start is called before the first frame update
	void Start()
	{
		Dictionary<string, CelestialObject> celestialObjects = CelestialObjectsData.celestialObjects;

		foreach(KeyValuePair<string, CelestialObject> celestialObject in celestialObjects) {
			CelestialBody celestialBody = createCelestialBody(celestialObject.Value.initialRotation, celestialObject.Value.position, prefab);
			Material material = Resources.Load(celestialObject.Value.materialPath) as Material;
			celestialBody.setMaterials(material);
			celestialBody.setScale(celestialObject.Value.scale);
			celestialBody.setName(celestialObject.Key);

			if(celestialBody.name == "Sun") { celestialBody.getMeshRenderer().receiveShadows = false; }
			
			AxisRotation rotationX = celestialObject.Value.rotation["x"];
			AxisRotation rotationY = celestialObject.Value.rotation["y"];
			AxisRotation rotationZ = celestialObject.Value.rotation["z"];
			
			celestialBody.setSpatialRotation(rotationX.direction, rotationX.step, rotationX.scalar,
																			 rotationY.direction, rotationY.step, rotationY.scalar,
																			 rotationZ.direction, rotationZ.step, rotationZ.scalar);

			if(celestialObject.Value.orbitTarget != null) {
				GameObject target = GameObject.Find(celestialObject.Value.orbitTarget);
				AxisRotation orbitX = celestialObject.Value.orbit["x"];
				AxisRotation orbitY = celestialObject.Value.orbit["y"];
				AxisRotation orbitZ = celestialObject.Value.orbit["z"];
				celestialBody.setSpatialOrbit(target, orbitX.direction, orbitX.step, orbitX.scalar,
																							orbitY.direction, orbitY.step, orbitY.scalar,
																							orbitZ.direction, orbitZ.step, orbitZ.scalar);
			}
		}
		run = true;
	}

	private CelestialBody createCelestialBody(Vector3 rotation, Vector3 position, GameObject prefab) {
		GameObject obj = GameObject.Instantiate(prefab, position, Quaternion.Euler(rotation));
		return obj.GetComponent("CelestialBody") as CelestialBody;
	}

	// Update is called once per frame
	void Update()
	{
		if(run != _run) {
			_run = run;
			UniversalTimeSystem.control = _run;
			SpatialRotationSystem.control = _run;
		}
	}
}
