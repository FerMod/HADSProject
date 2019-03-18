
using System.Web.UI.WebControls;

namespace CustomControls {

	public class CharCount : TextBox {

		private TextBox _controlToWatch;

		public TextBox ControlToWatch {
			get {
				return _controlToWatch;
			}
			set {
				string theFunction = $"javascript:textCounter({_controlToWatch.ClientID}, {this}, 160);";

				this.Attributes.Add("onKeyDown", theFunction);
				this.Attributes.Add("onKeyUp", theFunction);
				_controlToWatch = value;
			}
		}
		public int Max { get; set; }

		protected CharCount() {


			string textCounterFunction = @"
				<script language=javascript>
					function textCounter(field, countField, maxLimit) {
						if (field.value.length > maxLimit) {
							field.value = field.value.substring(0, maxLimit);
						} else {
							countField.value = maxLimit - field.value.length;
						}
					}
				</script>";

			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientScriptFunction", textCounterFunction);

		}

		//onkeyup='textCounter(this, outputField, 160);'
  //      onkeydown="textCounter(this, outputField, 160);"

	}

}
