using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    [SerializeField]private LayerMask mousePlaneLayerMask;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        transform.position = MouseWorld.GetMousePosition();
    }

    public static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }
}
