using UnityEngine;
using UnityEngine.UI;

public class OpenClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button toggleButton;

    private void Start()
    {
        toggleButton.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (GameObject p in panels)
        {
            if (p != panel)
            {
                p.SetActive(false);
            }
        }

        panel.SetActive(!panel.activeSelf);
    }
}
