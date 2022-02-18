using NotReaper.Models;
using UnityEngine;

namespace NotReaper.Targets {
	public class TargetSetHitsoundIntent {
		public TargetSetHitsoundIntent() {}

		public TargetSetHitsoundIntent(TargetSetHitsoundIntent other) {
			target = other.target;
			startingVelocity = other.startingVelocity;
			newVelocity = other.newVelocity;
		}

		public TargetData target;
		public InternalTargetVelocity startingVelocity;
		public InternalTargetVelocity newVelocity;
	}
}