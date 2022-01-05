using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTransfer : MonoBehaviour
{
    private string nombre;
    public GameObject inputField;
    public TextMeshProUGUI textDisplay;
    public MostrarMensaje mostrarMensaje;

    public void GuardarNombre()
    {
        nombre = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<TextMeshProUGUI>().text = "Bienvenido " + nombre + "!";
        mostrarMensaje.OnEInput(false);
        StateNameController.nombreUsuario = nombre;
    }
}
