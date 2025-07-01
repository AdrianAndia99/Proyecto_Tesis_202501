using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    [Header("Toggles")]
    [SerializeField] private Toggle toggle1;
    [SerializeField] private Toggle toggle2;
    [SerializeField] private Toggle toggle3;

    [Header("Botón para finalizar")]
    [SerializeField] private GameObject finishButton;

    [Header("Referencia al SO")]
    [SerializeField] private ProgressDataSO progressData;
    [SerializeField] private ProgressBarIndicator progressBarIndicator;
    private Toggle[] actions;

    void Awake()
    {
        finishButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) toggle1.isOn = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) toggle2.isOn = true;
        if (Input.GetKeyDown(KeyCode.Alpha3)) toggle3.isOn = true;

        if (toggle1.isOn && toggle2.isOn && toggle3.isOn)
        {
            finishButton.SetActive(true);
        }
        else
        {
            finishButton.SetActive(false);
        }
    }

    public void OnFinishButtonClick()
    {
        if (progressData != null && progressBarIndicator != null)
        {
            progressData.progress = progressBarIndicator.GetProgress();
        }
        SceneManager.LoadScene("Results");
    }
    private void OnEnable()
    {
        Injury.OnCorrectCollider += ValidateAction;
    }
    private void OnDisable()
    {
        Injury.OnCorrectCollider -= ValidateAction;
    }
    void ValidateAction()
    {
        toggle1.isOn = true;

    }
}
