using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField DelayField;
    public InputField SpeedField;
    public InputField DistanceField;

    private float newValue;

    private void Start()
    {
        DelayField.onValueChanged.AddListener(delegate { if (float.TryParse(DelayField.text, out newValue)) { MainManager.Instance.SpawnTimeDelay = newValue; } });
        SpeedField.onValueChanged.AddListener(delegate { if (float.TryParse(SpeedField.text, out newValue)) { MainManager.Instance.CubeSpeed = newValue; } });
        DistanceField.onValueChanged.AddListener(delegate { if (float.TryParse(DistanceField.text, out newValue)) { MainManager.Instance.CubeDistance = newValue; } });
    }
}
