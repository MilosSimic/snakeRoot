using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Security.cs
{
    public static class SnakeSecurity
    {
        public static String cript(String input, String shift)
        {
            string encrypt = input;
            //encrypt.ToLower();

            bool tbNull = input == "";

            if (tbNull)
            {
                throw new Exception("No data!");
            }
            else
            {
                char[] array = encrypt.ToCharArray();

                for (int i = 0; i < array.Length; i++)
                {
                    int num = (int)array[i];
                    if (num >= 'a' && num <= 'z')
                    {
                        num += Convert.ToInt32(shift);
                        if (num > 'z')
                        {
                            num = num - 26;
                        }
                    }
                    else if (num >= 'A' && num <= 'Z')
                    {
                        num += Convert.ToInt32(shift);
                        if (num > 'Z')
                        {
                            num = num - 26;
                        }
                    }
                    array[i] = (char)num;
                }
                String retVal = new string(array);

                return retVal;
            }
        }

        public static String decrypt(String input, String shift)
        {
            string decrypt = input;
            //decrypt.ToLower();

            bool tbNull = input == "";

            if (tbNull)
            {
                throw new Exception("No data!");
            }
            else
            {
                char[] array = decrypt.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    int num = (int)array[i];
                    if (num >= 'a' && num <= 'z')
                    {
                        num -= Convert.ToInt32(shift);
                        if (num > 'z')
                            num = num - 26;

                        if (num < 'a')
                            num = num + 26;
                    }
                    else if (num >= 'A' && num <= 'Z')
                    {
                        num -= Convert.ToInt32(shift);
                        if (num > 'Z')
                            num = num - 26;

                        if (num < 'A')
                            num = num + 26;
                    }
                    array[i] = (char)num;
                }

                String retval = new string(array);

                return retval;
            }
        }
    }
}
