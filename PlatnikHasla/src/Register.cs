using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatnikHasla
{
    class Register
    {
        private const string AdminPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Asseco Poland SA\Płatnik\10.02.002\Admin";
        private const string DatabasePath = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Asseco Poland SA\Płatnik\10.02.002\Baza";

        private readonly List<string> _userPasswords;
        private readonly List<string> _databasePasswords;

        public List<string> UserPasswords => _userPasswords;
        public List<string> DatabasePasswords => _databasePasswords; 

        public Register()
        {
            _userPasswords = new List<string>();
            _databasePasswords = new List<string>();
        }

        private string GetPassword(string path, string entry)
        {
            return Microsoft.Win32.Registry.GetValue(path, entry, null)?.ToString();
        }

        public void GetUserPasswords()
        {
            int i = 4;

            string userPassword;
            while ((userPassword = GetPassword(AdminPath, $"Adm{i}")) != null)
            {
                _userPasswords.Add(userPassword);
                i++;
            }
        }

        public void GetDatabasePasswords()
        {
            string databasePassword;
            if ((databasePassword = GetPassword(DatabasePath, "Jet OLEDB:Database Password")) != null)
            {
                _databasePasswords.Add(databasePassword);
            }
        }
    }
}
