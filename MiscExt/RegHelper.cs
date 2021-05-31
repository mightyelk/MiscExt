using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using Microsoft.Win32;

namespace MightyElk.MiscExt
{
    public class RegHelper
    {
        string _sid = null;
        string _host = null;

        public RegHelper()
        {

        }
        public RegHelper(string sid)
        {
            _sid = sid;
        }
        public RegHelper(string sid, string hostName) : this(sid)
        {
            _host = hostName;
        }

        public bool RegOk()
        {
            var k = GetKey(RegistryHive.CurrentUser, "");
            return k != null;
        }

        public static string GetSecurityIdentifier(string domain, string username)
        {
            var nt = new NTAccount(domain, username);
            if (nt == null)
                return null;

            var sid = nt.Translate(typeof(SecurityIdentifier));
            return sid.Value;
        }

        public RegistryKey GetKey(RegistryHive hive, string path)
        {
            return GetKey(hive, path, false);
        }

        public RegistryKey GetKey(RegistryHive hive, string path, bool openWritable)
        {
            RegistryKey key = null;

            if (hive == RegistryHive.CurrentUser)
                key = Registry.CurrentUser;
            if (hive == RegistryHive.LocalMachine)
                key = Registry.LocalMachine;
            if (hive == RegistryHive.ClassesRoot)
                key = Registry.ClassesRoot;
            if (hive == RegistryHive.CurrentUser && _sid != null)
            {
                hive = RegistryHive.Users;
                key = Registry.Users;
                path = _sid + "\\" + path;
            }

            if (key == null)
                throw new Exception($"Hive '{key.Name}' not supported");

            try
            {
                if (_host == null)
                    return key.OpenSubKey(path, openWritable);
                else
                {
                    var remotekey = RegistryKey.OpenRemoteBaseKey(hive, _host);
                    return remotekey.OpenSubKey(path, openWritable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool KeyExists(RegistryHive hive, string path)
        {
            return GetKey(hive, path) != null;
        }

        public string GetValue(RegistryHive hive, string path, string valueName)
        {

            var k = GetKey(hive, path);
            if (k == null)
                return "";
            var o = k.GetValue(valueName);
            if (o == null)
                return "";

            return o.ToString();
        }
        public int GetDword(RegistryHive hive, string path, string valueName)
        {
            var key = GetKey(hive, path);
            if (key == null)
                return 0;
            var val = key.GetValue(valueName);
            if (val == null)
                return 0;

            try
            {
                if (key.GetValueKind(valueName) != RegistryValueKind.DWord)
                    return 0;
                return (int)val;
            }
            catch (Exception)
            {
                return 0;
            }

        }


        public void DeleteKey(RegistryHive hive, string path)
        {
            int lastIndex = path.LastIndexOf('\\');

            if (lastIndex <= 0 | lastIndex == path.Length)
                return;


            string keyName = path.Substring(lastIndex + 1);
            string parentPath = path.Substring(0, lastIndex);


            var k = GetKey(hive, parentPath, true);
            if (k == null)
                return;

            k.DeleteSubKey(keyName);

        }
    }
}
