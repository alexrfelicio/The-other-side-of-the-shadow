using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessibilityController : MonoBehaviour {

    [SerializeField] private ColorBlindFilter colorBlind;
    [SerializeField] private Animator accessibilityAnimator;
    [SerializeField] private Button[] buttons;
    private bool showing;

    private void Start() {
        colorBlind.mode = GamePersist.Instance.GetColorBlindMode();
    }

    public void ShowAccessibilityMenu() {
        if (showing) {
            accessibilityAnimator.SetTrigger("Out");
        } else {
            accessibilityAnimator.SetTrigger("In");
        }
        showing = !showing;
    }

    public void SetColorBlindMode(int mode)
    {
        ColorBlindMode newMode;
        switch (mode)
        {
            case 1:
                newMode = ColorBlindMode.Protanopia;
                break;
            case 2:
                newMode = ColorBlindMode.Protanomaly;
                break;
            case 3:
                newMode = ColorBlindMode.Deuteranopia;
                break;
            case 4:
                newMode = ColorBlindMode.Deuteranomaly;
                break;
            case 5:
                newMode = ColorBlindMode.Tritanopia;
                break;
            case 6:
                newMode = ColorBlindMode.Tritanomaly;
                break;
            case 7:
                newMode = ColorBlindMode.Achromatopsia;
                break;
            case 8:
                newMode = ColorBlindMode.Achromatomaly;
                break;
            case 0:
            default:
                newMode = ColorBlindMode.Normal;
                break;

        }
        colorBlind.mode = newMode;
        GamePersist.Instance.SetColorBlindMode(newMode);
        UpdateButtons(mode);
    }

    private void UpdateButtons(int mode) {
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].transform.localScale = new Vector3(1f, 1f, 1f);
            if (i == mode) {
                buttons[i].transform.localScale = new Vector3(1.25f, 1.25f, 1f);
            }
        }
    }
}
