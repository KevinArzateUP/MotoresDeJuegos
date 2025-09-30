using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    public Camera mainCamera;

    // Referencia al InputAction de Move
    public InputAction moveMouseAction;
    public InputAction clickAction;
    
    // Velocidad de mi objeto
    public float speed = 3f;


    

    private void OnEnable()
    {
        clickAction = InputSystem.actions.FindAction("ClickMouse");
        moveMouseAction = InputSystem.actions.FindAction("MousePos");
        
        clickAction.started += OnShoot;
    }

    private void OnDisable()
    {
        clickAction.started -= OnShoot;
    }

    private void Update()
    {
        
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Vector2 clickPosition = moveMouseAction.ReadValue<Vector2>();
        Ray ray = mainCamera.ScreenPointToRay(clickPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            StopAllCoroutines();
            StartCoroutine(RoutineMoveToPoint(hit.point));
        }
    }

    IEnumerator RoutineMoveToPoint(Vector3 point)
    {
        Vector3 origin = transform.position;
        float alpha = 0;
        float distance = Vector3.Distance(origin, point);
        float time = distance / speed;
        // V = d/t
        // t = d/V

        while (alpha<time)
        {
            alpha += Time.deltaTime;
            alpha = Mathf.Clamp(alpha, 0, 1);
            transform.position = Vector3.Lerp(origin, point, alpha);
            yield return new WaitForEndOfFrame();
        }
    }

    

}
