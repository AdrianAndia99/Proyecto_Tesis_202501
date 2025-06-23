using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    Vector2 direction;
    Vector2 look;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    [SerializeField] private Transform cameraHolder; // el que rota en X (pitch)
    private float xRotation;
    private float currentYaw;
    private float targetYaw;
    private float yawSmoothVelocity;

    [SerializeField] private float mouseSensitivity = 10f;
    [SerializeField] private float yawSmoothTime = 0.05f;

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

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawRay(cameraHolder.position, cameraHolder.forward * hit.distance, Color.red);
            Debug.Log("Raycast hit: " + hit.collider.name);
        }
        else
        {
            Debug.DrawRay(cameraHolder.position, cameraHolder.forward * 15f, Color.green);
        }
    }
    public void OnMovement(InputAction.CallbackContext move)
    {
        direction = move.ReadValue<Vector2>();


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
        //Debug.Log("Mouse look: " + look);

    }
}
