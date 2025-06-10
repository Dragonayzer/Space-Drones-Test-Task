using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingUpdater : MonoBehaviour
{
    [SerializeField]
    private SettingParameter parameter;
    [SerializeField]
    private ValueSource valueSource;
    [SerializeField]
    private GameObject valueText;

    public void UpdateParameter()
    {
        Debug.Log($"Updated {valueSource} {parameter}");
        switch (valueSource)
        {
            case ValueSource.Slider:
                valueText.GetComponent<TMP_Text>().text = GetComponent<Slider>().value.ToString();
                SetParameter(GetComponent<Slider>().value);
                break;
            case ValueSource.InputText:
                float.TryParse(GetComponent<TMP_InputField>().text, out float value);
                SetParameter(value);
                break;
            case ValueSource.Checkbox:
                SetParameter(GetComponent<Toggle>().isOn);
                break;
        }
    }

    void SetParameter(float value)
    {
        switch (parameter)
        {
            case SettingParameter.DroneAmount:
                Settings.droneAmount = (int)value;
                break;
            case SettingParameter.DroneSpeed:
                Settings.droneSpeed = value;
                break;
            case SettingParameter.ResourceSpawnRate:
                Settings.resourceSpawnRate = value;
                break;
            case SettingParameter.SimulationTime:
                Settings.simulationTime = value;
                break;
        }
    }
    void SetParameter(bool value)
    {
        switch (parameter)
        {
            case SettingParameter.DronePathDisplay:
                Settings.dronePathDisplay = value;
                break;
        }
    }
}

public enum ValueSource
{
    Slider,
    InputText,
    Checkbox
}
