using DG.Tweening;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    Vector2 direction;
    Vector2 look;
    [SerializeField] string[] objectsToPick = { "medicine" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] private Transform cameraHolder; // el que rota en X (pitch)
    private float xRotation;
    private float currentYaw;
    private float targetYaw;
    private float yawSmoothVelocity;

    [SerializeField] private float mouseSensitivity =5f;
    [SerializeField] private float yawSmoothTime = 0.05f;
    [SerializeField] LayerMask layer;
    private bool holdingCrouch = false;

    [SerializeField] GameObject pickedObject;
    [SerializeField] GameObject selectedObject;

    bool isSelected;
    Rigidbody rbpicked;


   [SerializeField] GameRBEvent gameRBEventPick;
   [SerializeField] GameRBEvent gameRBEventThrow;

    private void Awake()
    {
        //rbpicked = pickedObject.GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        Debug.Log("On OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("On Disable");
    }

    void Update()
    {
        // Mouse input
        float mouseX = look.x * mouseSensitivity;
        float mouseY = look.y * mouseSensitivity;

        // Suavizar rotación en Y (horizontal)
        targetYaw += mouseX;
        currentYaw = Mathf.SmoothDampAngle(currentYaw, targetYaw, ref yawSmoothVelocity, yawSmoothTime);

        transform.rotation = Quaternion.Euler(0f, currentYaw, 0f);

        // Rotación vertical (pitch)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Ray ray = new Ray(cameraHolder.position, cameraHolder.forward);
        RaycastHit hit;
        Vector3 endPoint;//convert main variable

        if (Physics.Raycast(ray, out hit, 100f,layer))
        {
            Debug.DrawRay(cameraHolder.position, cameraHolder.forward * hit.distance, Color.red);
            Debug.Log("Raycast hit: " + hit.collider.name);
            endPoint = hit.point;

            //pickedObject.transform.position = endPoint;
            if(isSelected == false)
            {
                selectedObject = hit.collider.gameObject;
                
            }
            if (selectedObject != null) 
            {
                isSelected = true;
            }
           
        }
        else
        {
            Debug.DrawRay(cameraHolder.position, cameraHolder.forward * 15f, Color.green);
            endPoint = cameraHolder.position + cameraHolder.forward * 15f;
            isSelected = false;
            //selectedObject = null;
        }
        lineRenderer.SetPosition(0, cameraHolder.position);
        lineRenderer.SetPosition(1, endPoint);
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < objectsToPick.Length; i++) 
        { 
            //if(collision.gameObject.tag == objectsToPick[i] && pickedObject == null)
            {
                // pickedObject = collision.gameObject;
               // collision.transform.SetParent(pickedObject.transform);
                //set parent to move acording to other object in raycast
            }
        }
    }
   public void OnObjectActive()
    {
       rbpicked= pickedObject.GetComponent<Rigidbody>();
       rbpicked.isKinematic = true;

    }
    public void OnObjectThrow()
    {
       rbpicked = pickedObject.GetComponent<Rigidbody>();
       rbpicked.isKinematic = false;

    }
    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(" performed");
        }
        if ( selectedObject != null && isSelected==true)
        {
            Debug.Log("a " +  selectedObject.name + "---" + isSelected ) ;
           
            selectedObject.transform.SetParent(cameraHolder.transform);
            pickedObject = selectedObject;
            gameRBEventPick.Raise(rbpicked);

        }
       // if (pickedObject != null) { 
        // picked object set parent
        
    }
    public void OnLeave(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            Debug.Log(" cancelled");
            selectedObject.transform.SetParent(null);
            //gameRBEvent.Raise(rbpicked);
            gameRBEventThrow.Raise(rbpicked);
        }
       
        //pickedObject
    }
    void GrabObject()
    {

    }
    public void OnMovement(InputAction.CallbackContext move)
    {
        direction = move.ReadValue<Vector2>();


    }
    public void OnCrouch(InputAction.CallbackContext crouch)
    {
        if (crouch.started)
        {
            holdingCrouch = true;
        }
        if (crouch.canceled)
        {
            holdingCrouch = false;
            Debug.Log("soltao");
        }
        if(holdingCrouch == true) 
        { 
            cameraHolder.transform.position = new Vector3(cameraHolder.transform.position.x, 1.5f, cameraHolder.transform.position.z);
        }
        else
        {
            cameraHolder.transform.position = new Vector3(cameraHolder.transform.position.x, 2.5f, cameraHolder.transform.position.z);
        }
    }
    public void FixedUpdate()
    {
        Vector3 move = transform.right * direction.x + transform.forward * direction.y;
        move.y = 0f;
        myRBD.linearVelocity = new Vector3(move.x * velocityModifier, myRBD.linearVelocity.y, move.z * velocityModifier);
        /* Vector3 camForward = cameraTransform.forward;
         Vector3 camRight = cameraTransform.right;
        
         // Eliminar la componente Y (para evitar que se mueva hacia arriba/abajo)
         camForward.y = 0f;
         camRight.y = 0f;
        
         camForward.Normalize();
         camRight.Normalize();
        
         // Combinar direcciones
         Vector3 move = camForward * direction.y + camRight * direction.x;
        
         // Mover el Rigidbody
         myRBD.linearVelocity = new Vector3(move.x * velocityModifier, myRBD.linearVelocity.y, move.z * velocityModifier);
        
         // Rotar hacia la dirección de movimiento (si hay)
         if (direction.y > 0.1f || direction.x != 0)
         {
             Quaternion targetRotation = Quaternion.LookRotation(move);
             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
         }rotación camara cinemachine */
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();


    }
}
