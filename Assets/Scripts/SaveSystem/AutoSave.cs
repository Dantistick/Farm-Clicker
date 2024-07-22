using UnityEngine;
using UnityEngine.UI;

class AutoSave : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        StartCoroutine(AutoClickButton());
    }

    private System.Collections.IEnumerator AutoClickButton()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            _button.onClick.Invoke();
        }
    }
}