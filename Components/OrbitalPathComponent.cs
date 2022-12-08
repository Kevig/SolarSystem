using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalPathComponent : MonoBehaviour {

	public GameObject target;
	public float radius;
	public Material material;

	private float scale = 0.01f;
  private int points;
	private float lineSize = 0.1f;
  private LineRenderer lineRenderer;

  void Update () {
		this.transform.position = this.target.transform.position;
		Vector3 pos;
    float theta = 0f;
    for(int i = 0; i < points; i++){
      theta += (2.0f * Mathf.PI * scale);
      float x = radius * Mathf.Cos(theta);
      float y = radius * Mathf.Sin(theta);
      pos = new Vector3(x, y, 0);
      lineRenderer.SetPosition(i, pos);
    }
  }

	public void load() {
		float sizeValue = (2.0f * Mathf.PI) / scale;
    points = (int)sizeValue;
    lineRenderer = gameObject.AddComponent<LineRenderer>();
    lineRenderer.material = material;
		lineRenderer.startWidth = lineSize;
		lineRenderer.endWidth = lineSize;
    lineRenderer.positionCount = points;
		lineRenderer.useWorldSpace = false;
	}

}
