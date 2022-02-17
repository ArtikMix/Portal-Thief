using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane_logic : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject portalVFX;
    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("Click on " + transform.name);
        PortalSpawn();
    }

    private void PortalSpawn()
    {
        if (transform.GetChild(0).name[0] == 'I')
        {
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(90f, 0f, 0f);
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);
            Instantiate(portalVFX, position, rotation);
        }
    }
}
