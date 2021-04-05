using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatnikHasla
{
    class Core
    {
        private List<string> _encodedUserPasswords;
        private readonly List<string> _decodedUserPasswords;
        private List<string> _encodedDatabasePasswords;
        private readonly List<string> _decodedDatabasePasswords;
        private readonly Register _register;
        private readonly PasswordDecoder _decoder;

        public string UserPassword => _decodedUserPasswords.LastOrDefault();
        public string DatabasePassword => _decodedDatabasePasswords.LastOrDefault();

        public Core() 
        { 
            _decodedUserPasswords = new List<string>();
            _decodedDatabasePasswords = new List<string>();
            _register = new Register();
            _decoder = new PasswordDecoder();
        }

        public void GetUserPasswords()
        {
            _register.GetUserPasswords();
            _encodedUserPasswords = _register.UserPasswords;
        }

        public void GetDatabasePasswords()
        {
            _register.GetDatabasePasswords();
            _encodedDatabasePasswords = _register.DatabasePasswords;
        }

        public void DecodeUserPasswords()
        {
            foreach (var password in _encodedUserPasswords) 
            {
                _decodedUserPasswords.Add(_decoder.Decode(password));
            }
        }
        public void DecodeDatabasePasswords()
        {
            foreach (var password in _encodedDatabasePasswords)
            {
                _decodedDatabasePasswords.Add(_decoder.Decode(password));
            }
        }
    }
}
