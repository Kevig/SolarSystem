namespace DataType {

	using Unity.Entities;

	[System.Serializable]
	public struct RotationStep : IComponentData {
		public DataType.Step x, y, z;
		
		public RotationStep(Step step) : this()
		{
			this.x = step;
			this.y = step;
			this.z = step;
		}

		public RotationStep(Step x, Step y, Step z) : this()
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}