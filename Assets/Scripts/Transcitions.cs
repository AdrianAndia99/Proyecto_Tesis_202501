using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class Transcitions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject introduction;
    [SerializeField] GameObject finalCanvas;
    [SerializeField] GameObject initCanvas;
    [SerializeField] GameObject tempCanvas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveShowIntroduction()
    {

        introduction.transform.DOMoveX(finalCanvas.transform.position.x, 0.4f);
    }
    public void MoveHideIntroduction()
    {
        introduction.transform.DOMoveX(initCanvas.transform.position.x, 0.4f);
    }
    public void MoveInit(GameObject canvasObjReference)
    {
        canvasObjReference.transform.DOMoveX(initCanvas.transform.position.x, 0.4f);
    }
    public void MoveFinal(GameObject canvasObjReference)
    {
        canvasObjReference.transform.DOMoveX(finalCanvas.transform.position.x, 0.4f);
    }
    public void MoveTemp(GameObject canvasObjReference)
    {
        canvasObjReference.transform.DOMoveX(tempCanvas.transform.position.x, 0.4f);
    }
}

