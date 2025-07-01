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
    public static event Action OnCorrectCollider;
    public InjuryType type;
    public int weight;
    private void OnCollisionEnter(Collision collision)
    {
        if (type ==InjuryType.Wrist && collision.gameObject.tag== "Wrist")
        {
            Debug.Log("Wrist");
            typeNumb = (int)InjuryType.Wrist;
            OnCorrectCollider?.Invoke();
        }
        else if(type == InjuryType.Leg && collision.gameObject.tag == "Leg")
        {
            Debug.Log("Leg");
        }
        else if (type == InjuryType.Arm && collision.gameObject.tag == "Arm")
        {
            Debug.Log("Arm ");
        }
    }
    void Start()
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
    }
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
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
