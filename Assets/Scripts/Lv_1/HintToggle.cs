using UnityEngine;

public class HintToggle : MonoBehaviour
{
    public GameObject hintText;

    public void ToggleHint()
    {
        hintText.SetActive(!hintText.activeSelf);
    }
}
