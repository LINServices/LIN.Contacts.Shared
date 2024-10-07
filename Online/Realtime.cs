using LIN.Types.Contacts.Transient;
using SILF.Script.Interfaces;

namespace LIN.Contacts.Shared.Online;

public class Realtime
{

    /// <summary>
    /// Id del dispositivo.
    /// </summary>
    public static string DeviceName { get; set; } = string.Empty;


    /// <summary>
    /// Id del dispositivo.
    /// </summary>
    public static string DeviceKey { get; private set; } = string.Empty;


    /// <summary>
    /// Funciones
    /// </summary>
    public static List<IFunction> Actions { get; set; } = [];


    /// <summary>
    /// Hub de tiempo real.
    /// </summary>
    public static LIN.Access.Contacts.Hubs.ContactsAccessHub? InventoryAccessHub { get; set; } = null;


    /// <summary>
    /// Iniciar el servicio.
    /// </summary>
    public static void Start()
    {

        // Validar si ya existe el hub.
        if (InventoryAccessHub != null)
            return;

        // Llave.
        if (string.IsNullOrWhiteSpace(DeviceKey))
            DeviceKey = Guid.NewGuid().ToString();

        // Generar nuevo hub.
        InventoryAccessHub = new(Session.Instance.Token, new()
        {
            Name = "Navegador Web",
            LocalId = DeviceKey,
            Platform = "Web"
        });

        // Evento.
        InventoryAccessHub.On += OnReceiveCommand;

    }


    /// <summary>
    /// Construye las funciones.
    /// </summary>
    public static void Build(IEnumerable<IFunction> functions)
    {
        Actions = functions.ToList();
    }


    /// <summary>
    /// Evento al recibir un comando.
    /// </summary>
    /// <param name="e">Comando</param>
    private static void OnReceiveCommand(object? sender, CommandModel e)
    {

        // Generar la app.
        var app = new SILF.Script.App(e.Command);

        // Agregar funciones del framework de Inventory.
        app.AddDefaultFunctions(Actions);

        // Ejecutar app.
        app.Run();

    }


    /// <summary>
    /// Cerrar conexión.
    /// </summary>
    public static void Close()
    {
        DeviceKey = string.Empty;
        InventoryAccessHub?.Dispose();
        InventoryAccessHub = null;
    }

}