using UnityEngine;
using UnityEngine.UI;

public class TabButtonManager : MonoBehaviour
{
    public GameObject[] panels;
    public Button[] tabButtons;

    void Start()
    {
        // 기본으로 첫 번째 탭 활성화
        ShowTab(0);
        UpdateButtonColors(0);

        // 버튼 클릭 이벤트 등록
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i;  // 캡처 문제 해결
            tabButtons[i].onClick.AddListener(() => OnTabClick(index));
        }
    }

    void OnTabClick(int tabIndex)
    {
        ShowTab(tabIndex);
        UpdateButtonColors(tabIndex);
    }

    void ShowTab(int tabIndex)
    {
        // 모든 탭 비활성화
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // 선택한 탭 활성화
        if (tabIndex >= 0 && tabIndex < panels.Length)
        {
            panels[tabIndex].SetActive(true);
        }
    }

    void UpdateButtonColors(int activeIndex)
    {
        for (int i = 0; i < tabButtons.Length; i++)
        {
            Color color = (i == activeIndex) ? Color.cyan : Color.white;
            tabButtons[i].GetComponent<Image>().color = color;
        }
    }
}
