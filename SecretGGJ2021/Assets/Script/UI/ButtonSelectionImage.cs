using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSelectionImage : MonoBehaviour
{
    [SerializeField] UnityEvent changeValueTrueButton;
    [SerializeField] UnityEvent changeValueFalseButton;
    [SerializeField] GameObject imageGameObjectTick;

    bool valueOfButton = false;

    public void StartSelectionInfoAndEvents()
    {
        int iSave = PlayerPrefs.GetInt("Bool");
        if (iSave == 0)
        {
            valueOfButton = false;
            changeValueFalseButton.Invoke();
        }
        else
        {
            changeValueTrueButton.Invoke();
            valueOfButton = true;
        }

        imageGameObjectTick.SetActive(valueOfButton);
    }

    public void touchButton() {
        valueOfButton = !valueOfButton;

        if (valueOfButton) {
            PlayerPrefs.SetInt("Bool", 1);
            changeValueTrueButton.Invoke();
        }
        else {
            PlayerPrefs.SetInt("Bool", 0);
            changeValueFalseButton.Invoke();
        }

        imageGameObjectTick.SetActive(valueOfButton);

        //save
        

    }
}
