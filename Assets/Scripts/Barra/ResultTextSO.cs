using UnityEngine;

[CreateAssetMenu(fileName = "ResultTextSO", menuName = "Barra/ResultTextSO")]
public class ResultTextSO : ScriptableObject
{
    [TextArea]
    public string excelente;
    [TextArea]
    public string poderMejorar;
    [TextArea]
    public string repetirEscenario;
}
