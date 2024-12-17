using UnityEngine;
using TMPro;
using System.Reflection;

public class VariableDisplay : MonoBehaviour
{
    public TMP_Text text;
    [SerializeField]
    public object targetObject;
    public string variableName;
    public string label;

    private FieldInfo fieldInfo;
    private PropertyInfo propertyInfo; 

    void Awake()
    {
        if (string.IsNullOrEmpty(label))
        {
            label = "MISSING LABEL: ";
        }

        if (targetObject != null && !string.IsNullOrEmpty(variableName))
        {
            // Attempt to get field or property information
            fieldInfo = targetObject.GetType().GetField(variableName);
            propertyInfo = targetObject.GetType().GetProperty(variableName);

            if (fieldInfo == null && propertyInfo == null)
            {
                Debug.LogError($"VariableDisplay: No field or property '{variableName}' found on {targetObject}.");
            }
        }
    }

    void Update()
    {
        if (targetObject != null && text != null)
        {
            object value = null;

            if (fieldInfo != null)
            {
                value = fieldInfo.GetValue(targetObject);
            }
            else if (propertyInfo != null)
            {
                value = propertyInfo.GetValue(targetObject);
            }

            if (value != null)
            {
                text.text = $"{label}{value}";
            }
            else
            {
                text.text = $"{label}N/A";
            }
        }
    }
}