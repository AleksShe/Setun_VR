using UnityEngine;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.InputSystem;

public class SerialChecker : MonoBehaviour
{
    private const string RegistryKeyPath = @"SOFTWARE\CATO\Setun";
    private void Start()
    {
   
    }
    private void CheckSerial()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath);
        var text = key.GetValue("key");
        if (text == null || text.ToString() != GetKey())
            Application.Quit();
    }
    private string GetKey()
    {
        var combinedString = "setun";
        var md5 = MD5.Create();
        var inputBytes = Encoding.UTF8.GetBytes(combinedString);
        var hashBytes = md5.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        foreach (var b in hashBytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }
}
