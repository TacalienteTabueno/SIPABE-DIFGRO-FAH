using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Management; 



// ⢿⣯⣤⣾⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣱⡿⣡⡟⣿⣿⣿⣿⣧⢿⣿⣿⣿⣌⠈⢻⣿⣿⣿⡿⣿⣿⣿⣷⣌⠺⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⣿⡿⠿⠛⡋⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⢏⣼⢏⣼⣿⠁⣿⣿⡜⣿⣿⡌⢹⣿⣿⣿⣆⣆⣿⣿⣸⣷⢹⣿⢿⣿⣿⣿⣦⣭⣛⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⣿⣿⡿⠋⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⡿⣣⢞⣵⣿⣿⡏⡄⢿⣿⡇⡹⣿⣷⠇⢻⣿⢻⣿⣿⢸⡇⡏⣿⣾⣿⣮⠛⣛⣛⣛⣩⣵⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⣿⣿⠇⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠣⠂⢔⡅⣿⣿⣿⣿⢧⣿⢸⣿⡇⣷⢹⣿⢸⢂⢿⡜⣿⣿⡇⡇⣧⣿⠀⣿⢻⣷⣜⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⣿⣧⣾⣿⣿⣿⠏⣿⣿⣿⣿⣿⣿⣿⠏⣠⡄⣿⢧⢸⣿⣿⣿⢸⣿⡏⣿⡇⣿⣧⢻⡆⢸⡎⣇⠹⣿⣧⠃⢿⢸⠘⢸⡎⣽⣛⠳⠬⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⣿⠿⣟⣫⢁⣾⢸⣿⣿⣿⣿⡿⣿⣥⢠⣿⡇⣿⢸⣼⣿⣿⡇⣾⣿⣧⢹⡇⣿⡿⠎⣿⢸⣥⠸⣧⢻⣿⣧⢸⠈⠘⠅⢻⡜⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⣶⣿⠿⢏⣾⣿⢸⣿⣿⣿⣿⡇⢿⣿⣼⠿⠇⡇⢾⡇⠏⣿⣧⣿⣿⣿⡞⡇⠉⣀⣭⢸⢨⠍⠃⢽⡌⣿⠘⢸⠀⡀⠀⢠⣑⠜⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠋⠀⠀⣼⡿⠃⡟⠀⣿⣿⣿⢱⠸⡇⠛⠛⠀⠇⠒⠨⠀⣿⢹⣿⣿⣿⡇⠁⡿⠛⠉⠀⠀⢀⣁⠀⠡⠉⠀⢸⢰⠇⢸⣦⣍⢷⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠜⠉⠀⡜⠀⡀⣿⣿⠉⠸⠁⠃⠀⠀⠀⠀⠀⠀⠀⢻⢸⣿⣿⡿⢰⡆⠔⢁⠀⠀⡀⢸⣿⢀⡇⡄⡀⡰⠈⢀⢸⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠆⠹⢸⣿⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⢻⠿⠃⠘⢵⣆⠸⠷⠤⠴⢞⣡⣾⠇⡄⡇⠃⢈⢸⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⣀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⢠⢠⣤⣵⣆⠀⠀⠀⠀⠀⠒⠿⢿⠟⣴⢃⠃⢺⠀⠜⢿⣿⣿⣿⣿⣟⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠻⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣷⣤⣄⣀⣀⣀⣤⣴⣿⣿⢸⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⣿⣮⠻⠿⠿⠻⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⣤⣀⡀⠀⠀⣀⣀⣴⣿⣿⣿⣿⣿⢼⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠈⠀⠀⠀⠀⠀⠀⠑⢭⡛⢿⣿⣿⣷⣾⣿⣿⣶⣮⢻⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡛⢿⣋⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⢮⡛⢿⣿⣿⣿⣿⣿⢂⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣾⣿⣿⡿⠿⠿⣛⠋⣠⣿⢏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠳⢬⡻⢿⣿⣿⣘⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⣿⣿⣦⣀⠩⠭⣭⣭⣿⣷⣶⣶⣫⠭⣢⣾⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠳⢍⡻⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣷⣬⣝⣛⣛⣛⣛⣭⣵⣾⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠒⢍⠻⣿⣿⣿ No hay peor maldicion que el amor
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣶⣤⣤⣶⣾⣿⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠂⠙⢿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⢿⣿⣿⣿⣿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈




public class AuditoriaSistema
{
    public string UsuarioWindows { get; set; }
    public string NombreEquipo { get; set; }
    public string IPLocal { get; set; }
    public string DireccionMAC { get; set; }
    public string SerialHardware { get; set; }
    public string UUID { get; set; }
    public string Procesador { get; set; }
    public string MemoriaRAM { get; set; }


    public AuditoriaSistema()
    {
        this.UsuarioWindows = Environment.UserName;
        this.NombreEquipo = Environment.MachineName;
        this.IPLocal = ObtenerIP();
        this.DireccionMAC = ObtenerMAC();
        this.SerialHardware = ObtenerSerialBIOS();
        this.UUID = ObtenerUUID();
        this.Procesador = ObtenerProcesador();
        this.MemoriaRAM = ObtenerMemoriaRAM();
    }

    private string ObtenerIP()
    {
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) return ip.ToString();
            }
        }
        catch { }
        return "Desconocida";
    }


    private string ObtenerMAC()
    {
        try
        {
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    return nic.GetPhysicalAddress().ToString();
            }
        }
        catch { }
        return "000000000000";
    }

    private string ObtenerSerialBIOS()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
            {
                foreach (var obj in searcher.Get()) return obj["SerialNumber"].ToString().Trim();
            }
        }
        catch { }
        return "N/A";
    }



    private string ObtenerUUID()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct"))
            {
                foreach (var obj in searcher.Get()) return obj["UUID"].ToString().Trim();
            }
        }
        catch { }
        return "N/A";

    }
    private string ObtenerProcesador()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
            {
                foreach (var obj in searcher.Get())
                {
                    var val = obj["Name"];
                    return val != null ? val.ToString().Trim() : "N/A";
                }
            }
        }
        catch { }
        return "N/A";
    }

    private string ObtenerMemoriaRAM()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem"))
            {
                foreach (var obj in searcher.Get())
                {
                    if (obj["TotalPhysicalMemory"] != null)
                    {
                        // Convertir de Bytes a Gigabytes (1024^3 = 1073741824) porque si no luego nos vamos a estar haciendo bolas con lam operacion
                        double bytes = Convert.ToDouble(obj["TotalPhysicalMemory"]);
                        double gigabytes = Math.Round(bytes / 1073741824.0, 2);
                        return $"{gigabytes} GB";
                    }
                }
            }
        }
        catch { }
        return "N/A";
    }
}


//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣤⣤⣀⠀⠀⠀⣀⣤⣴⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣦⣤⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣷⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢶⣤⣄⡀⠀⠀
//⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣵⢹⠀⠀
//⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⢟⡿⢰⣾⣾⡆⠀
//⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⢿⣿⢿⣿⠟⠉⠉⠀⠀⠘⣴⢸⣿⣟⡇⠀
//⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠛⠉⠉⠉⠉⠁⠀⠈⠁⠀⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣸⣿⡇⡇⠀
//⢠⡀⠀⠀⠀⢈⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠋⢫⡇⠀
//⠀⠈⠙⠛⠛⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠞⠉⡇⠀⣨⡇⠀
//⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⣀⣀⣤⣤⣤⣤⣀⠀⠀⠀⠀⢀⢞⡟⠁⠀⢆⣧⢀⡏⡇⠀
//⠀⠀⠀⠀⣿⣿⠏⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠀⣀⠴⠊⠉⠁⠠⠶⢂⣉⠉⠉⡆⠀⠀⠀⣞⠎⠁⢀⣠⣜⣻⢸⡇⢣⠀
//⠀⠀⠀⢸⡿⡼⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠈⠙⡾⠀⠀⠀⠘⡉⣠⠞⠉⠀⠀⢸⣾⡇⣼⠀
//⠀⠀⠀⢸⠃⡇⠀⣿⡿⣿⣿⣿⣿⡿⠟⠻⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⢀⣠⠤⠶⠖⠒⠒⣀⠀⠀⠀⠀⠳⡉⠒⠀⠀⠀⣸⣿⡇⠈⡇
//⠀⠀⠀⠸⠀⠇⠀⢸⡇⠙⣿⣿⣿⢡⢶⣶⣄⠉⢻⡇⠀⠀⠀⠀⠀⠀⠰⠋⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠀⠀⠙⢆⡀⠀⠀⣿⢹⣗⣇⣇
//⠀⠀⠀⠀⠀⠀⠀⠀⠳⠀⠈⠻⣯⣸⠟⣡⢾⠗⠈⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⡦⢰⠇⢸⢟⣿⢿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣆⠰⡟⠙⢎⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⢀⠜⠁⠀⠀⢠⣾⠧⡼
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢆⠳⢤⣀⢱⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠃⠀⠀⠀⠀⣾⡏⢈⡇
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢇⢀⣤⣝⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠀⣀⠀⠀⢰⣸⠁⡿⠁
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⣶⣿⡷⢠⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣈⠤⠈⠁⠀⢀⠏⠁⢰⠁⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⣍⣛⣁⢎⡟⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠒⠒⠒⠉⠉⣥⣤⡶⠟⠀⠀⡘⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠽⡀⠉⠀⠙⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠀⠈⠓⠒⠒⠳⡮⢍⡒⠢⠤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡀⠀⠀⠀⠀⠀⠹⣆⠙⢦⡀⠀⠈⠉⠑⠒⠢⠤⢄⣀⣀⠀⠀⣀⡴⠋⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣶⣶⣤⣤⣤⣈⣦⠀⠙⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⠁⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣦⣤⣤⣄⣀⣀⣀⡀⣨⣤⣀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⡆⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡇⠀⠀⠀⠀⠀Entonces maldiceme un poco.....
//⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣱⡀⠀⠀⠀⠀(Reproduzca Amárrame de Mon Laferte y Juanes)