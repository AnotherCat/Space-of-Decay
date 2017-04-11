using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace uMyGUI
{
	public class uMyGUI_PopupText : uMyGUI_PopupButtons
	{
		[SerializeField]
		protected Text m_header;
		[SerializeField]
		protected Text m_body;

		public virtual uMyGUI_PopupText SetText(string p_headerText, string p_bodyText)
		{
			if (m_header != null)
			{
				m_header.text = p_headerText;
			}
			if (m_body != null)
			{
				m_body.text = p_bodyText;
			}
			return this;
		}
	}
}
