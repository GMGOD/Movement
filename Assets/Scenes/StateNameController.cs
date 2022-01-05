using UnityEngine;
using TMPro;

public class StateNameController : MonoBehaviour
{
    public static string nombreUsuario;

    public TextMeshProUGUI textDisplay;

    private void Start()
    {
        if (!string.IsNullOrEmpty(nombreUsuario))
        {
            textDisplay.GetComponent<TextMeshProUGUI>().text = "Bienvenido " + nombreUsuario + "!";
        }
    }
}
