using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI
using Vuforia;

public class TargetTracker : MonoBehaviour
{
    public static bool isTargetVisible = false;
    public GameObject uiButton; // Asigna aquí el botón desde el Inspector

    void Start()
    {
        var observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (uiButton != null)
        {
            uiButton.SetActive(false); // Oculta el botón al inicio
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        isTargetVisible = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        if (uiButton != null)
        {
            uiButton.SetActive(isTargetVisible); // Muestra u oculta el botón
        }
    }
}
