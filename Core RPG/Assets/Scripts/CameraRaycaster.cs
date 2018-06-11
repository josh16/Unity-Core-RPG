using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    public Layer[] layerPriorities = {
        Layer.Enemy,
        Layer.Walkable
    };

    [SerializeField] // keeps it private 
    float distanceToBackground = 100f;

    Camera viewCamera; 

    RaycastHit m_hit; // structure used to get information back from a raycast
    public RaycastHit hit // returns the raycast on what it hits
    {
        get { return m_hit; }
    }

    Layer m_layerHit;
    public Layer layerHit
    Layer m_layerHit; // Referece to layer
    {
        get { return m_layerHit; }
    }

    void Start() // TODO Awake?
    {
        viewCamera = Camera.main; // On Start, we initialize the maon camera
    }

    void Update()
    {
        // Look for and return priority layer hit 
        foreach (Layer layer in layerPriorities) // Checks each layer in "Layer"
        {
            //if this hits a layer, return it.
            var hit = RaycastForLayer(layer); 
            if (hit.HasValue)
            {
                m_hit = hit.Value;
                m_layerHit = layer;
                return;
            }
        }

        // Otherwise return background hit
        m_hit.distance = distanceToBackground;
        m_layerHit = Layer.RaycastEndStop; 
    }

    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; // See Unity docs for mask formation
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // used as an out parameter
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
}
