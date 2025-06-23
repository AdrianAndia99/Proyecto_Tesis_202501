using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InjuredMan : MonoBehaviour
{
    [SerializeField] List<GameObject> injuries = new List<GameObject>();
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DORotate(new Vector3(-90, transform.position.y, transform.transform.position.z), 2, RotateMode.Fast);
        transform.DOMoveY(0.32f,3);
    }

    
    void Update()
    {
        
    }
}
