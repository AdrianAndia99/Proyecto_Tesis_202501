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
    [Header("SO de textos de resultado")]
    [SerializeField] private ResultTextSO resultTextSO;

    [Header("Texto para mostrar el mensaje de resultado")]
    [SerializeField] private TextMeshProUGUI resultText;

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
            if (resultTextSO != null && resultText != null)
            {
                float percent = progressData.progress * 100f;
                if (percent >= 68f)
                {
                    resultText.text = resultTextSO.excelente;
                }
                else if (percent >= 33f)
                {
                    resultText.text = resultTextSO.poderMejorar;
                }
                else
                {
                    resultText.text = resultTextSO.repetirEscenario;
                }
            }
        }
    }
}
