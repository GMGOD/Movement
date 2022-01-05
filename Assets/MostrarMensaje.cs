using UnityEngine;

public class MostrarMensaje : MonoBehaviour
{
    public InputManager inputManager;
    public GameObject menu;
    public GameObject input;
    private bool isOpen;
    private int counter;
    private bool isTrigger;

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        menu.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
        menu.SetActive(false);
    }

    public void OnEInput(bool eInput)
    {
        if (!isTrigger) return;

        isOpen = eInput;
        counter++;
        if (counter > 1)
        {
            counter = 0;
            input.SetActive(false);
            inputManager.EnableInputsPlayer();
        }
        else
        {
            input.SetActive(true);
            menu.SetActive(false);
            inputManager.DisabledInputsPlayer();
        }
    }
}
