using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLenght;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, maximumLenght))
            {
                RoateToMouseDirection(gameObject, hit.point);

            }
            else 
            {
                var pos = rayMouse.GetPoint (maximumLenght);
                RoateToMouseDirection(gameObject, pos);

            }

        }
        else
        {
            Debug.Log("Sem camera");
        }
    }
    void RoateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
    public Quaternion GetRotation()
    {
        return rotation;
    }
}
