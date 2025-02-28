using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgentViewer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static AgentViewer instance;

    private void Awake()
    {
        if (instance != null && instance != this) 
            Destroy(this);
        else 
            instance = this;
    }

    [SerializeField] private TextMeshProUGUI hoverInfo;
    public GameObject target;


    private void Update()
    {
        hoverInfo.text = "";

        if (target != null)
            hoverInfo.text = target.name;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
        target = eventData.pointerEnter;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
