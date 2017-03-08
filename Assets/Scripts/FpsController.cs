using UnityEngine;

namespace Torappu.Prototype {
  public class FpsController : MonoBehaviour {
    [SerializeField]
    private bool m_lockTargetFps = false;
    [SerializeField]
    private int m_targetFps = 60;
    [SerializeField]
    private float m_periodToProfile = 1.0f;
    [SerializeField]
    private int m_fpsFontSize = 36;
    [SerializeField]
    private Rect m_fpsRect = new Rect(5, 5, 200, 50);

    private float m_fpsCountTime = 0;
    private int m_frameCnt = 0;
    private float m_lastFps = 0;

    public bool lockTargetFps {
      get { return m_lockTargetFps; }
    }

    private void Start() {
      Screen.sleepTimeout = SleepTimeout.NeverSleep;
      if (m_lockTargetFps) {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = m_targetFps;
      }
    }

    private void Update() {
      // **NOTICE** we don't want Time.timeScale affects our fps counter.
      m_fpsCountTime += Time.unscaledDeltaTime;
      m_frameCnt++;
      if (m_fpsCountTime >= m_periodToProfile) {
        m_lastFps = m_frameCnt / m_fpsCountTime;
        m_fpsCountTime = 0;
        m_frameCnt = 0;
      }
    }

    private void OnGUI() {
      int originFontSize = GUI.skin.label.fontSize;
      Color originColor = GUI.color;

      GUI.color = Color.black;
      GUI.skin.label.fontSize = m_fpsFontSize;
      GUI.Label(m_fpsRect, m_lastFps.ToString(".00" + " fps"));

      GUI.skin.label.fontSize = originFontSize;
      GUI.color = originColor;
    } 
  }
}