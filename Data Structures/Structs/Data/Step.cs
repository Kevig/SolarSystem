
using Unity.Entities;

namespace DataType {
	[System.Serializable]
	public struct Step : IComponentData {

		public Step(float amount, float duration) {
			_amount = amount;
			_duration = duration;
		}

		public float _amount, _duration;
		
		public float amount { get => _amount; set => _amount = value; }
		public float duration { get => _duration; set => _duration = value; }
	}
}
