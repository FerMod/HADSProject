
namespace WebApplication.Framework {

	public enum UserType {
		Unknown = -1,
		Student,
		Teacher,
		TeacherAdmin
	}

	public class UserRole {

		public UserType Value { get; set; }

		public string Name {
			get {
				switch(Value) {
					case UserType.Student:
						return "student";
					case UserType.Teacher:
						return "teacher";
					case UserType.TeacherAdmin:
						return "teacher_admin";
					case UserType.Unknown:
					default:
						return "unknown";
				}
			}
		}

		public UserRole() : this(UserType.Unknown){
		}

		public UserRole(UserType userType) {
			Value = userType;
		}

		public override string ToString() {
			return Name;
		}

		public static implicit operator string(UserRole userRole) {
			return userRole.ToString();
		}

	}

}
