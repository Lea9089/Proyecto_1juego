using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Variables privadas
    private bool isOn, isEnabled;
    private Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        SetState(false);
        isOn = false;
        isEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Switch();
    }

    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnabled)
        {
            isOn = !isOn;
            SetState(isOn);
        }
    }

    public void SetState(bool _state)
    {
        lightComponent.enabled = _state;
    }

    public void SetIsEnabled(bool _state)
    {
        isEnabled = _state;
    }
}
