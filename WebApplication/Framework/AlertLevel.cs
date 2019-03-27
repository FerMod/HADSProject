using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Framework {

	/// <summary>
	/// Class to act like an enum, that holds different values.
	/// This class specifies the alert level.
	/// </summary>
	[Serializable]
	public sealed class AlertLevel {

		private readonly int value;
		private readonly string name;

		private static readonly Dictionary<string, AlertLevel> instance = new Dictionary<string, AlertLevel>();

		public static readonly AlertLevel None = new AlertLevel(0, "");
		public static readonly AlertLevel Primary = new AlertLevel(1, "alert-primary");
		public static readonly AlertLevel Secondary = new AlertLevel(2, "alert-secondary");
		public static readonly AlertLevel Success = new AlertLevel(3, "alert-success");
		public static readonly AlertLevel Danger = new AlertLevel(4, "alert-danger");
		public static readonly AlertLevel Warning = new AlertLevel(5, "alert-warning");
		public static readonly AlertLevel Info = new AlertLevel(6, "alert-info");
		public static readonly AlertLevel Light = new AlertLevel(7, "alert-light");
		public static readonly AlertLevel Dark = new AlertLevel(8, "alert-dark");

		private AlertLevel(int value, string name) {
			instance[name] = this;
			this.value = value;
			this.name = name;
		}

		public override string ToString() {
			return name;
		}

		public static explicit operator AlertLevel(string str) {
			if(instance.TryGetValue(str, out AlertLevel result)) {
				return result;
			} else {
				throw new InvalidCastException();
			}
		}

		public static bool operator ==(AlertLevel a, AlertLevel b) {

			// If both are null, or both are same instance, return true.
			if(Object.ReferenceEquals(a, b)) {
				return true;
			}

			// If one is null, but not both, return false.
			if(a is null || b is null) {
				return false;
			}

			// Return true if the fields match
			return (a.value == b.value) && (a.name == b.name);
		}

		public static bool operator !=(AlertLevel a, AlertLevel b) {
			return !(a == b);
		}

		public override bool Equals(object obj) {
			return Equals(obj as AlertLevel);
		}

		public bool Equals(AlertLevel other) {

			// If parameter is null, return false.
			if(other is null) {
				return false;
			}

			// Optimization for a common success case.
			if(Object.ReferenceEquals(this, other)) {
				return true;
			}

			// If run-time types are not exactly the same, return false.
			if(this.GetType() != other.GetType()) {
				return false;
			}

			// Return true if the fields match.
			return (this.value == other.value) && (this.name == other.name);
		}

		public override int GetHashCode() {

			// Overflow is fine, just wrap
			unchecked {

				int hash = 17;

				hash = hash * 23 + GetHashCode(value);
				hash = hash * 23 + GetHashCode(name);

				return hash;
			}

		}

		private int GetHashCode<T>(T t) => (t == null) ? 0 : t.GetHashCode();

	}

}
