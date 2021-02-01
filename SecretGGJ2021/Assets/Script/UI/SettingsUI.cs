using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] PlayerMovementShip playerMovementShip;
    [SerializeField] GameObject GOSettingsUI;
    [SerializeField] Slider sliderRotate;

    public void changeStateSettingUI(bool changeBool) {
        GOSettingsUI.SetActive(changeBool);
    }

    public void ExitToSetting() {
        GOSettingsUI.SetActive(false);
        playerMovementShip.changeValueRotation( sliderRotate.value);
    }
}
