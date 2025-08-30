using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SystemConfigChecker;

public static class Program
{
    private static readonly string LogFile = Path.Combine(AppContext.BaseDirectory, "system_config.log");

    public static void Main()
    {
        try
        {
            Log("System configuration check started");
            LogResult("System Name", GetSystemName);
            LogResult("MAC Address", GetMacAddress);
            LogResult("Public IP", GetPublicIp);
            LogResult("Local IP", GetLocalIp);
            LogResult("Hard Disk Serial Number", GetHardDiskSerialNumber);
            LogResult("BaseBoard Serial Number", GetBaseBoardSerialNumber);
        }
        catch (Exception ex)
        {
            LogError("Fatal error", ex);
        }
        finally
        {
            Log("System configuration check finished");
        }
    }

    private static void LogResult(string label, Func<string?> getter)
    {
        try
        {
            var value = getter();
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
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
        using var results = searcher.Get();
        foreach (ManagementObject obj in results)
        {
            using (obj)
            {
                return obj["SerialNumber"]?.ToString()?.Trim();
            }
        }

        return null;
    }

    private static string? GetBaseBoardSerialNumber()
    {
        using var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
        using var results = searcher.Get();
        foreach (ManagementObject obj in results)
        {
            using (obj)
            {
                return obj["SerialNumber"]?.ToString();
            }
        }

        return null;
    }
}

