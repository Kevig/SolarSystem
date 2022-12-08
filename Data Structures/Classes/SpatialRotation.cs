
using DataType;
using UnityEngine;

public class SpatialRotation : MonoBehaviour {

	public int _x;
	public int x {
		get => _x;
		set => _x = value;
	}

	public int _y;
	public int y {
		get => _y;
		set => _y = value;
	}

	public int _z;
	public int z {
		get => _z;
		set => _z = value;
	}

	public Vector3 Vector3() {
		return new Vector3(x, y, z);
	}

	public RotationStep _rotationStep;
	public RotationStep rotationStep {
		get => _rotationStep;
		set => _rotationStep = value;
	}

	public void set(int x, int y, int z, RotationStep rotationStep) {
		this.x = x; this.y = y; this.z = z;
		this.rotationStep = rotationStep;
	}

	public void set(int x, int y, int z, Step step) {
		this.set(x, y, z, new RotationStep(step));
	}

	public void set(int x, int y, int z, Step stepX, Step stepY, Step stepZ) {
		this.set(x, y, z, new RotationStep(stepX, stepY, stepZ));
	}

	protected void doRotate() {
		DataType.RotationStep step = this.rotationStep;
		float x = this.x != 0 ? step.x.amount > 0 ? step.x.duration > 0 ? this.x * step.x.amount :0:0:0;
		float y = this.y != 0 ? step.y.amount > 0 ? step.y.duration > 0 ? this.y * step.y.amount :0:0:0;
		float z = this.z != 0 ? step.z.amount > 0 ? step.z.duration > 0 ? this.z * step.z.amount :0:0:0;

		if(!(x == 0 && y == 0 && z == 0)) {
			this.gameObject.transform.Rotate(new Vector3(x,y,z) * Time.deltaTime, Space.Self);
		}
	}

}
