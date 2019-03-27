
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication.Framework.Extensions {

	public static class AttributeCollectionExtension {

		// https://stackoverflow.com/a/3742207/4134376

		/// <summary>
		/// Appends the <c>CSS</c> classes passed as parameters to the already existing ones in the control <see cref="WebControl.Attributes" /> collection.
		/// If there is no attribute named <c>"class"</c> in the collection, one will be added.
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
		/// Appends the <c>CSS</c> classes passed as parameters to the already existing ones in the control <see cref="WebControl.CssClass" /> property.
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to add</param>
		public static void AddCssClass(this WebControl webControl, params string[] classNameParams) {
			IEnumerable<string> classEnumerable = webControl.GetCssClassesExcept(classNameParams).Concat(classNameParams);
			webControl.CssClass = String.Join(" ", classEnumerable.ToArray());
		}

		///// <summary>
		///// Replaces the <c>CSS</c> classes of the attribute <c>"class"</c> defined in the control <see cref="WebControl.Attributes" /> collection.
		///// If there is no attribute named <c>"class"</c> in the collection, one will be added.
		///// </summary>
		///// <param name="webControl">The type the method operates on</param>
		///// <param name="classNameParams">The class name to add</param>
		//public static void Class(this WebControl webControl, params string[] classNameParams) {
		//	webControl.Attributes.Add("class", String.Join(" ", classNameParams));
		//}

		///// <summary>
		///// Replaces the control <see cref="WebControl.CssClass" /> property <c>CSS</c> classes with the passed as parameters.
		///// </summary>
		///// <param name="webControl">The type the method operates on</param>
		///// <param name="classNameParams">The class name to add</param>
		//public static void CssClass(this WebControl webControl, params string[] classNameParams) {
		//	webControl.CssClass = String.Join(" ", classNameParams);
		//}

		/// <summary>
		/// Remove the <c>CSS</c> classes of the attribute <c>"class"</c> defined in the control <see cref="WebControl.Attributes" /> collection, that match the names passed as parameters.
		/// If the attribute <c>"class"</c> in the collection has no <c>CSS</c> classes it will be removed from the control.
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to remove</param>
		public static void RemoveClass(this WebControl webControl, params string[] classNameParams) {

			IEnumerable<string> classEnumerable = classNameParams;
			if(webControl.Attributes["class"] != null) {
				classEnumerable = webControl.GetClassesExcept(classNameParams);
			}

			string[] classNames = classEnumerable.ToArray();
			if(classNames.Length > 0) {
				webControl.Attributes.Add("class", String.Join(" ", classNames));
			} else {
				webControl.Attributes.Remove("class");
			}

		}

		/// <summary>
		/// Removes from the control <see cref="WebControl.CssClass" /> property, the <c>CSS</c> classes that match the name from the passed parameters.
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNameParams">The class name to remove</param>
		public static void RemoveCssClass(this WebControl webControl, params string[] classNameParams) {
			IEnumerable<string> classEnumerable = webControl.GetCssClassesExcept(classNameParams);
			webControl.CssClass = String.Join(" ", classEnumerable.ToArray());
		}

		/// <summary>
		/// Returns the <c>CSS</c> classes of the attribute <c>"class"</c> in the control <see cref="WebControl.Attributes" /> collection, excluding the ones passed as parameters.
		/// </summary>
		/// <param name="webControl">The type the method operates on</param>
		/// <param name="classNames">The class name that will be excluded from the result</param>
		/// <returns></returns>
		public static IEnumerable<string> GetClassesExcept(this WebControl webControl, IEnumerable<string> classNames) {
			classNames = classNames.Concat(new[] { "" });
			return webControl.Attributes["class"].Split(' ').Except(classNames);
		}

		/// <summary>
		/// Returns the <c>CSS</c> classes in the property <see cref="WebControl.CssClass" />, excluding the ones passed as parameters.
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
