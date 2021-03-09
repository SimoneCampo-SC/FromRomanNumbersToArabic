using System;
using System.Collections.Generic;
namespace Challenge8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int number;
            number = ParseNumber("LXIX");
            Console.WriteLine(number);
        }

        public static int ParseNumber(string input)
        {
            Dictionary<string, int> romanNumbers = new Dictionary<string, int>()
            {
                {"I", 1},
                {"II", 2},
                {"III", 3},
                {"IV", 4},
                {"V", 5},
                {"VI", 6},
                {"VII", 7},
                {"VIII", 8},
                {"IX", 9},

                {"X", 10},
                {"XX", 20},
                {"XXX", 30},
                {"XL", 40},
                {"L", 50},
                {"LX", 60},
                {"LXX", 70},
                {"LXXX", 80},
                {"XC", 90},

                {"C", 100},
                {"CC", 200},
                {"CCC", 300},
                {"CD", 400},
                {"D", 500},
                {"DC", 600},
                {"DCC", 700},
                {"DCCC", 800},
                {"CM", 900},

                {"M", 1000},
                {"MM", 2000},
                {"MMM", 3000},
            };

            char[] arrayOfInput = input.ToCharArray();

            string singleNumber, stringNumber, testNumber;

            int number, totalNumber = 0;

            int j, i = 0, x = 1;

            while(i < arrayOfInput.Length)
            {
                stringNumber = arrayOfInput[i].ToString();
                j = i + 1;

                if (j < arrayOfInput.Length)
                {
                    testNumber = stringNumber + arrayOfInput[j].ToString();
                    while ((romanNumbers.ContainsKey(testNumber)))
                    {
                        if ((j + x) < arrayOfInput.Length)
                        {
                            x = 1;
                            stringNumber = testNumber;
                            testNumber += arrayOfInput[j + x].ToString();
                            x++;
                            j++;
                        }
                        else
                        {
                            stringNumber = testNumber;
                            j++;
                            break;
                        }
                    }
                }
                singleNumber = stringNumber;
                romanNumbers.TryGetValue(singleNumber, out number);

                totalNumber += number;

                i = j;
            }
            return totalNumber;
        }
    }
}
