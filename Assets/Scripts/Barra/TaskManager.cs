using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    [Header("Toggles")]
    [SerializeField] private Toggle[] toggles = new Toggle[3];

    [Header("Botón para finalizar")]
    [SerializeField] private GameObject finishButton;

    [Header("Referencia al SO")]
    [SerializeField] private ProgressDataSO progressData;
    [SerializeField] private ProgressBarIndicator progressBarIndicator;

    void Awake()
    {
        finishButton.SetActive(false);
    }
    private void OnEnable()
    {
        Injury.OnCorrectCollider += ValidateAction;
    }
    private void OnDisable()
    {
        Injury.OnCorrectCollider -= ValidateAction;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) toggles[0].isOn = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) toggles[1].isOn = true;
        if (Input.GetKeyDown(KeyCode.Alpha3)) toggles[2].isOn = true;

        bool allOn = true;
        for (int i = 0; i < toggles.Length; i++)
        {
            if (!toggles[i].isOn) allOn = false;
        }
        finishButton.SetActive(allOn);
    }

    public void OnFinishButtonClick()
    {
        if (progressData != null && progressBarIndicator != null)
        {
            progressData.progress = progressBarIndicator.GetProgress();
        }
        if (progressData != null && GameManager.Instance != null)
        {
            progressData.time = GameManager.Instance.GetTime();
        }
        SceneManager.LoadScene("Results");
    }

    public void ValidateAction(Injury.InjuryType type, bool correct)
    {
        if (correct)
        {
            int idx = -1;
            switch(type)
            {
                case Injury.InjuryType.Wrist: idx = 0; break;
                case Injury.InjuryType.Leg: idx = 1; break;
                case Injury.InjuryType.Arm: idx = 2; break;
            }
            if (idx >= 0 && idx < toggles.Length)
            {
                toggles[idx].isOn = true;
                Debug.Log($"Acción correcta detectada, toggle {idx+1} activado.");
            }
        }
        else
        {
            if (progressBarIndicator != null)
            {
                progressBarIndicator.DecreaseProgress(0.1f);
                Debug.Log("Colisión incorrecta: progreso disminuido en 10%.");
            }
        }
    }
}
