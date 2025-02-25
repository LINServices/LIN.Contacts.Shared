﻿using Microsoft.JSInterop;

namespace LIN.Contacts.Shared.Components;

public partial class ContactSquareComponent
{

    /// <summary>
    /// Modelo.
    /// </summary>
    [Parameter]
    public ContactModel? Modelo { get; set; }


    /// <summary>
    /// Acción al eliminar.
    /// </summary>
    [Parameter]
    public Action? OnDelete { get; set; }


    /// <summary>
    /// Enviar correo.
    /// </summary>
    private async void SendMail()
    {
        await JSRuntime.InvokeVoidAsync("enviarCorreo", Modelo?.Mails[0].Email);
    }

}