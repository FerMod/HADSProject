
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication.Framework.Extensions {

	public static class AttributeCollectionExtension {

		// https://stackoverflow.com/a/3742207/4134376

		/// <summary>
		/// Adds to the control the class that with the passed name
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to add</param>
		public static void AddClass(this WebControl webControl, params string[] classNameParams) {
			IEnumerable<string> classEnumerable = classNameParams;
			if(webControl.Attributes["class"] != null) {
				classEnumerable = webControl.GetClassesExcept(classNameParams).Concat(classNameParams);
			}
			webControl.Attributes.Add("class", String.Join(" ", classEnumerable.ToArray()));
		}

		/// <summary>
		/// Adds to the control the class that with the passed name
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to add</param>
		public static void AddCssClass(this WebControl webControl, params string[] classNameParams) {
			IEnumerable<string> classEnumerable = webControl.GetCssClassesExcept(classNameParams).Concat(classNameParams);
			webControl.CssClass = String.Join(" ", classEnumerable.ToArray());
		}

		/// <summary>
		/// Removes the from the control the class that matches the name
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to remove</param>
		public static void RemoveClass(this WebControl webControl, params string[] classNameParams) {
			IEnumerable<string> classEnumerable = classNameParams;
			if(webControl.Attributes["class"] != null) {
				classEnumerable = webControl.GetClassesExcept(classNameParams);
			}
			webControl.Attributes.Add("class", String.Join(" ", classEnumerable.ToArray()));
		}

		/// <summary>
		/// Removes the from the control the class that matches the name
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to remove</param>
		public static void RemoveCssClass(this WebControl webControl, params string[] classNameParams) {
			IEnumerable<string> classEnumerable = webControl.GetCssClassesExcept(classNameParams);
			webControl.CssClass = String.Join(" ", classEnumerable.ToArray());
		}

		/// <summary>
		/// Returns the classes excluding the ones passed as parameters
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNames">The class name that will be excluded from the result</param>
		/// <returns></returns>
		public static IEnumerable<string> GetClassesExcept(this WebControl webControl, IEnumerable<string> classNames) {
			classNames = classNames.Concat(new[] { "" });
			return webControl.Attributes["class"].Split(' ').Except(classNames);
		}

		/// <summary>
		/// Returns the classes excluding the ones passed as parameters
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNames">The class name that will be excluded from the result</param>
		/// <returns></returns>
		public static IEnumerable<string> GetCssClassesExcept(this WebControl webControl, IEnumerable<string> classNames) {
			classNames = classNames.Concat(new[] { "" });
			return webControl.CssClass.Split(' ').Except(classNames);
		}

	}

}
