using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement {
	public class Path {
		
		public Stack<Vector3> _nodes = new Stack<Vector3>();
		public Stack<Vector3> nodes {
			get => this._nodes;
			set => this._nodes = value;
		}

		public void add(Vector3 node) => this._nodes.Push(node);
		
		public Vector3 next() => this._nodes.Pop();

		public int size() => this._nodes.Count;
	}
}
