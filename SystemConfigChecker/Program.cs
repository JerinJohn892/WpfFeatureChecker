using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SystemConfigChecker;

public static class Program
{
    private static readonly string LogFile = Path.Combine(AppContext.BaseDirectory, "system_config.log");

    public static (string systemName,
        string macAddress,
        string publicIP,
        string localIP,
        string hardDiskSerialNumber,
        string baseBoardSerialNumber
        ) GetSystemConfig()

    {
        var systemName = string.Empty;
        var macAddress = string.Empty;
        var publicIP = string.Empty;
        var localIP = string.Empty;
        var hardDiskSerialNumber = string.Empty;
        var baseBoardSerialNumber = string.Empty;

        try
        {
            Log("System configuration check started");
            systemName = LogResult("System Name", GetSystemName);
            macAddress = LogResult("MAC Address", GetMacAddress);
            publicIP = LogResult("Public IP", GetPublicIp);
            localIP = LogResult("Local IP", GetLocalIp);
            hardDiskSerialNumber = LogResult("Hard Disk Serial Number", GetHardDiskSerialNumber);
            baseBoardSerialNumber = LogResult("BaseBoard Serial Number", GetBaseBoardSerialNumber);
        }
        catch (Exception ex)
        {
            LogError("Fatal error", ex);
        }
        finally
        {
            Log("System configuration check finished");

        }
        return (systemName,
            macAddress,
            publicIP,
            localIP,
            hardDiskSerialNumber,
            baseBoardSerialNumber);
    }

    private static string LogResult(string label, Func<string?> getter)
    {
        string value = string.Empty; // Declare the variable outside the try-finally block
        try
        {
            value = getter();
            if (string.IsNullOrWhiteSpace(value))
            {
                Log($"{label}: value not found");
            }
            else
            {
                Log($"{label}: {value}");
            }
        }
        catch (Exception ex)
        {
            LogError(label, ex);
        }
        //finally
        //{
        //    return value; // Ensure the return statement is outside the try-finally block
        //}
        return value; // Ensure the return statement is outside the try-finally block
    }

    private static void Log(string message)
    {
        try
        {
            File.AppendAllText(LogFile, $"{DateTime.Now:O} {message}{Environment.NewLine}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Logging failed: {ex}");
        }
    }

    private static void LogError(string label, Exception ex)
    {
        Log($"{label} error: {ex}");
    }

    private static string GetSystemName()
    {
        var domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
        var hostName = Dns.GetHostName();
        return hostName.Contains(domainName, StringComparison.OrdinalIgnoreCase)
            ? hostName
            : $"{hostName}.{domainName}";
    }

    private static string? GetMacAddress()
    {
        return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
    }

    private static string GetPublicIp()
    {
        using var client = new WebClient();
        var response = client.DownloadString("https://api.ipify.org/");
        return Regex.Matches(response, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")[0].ToString();
    }

    private static string GetLocalIp()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new InvalidOperationException("No network adapters with an IPv4 address in the system!");
    }

    private static string? GetHardDiskSerialNumber()
    {
        // System.Management is only supported on Windows. Avoid a
        // PlatformNotSupportedException when the code is executed on
        // other operating systems.
        if (!OperatingSystem.IsWindows())
        {
            return null;
        }

        try
        {
            var scope = new ManagementScope(@"\\.\root\cimv2");
            scope.Options.Impersonation = ImpersonationLevel.Impersonate;
            scope.Options.EnablePrivileges = true;
            scope.Connect();

            // Determine the system drive (e.g., "C:").
            var systemDrive = Path.GetPathRoot(Environment.SystemDirectory)?.TrimEnd('\\');
            if (string.IsNullOrEmpty(systemDrive))
            {
                return null;
            }

            // Find the partition associated with the system drive.
            var partitionQuery =
                $"ASSOCIATORS OF {{Win32_LogicalDisk.DeviceID='{systemDrive}'}} WHERE AssocClass=Win32_LogicalDiskToPartition";
            using var partitionSearcher = new ManagementObjectSearcher(scope, new ObjectQuery(partitionQuery));
            using var partitions = partitionSearcher.Get();

            foreach (ManagementObject partition in partitions)
            {
                using (partition)
                {
                    var driveQuery =
                        $"ASSOCIATORS OF {{{partition.Path.RelativePath}}} WHERE AssocClass=Win32_DiskDriveToDiskPartition";
                    using var driveSearcher = new ManagementObjectSearcher(scope, new ObjectQuery(driveQuery));
                    using var drives = driveSearcher.Get();

                    foreach (ManagementObject drive in drives)
                    {
                        using (drive)
                        {
                            var mediaType = drive["MediaType"]?.ToString();
                            if (mediaType?.Contains("Removable", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                continue;
                            }

                            return drive["SerialNumber"]?.ToString()?.Trim();
                        }
                    }
                }
            }
        }
        catch (ManagementException)
        {
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }

        return null;
    }

    private static string? GetBaseBoardSerialNumber()
    {
        if (!OperatingSystem.IsWindows())
        {
            return null;
        }

        try
        {
            var scope = new ManagementScope(@"\\.\root\cimv2");
            scope.Options.Impersonation = ImpersonationLevel.Impersonate;
            scope.Options.EnablePrivileges = true;
            scope.Connect();

            using var searcher = new ManagementObjectSearcher(scope,
                new ObjectQuery("SELECT SerialNumber FROM Win32_BaseBoard"));
            using var results = searcher.Get();
            foreach (ManagementObject obj in results)
            {
                using (obj)
                {
                    return obj["SerialNumber"]?.ToString();
                }
            }
        }
        catch (ManagementException)
        {
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }

        return null;
    }
}

