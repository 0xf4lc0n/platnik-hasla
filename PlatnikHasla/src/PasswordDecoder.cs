using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlatnikHasla
{
    class PasswordDecoder
    {
        private const string BaseKey = "lmnopqrstuvwxyz{";
        private readonly List<int> _order;
        private readonly List<string> _key;

        public PasswordDecoder()
        {
            _key = new List<string>();
            _key.Add(Swap(BaseKey, 8));
            _key.Add(Swap(Swap(BaseKey, 4), 1));
            _key.Add(Swap(Swap(BaseKey, 8), 1));
            _key.Add(Swap(BaseKey, 1));
            _key.Add(Swap(BaseKey, 4));
            _key.Add(Swap(BaseKey, 2));
            _key.Add(Swap(Swap(BaseKey, 2), 1));
            _key.Add(Swap(Swap(Swap(BaseKey, 4), 2), 1));

            _order = new List<int> { 0, 1, 2, 3, 4, 0, 3, 5, 2, 1, 5, 4, 3, 6, 6, 2, 4, 2, 2, 4, 3, 2, 7, 7 };
        }

        private string Swap(string text, int index)
        {
            var re = new Regex($"(.{{{index}}})(.{{{index}}})");
            return re.Replace(text, "$2$1");
        }

        public string Decode(string encoded)
        {
            var pairs = Regex.Replace(encoded, @"(.)(.)", "$1$2 ").Split(' ').TakeWhile(x => x != "").ToList();
            var decodedPassword = new List<char>();
            int i = 0;

            foreach (var pair in pairs)
            {
                var HexCode = Convert.ToInt32($"{_key[_order[i]].IndexOf(pair[1])}{_key[_order[i]].IndexOf(pair[0])}", 16);
                decodedPassword.Add(Convert.ToChar(HexCode));
                i++;
            }

            return String.Join("", decodedPassword);
        }
    }
}
