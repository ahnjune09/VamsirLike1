using UnityEngine;

public class UI : MonoBehaviour, IUI
{
    private void Start()
    {
        Initialize();
    }

    public static DebugController Debug { get; private set; }
    public void Initialize()
    {
        SetDebugController();
        Open();
    }

    public void Open()
    {
        
    }

    public void Close()
    {

    }

    public void SetDebugController()
    {
        Debug = transform.GetComponentInChildren<DebugController>();
        Debug.Initialize();
    }
}
