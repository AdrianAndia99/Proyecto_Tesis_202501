using System;
using UnityEngine;

public class Injury : MonoBehaviour
{
    public enum InjuryType
    {
        None,
        Bruise,
        Cut,
        Fracture,
        Wrist,
        Leg,
        Arm,
    }
    int typeNumb;
    public static event Action<InjuryType, bool> OnCorrectCollider;
    [SerializeField] private InjuryType type;
    [SerializeField] private int weight;
    [Header("Layer esperado para colisión correcta")]
    [SerializeField] private int expectedLayer;
    private void OnCollisionEnter(Collision collision)
    {
        bool correct = false;
        if (collision.gameObject.tag == type.ToString() && collision.gameObject.layer == (int)expectedLayer)
        {
            Debug.Log($"{type} correcto en tag y layer");
            typeNumb = (int)type;
            correct = true;
        }
        OnCorrectCollider?.Invoke(type, correct);
    }
    /*void Start()
    {
        switch (type)
        {
            case InjuryType.Fracture:
                Debug.Log("Esta es una fractura");

                break;

            case InjuryType.Bruise:
                Debug.Log("Esta es un moreton xd");

                break;

        }
        typeNumb = (int)InjuryType.Wrist;
        Debug.Log("typeNumb" +  typeNumb);
    }*/

    /* private void OnTriggerEnter(Collider other)
     {
         if (tipo == TipoCaja.TipoA || tipo == TipoCaja.TipoB)
         {
             if (other.tag == "star")
             {
                 SetWeight(3, "estrellita donde estas");
             }
             else if (other.tag == "ship")
             {
                 SetWeight(1, "nave");
             }
             else if (other.tag == "moon")
             {
                 SetWeight(10, "luna");
             }
             else if (other.tag == "alien")
             {
                 SetWeight(4, "alien");
             }
             else if (other.tag == "saturn")
             {
                 SetWeight(8, "saturno");
             }
             else
             {
                 Debug.Log("xd");
             }
         }
     }

     private void SetWeight(int weight, string messageDebug = "")
     {
         Debug.Log(messageDebug);
         this.weight = weight;

     }
 */   
}