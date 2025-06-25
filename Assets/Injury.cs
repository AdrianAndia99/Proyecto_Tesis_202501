using UnityEngine;

public class Injury : MonoBehaviour
{
    public enum InjuryType
    {
        None,
        Bruise,
        Cut,
        Fracture
    }
   

    public InjuryType tipo;
    public int weight;
    void Start()
    {
        switch (tipo)
        {
            case InjuryType.Fracture:
                Debug.Log("Esta es una fractura");

                break;

            case InjuryType.Bruise:
                Debug.Log("Esta es un moreton xd");

                break;

        }
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
