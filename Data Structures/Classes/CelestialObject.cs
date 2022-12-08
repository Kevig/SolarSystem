using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject {

		public CelestialObject(string materialPath, Vector3 initialRotation, Vector3 position,
													 Vector3 scale, Dictionary<string, AxisRotation> rotation,
													 Dictionary<string, AxisRotation> orbit) {
			this._materialPath = materialPath;
			this._position = position;
			this._initialRotation = initialRotation;
			this._scale = scale;
			this._rotation = rotation;
			this._orbit = orbit;
		}

    private string _materialPath;
		public string materialPath {
			get => this._materialPath;
			set => this._materialPath = value;
		}

		private Vector3 _position;
		public Vector3 position {
			get => this._position;
			set => this._position = value;
		}

		private Vector3 _initialRotation;
		public Vector3 initialRotation {
			get => this._initialRotation;
			set => this._initialRotation = value;
		}

		private Vector3 _scale;
		public Vector3 scale {
			get => this._scale;
			set => this._scale = value;
		}

		private Dictionary<string, AxisRotation> _rotation;
		public Dictionary<string, AxisRotation> rotation {
			get => this._rotation;
			set => this._rotation = value;
		}

		private Dictionary<string, AxisRotation> _orbit;
		public Dictionary<string, AxisRotation> orbit {
			get => this._orbit;
			set => this._orbit = value;
		}
		
		private string _orbitTarget = null;
		public string orbitTarget {
			get => this._orbitTarget;
			set => this._orbitTarget = value;
		}

}
