using UnityEngine;
using TMPro;

public class ResultsDisplay : MonoBehaviour
{
    [Header("Referencia al SO")]
    [SerializeField] private ProgressDataSO progressData;
    [Header("Texto para mostrar el porcentaje")]
    [SerializeField] private TextMeshProUGUI percentageText;
    [Header("Texto para mostrar el tiempo")]
    [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
        if (progressData != null)
        {
            if (percentageText != null)
            {
                float displayPercent = Mathf.Round(progressData.progress * 1000f) / 10f;
                percentageText.text = displayPercent.ToString("F1") + "%";
            }
            if (timeText != null)
            {
                int minutes = Mathf.FloorToInt(progressData.time / 60f);
                int seconds = Mathf.FloorToInt(progressData.time % 60f);
                timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
    }
}
