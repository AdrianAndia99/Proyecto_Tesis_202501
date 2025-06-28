using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProgressBarIndicator : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private RectTransform indicator;
    [SerializeField] private TextMeshProUGUI percentageText;

    [Header("Tiempo y porcentaje")]
    [SerializeField] private float interval = 3f;
    [SerializeField] private float percentageDecrease = 0.005f;

    [Header("Posición del indicador")]
    [SerializeField] private float startY = 200f;
    [SerializeField] private float endY = -200f;

    [SerializeField] private float progress = 1f;
    public float GetProgress() => progress;
    
    private void Start()
    {
        if (indicator == null) Debug.LogError("No se ha asignado el indicador");
        if (percentageText == null) Debug.LogError("No se ha asignado el texto de porcentaje");

        UpdateUI(); // para iniciar en 100%
        StartCoroutine(UpdateProgress());
    }

    private IEnumerator UpdateProgress()
    {
        while (progress > 0f)
        {
            yield return new WaitForSeconds(interval);

            progress -= percentageDecrease;
            progress = Mathf.Clamp01(progress);

            UpdateUI();

            if (progress == 0f)
            {
                SceneManager.LoadScene("Results");
            }
        }
    }

    private void UpdateUI()
    {
        float newY = Mathf.Lerp(endY, startY, progress);
        indicator.anchoredPosition = new Vector2(indicator.anchoredPosition.x, newY);

        float displayPercent = Mathf.Round(progress * 1000f) / 10f;
        percentageText.text = displayPercent.ToString("F1") + "%";
    }
}