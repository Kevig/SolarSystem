using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DataCelestialObject {
    
		public string name,
									material,
									rotationUnit,
									orbitTarget,
									orbitUnit;
		
		public int 	rotationDirectionX, rotationDirectionY, rotationDirectionZ,
								orbitDirectionX, orbitDirectionY, orbitDirectionZ;

		public float 	initialRotationX, initialRotationY, initialRotationZ,
									positionX, positionY, positionZ,
									scaleX, scaleY, scaleZ,
									rotationStepX, rotationScalarX,
								 	rotationStepY, rotationScalarY,
								 	rotationStepZ, rotationScalarZ,
									orbitStepX, orbitScalarX,
									orbitStepY, orbitScalarY,
									orbitStepZ, orbitScalarZ;

		public static DataCelestialObject createFromJson(string data) {
			return JsonUtility.FromJson<DataCelestialObject>(data);
		}

		public Vector3 getInitialRotation() {
			return new Vector3(this.initialRotationX, this.initialRotationY, this.initialRotationZ);
		}

		public Vector3 getPosition() {
			return new Vector3(this.positionX, this.positionY, this.positionZ);
		}

		public Vector3 getScale() {
			return new Vector3(this.scaleX, this.scaleY, this.scaleZ);
		}

}
