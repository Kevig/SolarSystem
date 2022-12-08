using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetPositionComponent : MonoBehaviour {

		public GameObject target = null;
		public float scale;

    void Start() {
        CelestialBodyTesting.onSelectedChange += this.updateTarget;
    }

		public void Update() {
			if(this.target != null) {
				this.transform.position = Vector3.MoveTowards(this.transform.position,
																											this.target.transform.position,
																											Time.deltaTime * this.scale);
			}
		}

		private void updateTarget(GameObject target) {
			this.target = target;
		}

}
