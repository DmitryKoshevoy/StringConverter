using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Writing
    {
        public static String MirrorGenerator(String outputHex)
        {
            char[] HEXCode = outputHex.ToCharArray();
            Array.Reverse(HEXCode);
            char[] ChangedHEXCode = new char[8];
            for (var i = 0; i < ChangedHEXCode.Length; i++)
            {
                ChangedHEXCode[i] = '0';
            }
            for (var i = 0; i < HEXCode.Length; i++)
            {
                if (i != HEXCode.Length - 1)
                {
                    ChangedHEXCode[i] = HEXCode[i + 1];
                    ChangedHEXCode[i + 1] = HEXCode[i];
                    i++;
                }
                else if (i == HEXCode.Length - 1 && i != 7)
                {
                    ChangedHEXCode[i + 1] = HEXCode[i];
                }
            }
            return new string(ChangedHEXCode);
        }

        public static String ASCIIcode(String encodindStr)
        {
            var strBuild = new StringBuilder();
            Array.ForEach(Encoding.ASCII.GetBytes(encodindStr), s => strBuild.Append(s.ToString("X")));
            return strBuild.ToString();
        }
        

        public static String[] OutputText(String mystring)
        {
            if (mystring.Length > 21)
                throw new ArgumentOutOfRangeException("String can't have more than 21 char, you will use reserve memory at adress 0x00000020");
            var startIndex = 0;
            var outText = new string[6];
            var outStr = new StringBuilder();
            outStr.Append(ASCIIcode(mystring));
            while (outStr.Length < 48)
                outStr.Append('0');
            for (var i = 0; i < outText.Length; i++)
            {
                outText[i] = MirrorGenerator(outStr.ToString().Substring(startIndex, 8));
                startIndex +=8;
            }
            return outText;
        }

        private static void Main(string[] args)
        {
            const string str = "!DIRTY_STINKING.BAZE!";
            var array = OutputText(str);
            foreach (var strin in array)
            {
                Console.WriteLine(strin);
            }
            Console.WriteLine(Reading.InputText(array));
            Console.ReadKey();
        }
    }
}
