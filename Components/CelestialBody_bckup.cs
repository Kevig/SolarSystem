/*
using System.Collections;
using System.Collections.Generic;
using Spatial;
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

/*
	private GameObject _gameObject;
	public GameObject getGameObject() => this.gameObject;
	public void setGameObject(GameObject value) => this._gameObject = value;

	private Transform _transform;
	public Transform getTransform() => this._transform;
	public void setTransform(Transform value) => this._transform = value;

	private MeshFilter _meshFilter;
	public MeshFilter meshFilter {
		get => this._meshFilter;
		set => this._meshFilter = value;
	}

	private MeshRenderer _meshRenderer;
	public MeshRenderer meshRenderer { 
		get => _meshRenderer; 
		set => _meshRenderer = value;
	}

	private MeshCollider _meshCollider;
	public MeshCollider meshCollider {
		get => this._meshCollider;
		set => this._meshCollider = value;
	}

	private Rigidbody _rigidBody;
	public Rigidbody getRigidbody() => this._rigidBody;
	public void setRigidbody(Rigidbody value) => this._rigidBody = value;

	// Id - int id
	private int _id;
	public int id {
		get => this._id;
		set => this._id = value;
	}

	// Rotation Data - axies, direction, step, step time duration
	private Spatial.Rotation _spatialRotation;
	public Spatial.Rotation spatialRotation {
		get => this._spatialRotation;
		set => this._spatialRotation = value;
	}
	
	// Orbit Data - central point, path, step, step time duration
	private Spatial.Orbit _orbit = null;
	public Spatial.Orbit orbit {
		get => this._orbit;
		set => this._orbit = value;
	}

	// Stats - TODO
	// Resources etc

	// Name - GameObject Name
	public string getName() => this.getGameObject().name;
	public void setName(string value) => this.getGameObject().name = value;

	public Material[] materials {
		get => this.meshRenderer.materials;
		set => this.meshRenderer.materials = value;
	}

	public Vector3 position {
		get => this.getTransform().position;
		set => this.getTransform().position = value;
	}

	public Quaternion rotation {
		get => this.getTransform().rotation;
		set => this.getTransform().rotation = value;
	}

	public Vector3 scale {
		get => this.getTransform().localScale;
		set => this.getTransform().localScale = value;
	}

	public Mesh mesh {
		get => this.meshFilter.mesh;
		set { 
			this.meshFilter.mesh = value;
			this.meshCollider.sharedMesh = value;
		}
	}

	/// <summary>
	/// Mass property of object
	/// </summary>
	/// <value>float value</value>
	public float mass {
		get => this.getRigidbody().mass;
		set => this.getRigidbody().mass = value;
	}

	/// <summary>
	/// Zero argument contructor
	/// </summary>
	public CelestialBody() {  }

	/// <summary>
	/// Initialises this objects gameObject reference and
	/// component references
	/// </summary>
	/// <param name="prefab">Prefab Gameobject with core components attached</param>
	public void createFromPrefab(GameObject prefab) {
		this.setGameObject(prefab);
		this.setComponents(prefab);
	}

	/// <summary>
	/// Initialises this objects gameObject reference,
	/// component references and id
	/// </summary>
	/// <param name="prefab">Prefab Gameobject with core components attached</param>
	/// <param name="id">Int value identifying object</param>
	public void createFromPrefab(GameObject prefab, int id) {
		this.setGameObject(prefab);
		this.id = id;
		this.setComponents(prefab);
	}
	
	/// <summary>
	/// Initialises this objects gameObject reference,
	/// component references, id and name
	/// </summary>
	/// <param name="prefab">Prefab Gameobject with core components attached</param>
	/// <param name="id">Int value identifying object</param>
	/// <param name="name">String value representing object name</param>
	public void createFromPrefab(GameObject prefab, int id, string name) {
		this.setGameObject(prefab);
		this.id = id;
		this.setName(name);
		this.setComponents(prefab);
	}

	/// <summary>
	/// Initialises this objects core component references
	/// If any core component does not exist on gameObject
	/// component reference will be set to null
	/// </summary>
	/// <param name="gameObject">GameObject with core components attached</param>
	private void setComponents(GameObject gameObject) {
		this.setTransform(gameObject.GetComponent("Transform") as Transform);
		this.meshFilter = gameObject.GetComponent("MeshFilter") as MeshFilter;
		this.meshRenderer = gameObject.GetComponent("MeshRenderer") as MeshRenderer;
		this.meshCollider = gameObject.GetComponent("MeshCollider") as MeshCollider;
		this.setRigidbody(gameObject.GetComponent("RigidBody") as Rigidbody);
	}

}
*/