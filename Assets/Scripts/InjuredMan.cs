using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InjuredMan : MonoBehaviour
{
    [SerializeField] List<GameObject> injuries = new List<GameObject>();
    [SerializeField] Rigidbody rb;

    [SerializeField] Material injuredMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DORotate(new Vector3(-90, transform.position.y, transform.transform.position.z), 2, RotateMode.Fast);
        transform.DOMoveY(0.32f, 3);
    }


    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medicine")
        {
            collision.gameObject.SetActive(false);
            //  StartCoroutine(HandleInjury());
        }
        {

        }
    }
    void HandleInjury()
    {

    }
    IEnumerator Healing()
    {
        yield return new WaitForSeconds(2);
        for(int i = 0; i<injuries.Count; i++)
        {
            
        }
        
    }
}
/*foreach (GameObject injury in injuries)
            {
                injury.SetActive(true);
            }
            rb.isKinematic = true;
            rb.useGravity = false;
            transform.DORotate(new Vector3(-90, transform.position.y, transform.transform.position.z), 2, RotateMode.Fast);
            transform.DOMoveY(0.32f, 3);*/