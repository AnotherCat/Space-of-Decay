using UnityEngine;
using System.Collections;

namespace uMyGUI
{
	public class uMyGUI_Popup : MonoBehaviour
	{
		public virtual bool IsShown
		{
			get
			{
				return gameObject.activeSelf;
			}
		}

		public virtual void Show()
		{
			gameObject.SetActive(true);
		}

		public virtual void Hide()
		{
			gameObject.SetActive(false);
		}

		protected virtual void Start()
		{
		}
	}
}
