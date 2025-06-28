using UnityEngine;
using TMPro;

public class ResultsDisplay : MonoBehaviour
{
    [Header("Referencia al SO")]
    [SerializeField] private ProgressDataSO progressData;
    [Header("Texto para mostrar el porcentaje")]
    [SerializeField] private TextMeshProUGUI percentageText;

    void Start()
    {
        if (progressData != null && percentageText != null)
        {
            float displayPercent = Mathf.Round(progressData.progress * 1000f) / 10f;
            percentageText.text = displayPercent.ToString("F1") + "%";
        }
    }
}
