using Byte.Sized.Monkeys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Sized_Monkeys_Pad_A.Core.Services
{
    public static class Mapper
    {

        public static string MapMayanHieroglyphicsToString(string mayanString)
        {

            StringBuilder response = new StringBuilder();
            foreach(var c in mayanString)
            {
                if (HieroglyphAlphabet.Characters.TryGetValue(c, out char value))
                {
                    response.Append(value);
                }
            }

            //var humanString = 
            //    mayanString.ToCharArray()
            //    .Select(c => HieroglyphAlphabet.Characters.TryGetValue(c, out char value))
            //    ;

            return response.ToString();
        }

    }
}
