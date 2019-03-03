using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Framework {

	/// <summary>
	/// Class to act like an enum, that holds different values.
	/// This class specifies the alert level.
	/// </summary>
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

	}

}
