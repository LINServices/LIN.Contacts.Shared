using Microsoft.JSInterop;

namespace LIN.Contacts.Shared.Components;


public partial class ContactComponent
{


    /// <summary>
    /// Modelo.
    /// </summary>
    [Parameter]
    public ContactModel? Modelo { get; set; }



    /// <summary>
    /// Modelo.
    /// </summary>
    [Parameter]
    public Action<ContactModel>? OnClick { get; set; }





    /// <summary>
    /// Imagen del contacto en base 64.
    /// </summary>
    private string Base64 => Convert.ToBase64String(Modelo?.Picture ?? []);



    /// <summary>
    /// Abrir el contacto.
    /// </summary>
    private void Open()
    {

        // Validar el modelo.
        if (Modelo == null)
            return;

        OnClick(Modelo);
        // Abrir.


    }



    /// <summary>
    /// Abrir mail.
    /// </summary>
    private async void Mail() => await JSRuntime.InvokeVoidAsync("enviarCorreo", Modelo?.Mails[0].Email);



    /// <summary>
    /// Abrir llamada.
    /// </summary>
    private async void Call() => await JSRuntime.InvokeVoidAsync("llamar", Modelo?.Phones[0].Number);


}