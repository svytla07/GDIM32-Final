using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuPanel;

    void Start()
    {
        Time.timeScale = 0f; // 游戏开始暂停
        startMenuPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        startMenuPanel.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏
    }
}
