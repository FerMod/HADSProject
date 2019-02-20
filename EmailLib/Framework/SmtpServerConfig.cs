using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailLib {

	public class SmtpServerConfig {

		public string Account { get; set; } = "";
		public string Password { get; set; } = "";
		public string Host { get; set; } = "";
		public int Port { get; set; } = 587;
		public SmtpDeliveryMethod DeliveryMethod { get; set; } = SmtpDeliveryMethod.Network;
		public bool UseDefaultCredentials { get; set; } = false;
		public bool EnableSsl { get; set; } = true;

		public static bool operator ==(SmtpServerConfig a, SmtpServerConfig b) {

			// If both are null, or both are same instance, return true.
			if(Object.ReferenceEquals(a, b)) {
				return true;
			}

			// If one is null, but not both, return false.
			if(((object)a == null) || ((object)b == null)) {
				return false;
			}

			// Return true if the fields match
			return (a.Account == b.Account)
				&& (a.Password == b.Password)
				&& (a.Host == b.Host)
				&& (a.Port == b.Port)
				&& (a.DeliveryMethod == b.DeliveryMethod)
				&& (a.UseDefaultCredentials == b.UseDefaultCredentials)
				&& (a.EnableSsl == b.EnableSsl);
		}

		public static bool operator !=(SmtpServerConfig a, SmtpServerConfig b) {
			return !(a == b);
		}

		public override bool Equals(object obj) {
			return Equals(obj as SmtpServerConfig);
		}

		public bool Equals(SmtpServerConfig other) {

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
			return (this.Account == other.Account)
				&& (this.Password == other.Password)
				&& (this.Host == other.Host)
				&& (this.Port == other.Port)
				&& (this.DeliveryMethod == other.DeliveryMethod)
				&& (this.UseDefaultCredentials == other.UseDefaultCredentials)
				&& (this.EnableSsl == other.EnableSsl);
		}

		public override int GetHashCode() {

			// Overflow is fine, just wrap
			unchecked {

				int hash = 17;

				hash = hash * 23 + GetHashCode(Account);
				hash = hash * 23 + GetHashCode(Password);
				hash = hash * 23 + GetHashCode(Host);
				hash = hash * 23 + GetHashCode(Port);
				hash = hash * 23 + GetHashCode(DeliveryMethod);
				hash = hash * 23 + GetHashCode(UseDefaultCredentials);
				hash = hash * 23 + GetHashCode(EnableSsl);

				return hash;
			}

		}

		private int GetHashCode<T>(T t) {
			return t == null ? 0 : t.GetHashCode();
		}

	}

}
