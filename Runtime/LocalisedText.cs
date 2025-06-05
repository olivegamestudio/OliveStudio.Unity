using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class LocalisedText : MonoBehaviour
{
    public LocalizedString Text;

    void OnEnable()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = Text.GetLocalizedString();
    }
}
