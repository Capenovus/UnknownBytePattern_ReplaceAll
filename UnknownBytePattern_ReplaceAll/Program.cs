using System.Text;

namespace UnknownBytePattern_ReplaceAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) return;
            string path = args[0];
            if (!File.Exists(path)) return;

            Console.Write("Input Search Pattern: ");
            string pattern = Console.ReadLine().Replace(" ", "");
            Console.Write("Input Replacement Pattern: ");
            string r_pattern = Console.ReadLine().Replace(" ", "");

            if (pattern.Length != r_pattern.Length) return;

            var contents = File.ReadAllBytes(path);
            var writer = File.OpenWrite(path);

            for (int i = 0; i < contents.Length; i++) 
            {
                StringBuilder replace = new(r_pattern);
                string hex = contents[i].ToString("X2");
                if (hex == $"{pattern[0]}{pattern[1]}" || $"{pattern[0]}{pattern[1]}" == "??") 
                {
                    int strcount2 = 2;
                    for (int j = 1; j < pattern.Length / 2; j++)
                    {
                        string hex2 = contents[i + j].ToString("X2");
                        if (hex2 != $"{pattern[strcount2]}{pattern[strcount2 + 1]}" && $"{pattern[strcount2]}{pattern[strcount2 + 1]}" != "??")
                        {
                            i += j + 1;
                            break;
                        }
                        if ($"{replace[strcount2]}{replace[strcount2 + 1]}" == "??")
                        {
                            replace[strcount2] = hex2[0];
                            replace[strcount2 + 1] = hex2[1];
                        }
                        if (j == pattern.Length / 2 - 1)
                        {
                            if ($"{replace[0]}{replace[1]}" == "??") 
                            {
                                replace[0] = hex[0];
                                replace[1] = hex[1];
                            }
                            byte[] buffer = StringToByteArray(replace.ToString());
                            writer.Seek(i, SeekOrigin.Begin);
                            writer.Write(buffer, 0, buffer.Length);
                            i += j + 1;
                        }
                        strcount2 += 2;
                    }
                    
                }
            }
            writer.Dispose();
            writer.Close();
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }
}