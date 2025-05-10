using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance;

    public bool IsBusy { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetBusy(bool value)
    {
        IsBusy = value;
    }
}
