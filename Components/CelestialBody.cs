using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour {

	/*
		GameObject Components:
			GameObject
			Transform - Position, Rotation, Scale
			Mesh Filter
			Mesh Renderer
			Collider
			Rigidbody
			Materials
	*/

	// Id - public for testing
	public int _id;
	public int id {
		get => this._id;
		set => this._id = value;
	}

	// Rotation Data - axies, direction, step, step time duration
	// - public for testing
	public SpatialRotationComponent getSpatialRotation(GameObject obj) =>
		obj.GetComponent("SpatialRotationComponent") as SpatialRotationComponent;

	public void setSpatialRotation(int x, int y, int z, DataType.RotationStep rotationStep) {
		SpatialRotationComponent objComponent = this.getSpatialRotation(this.gameObject);
		if(objComponent == null) { objComponent = this.gameObject.AddComponent<SpatialRotationComponent>(); }
		objComponent.set(x, y, z, rotationStep);
	}

	public void setSpatialRotation(int x, int y, int z, DataType.Step step) {
		this.setSpatialRotation(x, y, z, new DataType.RotationStep(step));
	}

	public void setSpatialRotation(int x, int y, int z, float distance, float time) {
		this.setSpatialRotation(x, y, z, new DataType.RotationStep(new DataType.Step(distance, time)));
	}

	public void setSpatialRotation(int x, int y, int z, DataType.Step stepX, DataType.Step stepY, DataType.Step stepZ) {
		this.setSpatialRotation(x, y, z, new DataType.RotationStep(stepX, stepY, stepZ));
	}

	public void setSpatialRotation( int x, float distanceX, float durationX,
																	int y, float distanceY, float durationY,
																	int z, float distanceZ, float durationZ) {
		this.setSpatialRotation(x, y, z, 	new DataType.Step(distanceX, durationX),
																			new DataType.Step(distanceY, durationY),
																			new DataType.Step(distanceZ, durationZ));
	}

	// Orbit Data - central orbitTarget, path, step, step time duration
	// - public for testing
	public SpatialRotationComponent getSpatialOrbit() => this.transform.parent.GetComponent("SpatialRotationComponent") as SpatialRotationComponent;
	public void setSpatialOrbit(GameObject orbitTarget, int x, int y, int z, DataType.RotationStep rotationStep) {
		Transform orbitControlTransform = this.gameObject.transform.parent;
		GameObject orbitControlObject;
		if(orbitControlTransform == null) {
			orbitControlObject = GameObject.Instantiate((	GameObject.Find("Test_Manager").GetComponent("CelestialBodyTesting") as CelestialBodyTesting).orbitControlPrefab,
																										orbitTarget.transform.position,
																										Quaternion.Euler(Vector3.zero));
			orbitControlObject.name = this.gameObject.name + " Orbit";
			this.transform.parent = orbitControlObject.transform;
		} else {
			orbitControlObject = orbitControlTransform.gameObject;
		}

		GameObject orbitalPathObject = GameObject.Instantiate((	GameObject.Find("Test_Manager").GetComponent("CelestialBodyTesting") as CelestialBodyTesting).orbitalPathPrefab,
																														orbitTarget.transform.position,
																														Quaternion.Euler(new Vector3(45f, 0f, 0f)));
		orbitalPathObject.name = this.gameObject.name + " Orbital Path";
		OrbitalPathComponent orbitalPathComponent = orbitalPathObject.GetComponent("OrbitalPathComponent") as OrbitalPathComponent;
		orbitalPathComponent.target = orbitTarget;
		orbitalPathComponent.radius = this.gameObject.transform.position.x - orbitTarget.transform.position.x;
		orbitalPathComponent.load();
		
		SpatialRotationComponent spatialRotation = orbitControlObject.GetComponent("SpatialRotationComponent") as SpatialRotationComponent;
		spatialRotation.set(x, y, z, rotationStep);
		spatialRotation.target = orbitTarget;
	}
	
	public void setSpatialOrbit(GameObject orbitTarget, int x, int y, int z, DataType.Step step) {
		this.setSpatialOrbit(orbitTarget, x, y, z, new DataType.RotationStep(step));
	}

	public void setSpatialOrbit(GameObject orbitTarget, int x, int y, int z, float distance, float time) {
		this.setSpatialOrbit(orbitTarget, x, y, z, new DataType.Step(distance, time));
	}

	public void setSpatialOrbit(GameObject orbitTarget, int x, int y, int z, DataType.Step stepX, DataType.Step stepY, DataType.Step stepZ) {
		this.setSpatialOrbit(orbitTarget ,x, y, z, new DataType.RotationStep(stepX, stepY, stepZ));
	}

	public void setSpatialOrbit( GameObject orbitTarget, int x, float distanceX, float durationX,
																											 int y, float distanceY, float durationY,
																											 int z, float distanceZ, float durationZ) {
		this.setSpatialOrbit(orbitTarget, x, y, z, new DataType.Step(distanceX, durationX),
																							 new DataType.Step(distanceY, durationY),
																							 new DataType.Step(distanceZ, durationZ));
	}

	// Stats - TODO
	// Resources etc

	/// <summary>
	/// Zero argument contructor
	/// </summary>
	public CelestialBody() {  }

	public GameObject getGameObject() => this.gameObject;
	public Transform getTransform() => this.gameObject.GetComponent("Transform") as Transform;
	public MeshFilter getMeshFilter() => this.gameObject.GetComponent("MeshFilter") as MeshFilter;
	public MeshRenderer getMeshRenderer() => this.gameObject.GetComponent("MeshRenderer") as MeshRenderer;
	public MeshCollider getMeshCollider() => this.gameObject.GetComponent("MeshCollider") as MeshCollider;
	public Rigidbody getRigidbody() => this.gameObject.GetComponent("Rigidbody") as Rigidbody;
	public string getName() => this.gameObject.name;
	public void setName(string value) => this.gameObject.name = value;
	public Material[] getMaterials() => this.getMeshRenderer().materials;
	public void setMaterials(Material[] materials) => this.getMeshRenderer().materials = materials;
	public void setMaterials(Material material) => this.getMeshRenderer().materials = new [] { material };
	public Vector3 getPosition() => this.getTransform().position;
	public void setPosition(Vector3 position) => this.getTransform().position = position;
	public Quaternion getRotation() => this.getTransform().rotation;
	public void setRotation(Vector3 rotation) => this.getTransform().rotation = Quaternion.Euler(rotation);
	public Vector3 getScale()	=> this.getTransform().lossyScale;
	public void setScale(Vector3 scale) => this.getTransform().localScale = scale;

	public Mesh getMesh() => this.getMeshFilter().mesh;
	public void setMesh(Mesh mesh) { 
		this.getMeshFilter().mesh = mesh;
		this.getMeshCollider().sharedMesh = mesh;
	}

	public float getMass() => this.getRigidbody().mass;
	public void setMass(float mass) => this.getRigidbody().mass = mass;

}
