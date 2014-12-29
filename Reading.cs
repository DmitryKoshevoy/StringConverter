using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Reading
    {
        public static String InputText(String[] outPutArray)
        {
            var charIndex = 0;
            var outPutString = new StringBuilder();
            var inputString = new StringBuilder();
            foreach (var str in outPutArray)
            {
                outPutString.Append(Writing.MirrorGenerator(str));
            }
            while (charIndex != 48)
            {
                inputString = inputString.Append(Char.ConvertFromUtf32(Convert.ToByte(outPutString.ToString().Substring(charIndex, 2), 16)));
                charIndex += 2;
            }
            return inputString.ToString();
        }
    }
}
