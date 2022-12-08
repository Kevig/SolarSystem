using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControlComponent : MonoBehaviour
{

		public GameObject target;

    public float scale;
		public float distance;
		public float zoomScaler;

		public void Start() {
			CelestialBodyTesting.onSelectedChange += this.targetChange;

			this.target = this.transform.parent.gameObject;
			this.distance = Mathf.Abs(this.transform.position.z);
		}

		public void zoom(int direction) {
			float step = (direction == 1) ? Time.deltaTime * this.scale :
									(direction == -1) ? Time.deltaTime * -this.scale : 0;
			this.distance -= step;
		}

		public void Update() {
			if(Mathf.Abs(this.transform.localPosition.z) != this.distance) {
				this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,
																													 new Vector3(0f, 0f, -this.distance),
																													 Time.deltaTime * this.zoomScaler);
			}
		}

		private void targetChange(GameObject target) {
			if(target != null) {
				this.distance = (this.distance > 20f) ? 20f : this.distance;
			}
		}
}
