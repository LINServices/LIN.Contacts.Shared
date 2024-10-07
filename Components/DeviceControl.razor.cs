using LIN.Types.Contacts.Transient;

namespace LIN.Contacts.Shared.Components;

public partial class DeviceControl
{

    /// <summary>
    /// Modelo del producto.
    /// </summary>
    [Parameter]
    public DeviceModel? Model { get; set; }


    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<DeviceModel?>? OnClick { get; set; }


    /// <summary>
    /// Enviar el evento.
    /// </summary>
    private void SendEvent()
    {
        OnClick?.Invoke(Model);
    }


    /// <summary>
    /// Obtener el icono.
    /// </summary>
    private string GetImage()
    {

        // Segun.
        return (Model?.Platform.ToLower().Trim()) switch
        {
            // Android.
            "android" => "./img/android.png",
            // Windows
            "windows" => "./img/windows.png",
            // Windows
            "web" => "./img/web.png",
            _ => "",
        };
    }

}