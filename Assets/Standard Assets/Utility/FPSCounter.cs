using System;
using UnityEngine;
#if UNITY_2017_2_OR_NEWER
using UnityEngine.UI;
#endif

namespace UnityStandardAssets.Utility
{
#if UNITY_2017_2_OR_NEWER
    [RequireComponent(typeof (Text))]
#else
    [RequireComponent(typeof (GUIText))]
#endif
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
#if UNITY_2017_2_OR_NEWER
        private Text m_GuiText;
#else
        private GUIText m_GuiText;
#endif

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
#if UNITY_2017_2_OR_NEWER
            m_GuiText = GetComponent<Text>();
#else
            m_GuiText = GetComponent<GUIText>();
#endif
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_GuiText.text = string.Format(display, m_CurrentFps);
            }
        }
    }
}
