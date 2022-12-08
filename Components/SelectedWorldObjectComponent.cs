using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWorldObjectComponent : MonoBehaviour {
  
	public enum HighlightType {
		LineRenderer,
		Canvas,
		None
	}
	
	public GameObject target;
	public GameObject mainCamera;
	public bool show = false;
	public float radius;
	public Material material;
	private float scale = 0.01f;
	private int points;
	private float lineSize = 0.1f;
	private RectTransform canvasRect;
	private Canvas canvas;

	public HighlightType highlightType = HighlightType.Canvas;
	private HighlightType _highlightType = HighlightType.Canvas;

	public LineRenderer getLineRenderer() {
		return (this.gameObject.GetComponent<LineRenderer>() as LineRenderer);
	}

	private void updateTarget(GameObject target) {
		this.target = target;
		if(target == null) {
			this.radius = 0;
			this.show = false;
		} else {
			this.radius = (target.transform.lossyScale.x / 2);
			this.radius += 0.1f * this.radius;
			this.show = true;
		}

		this.updateCanvas(new Vector2(this.radius, this.radius));
		this.showHighlight();
	}

	private void updateCanvas(Vector2 size) {
		size *= 2f;
		size = new Vector2(size.x + (size.x * 0.1f), size.y + (size.y * 0.1f));
		this.canvasRect.sizeDelta = size;
	}

	public void Start() {
		CelestialBodyTesting.onSelectedChange += this.updateTarget;
		
		this.mainCamera = GameObject.Find("Main Camera");
		
		this.canvas = this.GetComponent<Canvas>() as Canvas;
		this.canvasRect = this.GetComponent<RectTransform>() as RectTransform;

		float sizeValue = (2.0f * Mathf.PI) / this.scale;
    this.points = (int)sizeValue;
    LineRenderer lineRenderer = this.getLineRenderer();
		lineRenderer.startWidth = this.lineSize;
		lineRenderer.endWidth = this.lineSize;
    lineRenderer.positionCount = this.points;
		lineRenderer.useWorldSpace = false;
	}

	public void Update() {

		if(this.highlightType != this._highlightType) {
			if(this.highlightType != HighlightType.None) {
				this.show = true;
			}
			this._highlightType = this.highlightType;
			this.showHighlight();
		}

		if(this.target != null) {
			this.transform.LookAt(this.mainCamera.transform);
			this.transform.position = target.transform.position;
			Vector3 pos;
			float theta = 0f;
			LineRenderer lineRenderer = this.getLineRenderer();
			for(int i = 0; i < this.points; i++){
				theta += (2.0f * Mathf.PI * this.scale);
				float x = this.radius * Mathf.Cos(theta);
				float y = this.radius * Mathf.Sin(theta);
				pos = new Vector3(x, y, 0);
				lineRenderer.SetPosition(i, pos);
			}
		}
	}

	private void showHighlight() {
		if(this.highlightType == HighlightType.LineRenderer) {
			this.getLineRenderer().enabled = this.show;
			this.canvas.enabled = false;
		} else if(this.highlightType == HighlightType.Canvas) {
			this.canvas.enabled = this.show;
			this.getLineRenderer().enabled = false;
		} else {
			this.show = false;
			this.canvas.enabled = false;
			this.getLineRenderer().enabled = false;
		}
	}

}
