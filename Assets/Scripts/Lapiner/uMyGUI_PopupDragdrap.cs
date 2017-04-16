using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace uMyGUI
{
    public class uMyGUI_PopupDragdrap : uMyGUI_PopupButtons
    {

        [SerializeField]
        protected RectTransform[] m_dragdropPanels = new RectTransform[0];
        [SerializeField]
        protected string[] m_dragdropPanelNames = new string[0];

        public virtual uMyGUI_PopupDragdrap ShowDragdropPanel(string m_dragdropNames)
        {
            for (int i = 0; i < m_dragdropPanels.Length; i++)
            {
                if (m_dragdropPanels[i] != null && m_dragdropPanelNames[i] == m_dragdropNames)
                {
                    m_dragdropPanels[i].gameObject.SetActive(true);
                    return this;
                }
            }
            return this;
        }

        public override void Hide()
        {
            base.Hide();
            // hide all buttons
            for (int i = 0; i < m_dragdropPanels.Length; i++)
            {
                if (m_dragdropPanels[i] != null)
                {
                    m_dragdropPanels[i].gameObject.SetActive(false);
                }
            }
        }

        protected override void Start()
        {
            base.Start();
            if (m_dragdropPanels.Length != m_dragdropPanelNames.Length)
            {
                Debug.LogError("uMyGUI_PopupButtons: m_buttons and m_buttonNames must have the same length (" + m_dragdropPanels.Length + "!=" + m_dragdropPanelNames.Length + ")!");
            }
            
        }
    }
}