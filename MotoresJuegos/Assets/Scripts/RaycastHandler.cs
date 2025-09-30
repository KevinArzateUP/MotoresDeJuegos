using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public LineRenderer lineRenderer;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayo = new Ray(transform.position,transform.forward);
        RaycastHit hit;
        
        if(Physics.Raycast(rayo, out hit))
        {
            // Si estoy chocando con algo
            Debug.Log(hit.point);
        }
    }

    
}
