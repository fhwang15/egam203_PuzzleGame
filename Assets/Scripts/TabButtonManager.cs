using UnityEngine;
using UnityEngine.UI;

public class TabButtonManager : MonoBehaviour
{
    public GameObject[] panels;
    public Button[] tabButtons;

    void Start()
    {
        // �⺻���� ù ��° �� Ȱ��ȭ
        ShowTab(0);
        UpdateButtonColors(0);

        // ��ư Ŭ�� �̺�Ʈ ���
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i;  // ĸó ���� �ذ�
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
        // ��� �� ��Ȱ��ȭ
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // ������ �� Ȱ��ȭ
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
