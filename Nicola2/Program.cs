using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Информатика
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Menuu();
        }

        class Menu
        {
            public static void Menuu()
            {
                Console.WriteLine("Выберите что вы хотите сделать:");
                Console.WriteLine("1. Перевести из одной системы счисления в другую.");
                Console.WriteLine("2. Перевести число из Арабской в Римскую и наоборот.");
                Console.WriteLine("3. Сложение в произвольной системе счисления");
                Console.WriteLine("4. Вычитание в произвольной системе счисления");
                Console.WriteLine("5. Умножение в произвольной системе счисления");
                Console.WriteLine("Все действия необходимо подтверждать нажатием клавиши Enter.");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        ConvertingToAnyBase.TransferToAnotherSystem();
                        Return();
                        break;
                    case "2":
                        ArabicOrRomanian.ChoseTheSystem();
                        Return();
                        break;
                    case "3":
                        SummaryInAnySystem.Summary();
                        Return();
                        break;
                    case "4":
                        SubstractionInAnySystem.Subtraction();
                        Return();
                        break;
                    case "5":
                        MultiplicationInAnySystem.Multiplication();
                        Return();
                        break;
                }
            }
        }

        static void Return()
        {
            Console.WriteLine("Хотите ли вы еще воспользоваться программой?");
            Console.WriteLine("Если хотите то введите 1.");
            Console.WriteLine("Иначе введите что угодно.");
            int a = Int32.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.Clear();
                Menu.Menuu();
            }
            else
            {
                return;
            }
        }
    }

    class ConvertingToAnyBase
    {
        public static Dictionary<int, string> numbers = new Dictionary<int, string>
        {
            {10, "A"}, {11, "B"}, {12, "C"}, {13, "D"}, {14, "E"}, {15, "F"}, {16, "G"}, {17, "H"}, {18, "I"}, {19, "J"}, {21, "K"}, {22, "L"},
            {23, "M"}, {24, "N"}, {25, "O"}, {26, "P"}, {27, "Q"}, {28, "R"}, {29, "S"}, {30, "T"}, {31, "U"}, {32, "V"}, {33, "W"}, {34, "X"},
            {35, "Y"}, {36, "Z"}, {37, "a"}, {38, "b"}, {39, "c"}, {40, "d"}, {41, "e"}, {42, "f"}, {43, "g"}, {44, "h"}, {45, "i"}, {46, "j"},
            {47, "k"}, {48, "l"}, {49, "m"}, {50, "n"}
        };

        public static string ConvertFromDec(int num, int sys)
        {
            string result = "";
            var pos = num;
            while (true)
            {
                if (pos == 1)
                {
                    result += pos;
                    break;
                }
                else if (pos == 0)
                {
                    break;
                }
                var ost = pos % sys;
                if (ost > 9)
                {
                    result += numbers[ost];
                }
                else
                {
                    result += ost;
                }
                pos /= sys;
            }
            return Reverse(result);
        }

        public static int ConvertToDec(char[] num, int sys)
        {
            int result = 0;
            int s = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                result += Convert.ToInt32(Math.Pow(sys, s)) * Convert.ToInt32(num[i].ToString());
                s++;
            }
            return result;
        }

        public static void TransferToAnotherSystem()
        {
            Console.Clear();
            Console.WriteLine("Введите число:");
            bool num = int.TryParse(Console.ReadLine(), out int number);
            Console.Clear();
            Console.WriteLine("Введите систему счисления:");
            bool sys = int.TryParse(Console.ReadLine(), out int system);
            if (number <= 0 || system <= 0)
            {
                Console.Clear();
                Console.WriteLine("Введите число больше нуля!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                TransferToAnotherSystem();
            }
            if (num == true && sys == true)
            {
                int verification = number;
                while (verification > 0)
                {
                    int proverka = verification % 10;
                    if (proverka >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        TransferToAnotherSystem();
                    }
                    verification = verification / 10;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введите именно арабское число!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                TransferToAnotherSystem();
            }
            Console.Clear();
            char[] truNum = number.ToString().ToCharArray();
            Console.WriteLine($"Берем последний элемент числа(в данном случае {truNum[truNum.Length - 1]})");
            Console.WriteLine($"И умножаем его ({truNum[truNum.Length - 1]}) на систему счисления (в данном случае {system}) в степени начиная с 0");
            int ans = Convert.ToInt32(truNum[truNum.Length - 1].ToString()) * Convert.ToInt32(Math.Pow(system, 0));
            Console.WriteLine($"В данном случае ответ будет {ans}");
            Console.WriteLine("Дальше берем следующий элемент и домножаем на систему счисления в степени на 1 больше.");
            Console.WriteLine($"В конце складываем полученные результаты и получаем ответ(в десятичной системе):{ConvertToDec(truNum, system)}");
            Console.WriteLine("Для продолжения нажмите любую кнопку.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Введите в какую систему счисления осуществить перевод:");
            bool sys1 = int.TryParse(Console.ReadLine(), out int sys2);
            if (sys1 == true)
            {
                Console.Clear();
                Console.WriteLine($"Ответ в {sys2}-ой системе:{ConvertFromDec(ConvertToDec(truNum, system), sys2)}");
            }
            else if (sys2 <= 0)
            {
                Console.Clear();
                Console.WriteLine("Введите число больше нуля!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                TransferToAnotherSystem();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введите именно арабское число!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                TransferToAnotherSystem();
            }
        }

        public static string Reverse(string line)
        {
            string result = "";
            for (int i = line.Length - 1; i > 0; i--)
            {
                result += line[i];
            }

            return result + line[0];
        }
    }

    class ArabicOrRomanian
    {
        public static void ChoseTheSystem()
        {
            Console.Clear();
            Console.WriteLine("Нажмите 1, если хотите перевести арабские цифры в римские");
            Console.WriteLine("Нажмите 2, если хотите перевести римские цифры в арабские");
            int a = Int32.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine(ArabicToRomanian(ArabicInput()));
            }
            else if (a == 2)
            {
                Console.WriteLine(RomanianToArabic(RomanianInput()));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неправильное значение.");
                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.ReadKey();
                ChoseTheSystem();
            }
        }

        public static int ArabicInput()
        {
            Console.WriteLine("Введите число, которое хотите перевести");
            int arabic = int.Parse(Console.ReadLine());
            Console.Clear();
            return arabic;
        }

        public static string ArabicToRomanian(int arabicNumber)
        {
            if (arabicNumber > 5000)
            {
                Console.WriteLine( "Число превышает максимально допустимое значение, пожалуйста введите новое число меньше или равное 5000");
                Console.WriteLine("");
                arabicNumber = Int32.Parse(Console.ReadLine());
                Console.Clear();
                return ArabicToRomanian(arabicNumber);
            }
            else
            {
                string[] Thousands = { "", "M", "MM", "MMM", "MMMM", "MMMMM" };
                string[] Hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
                string[] Tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
                string[] Ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

                string result = null;

                int number = arabicNumber / 1000;
                result += Thousands[number];
                arabicNumber %= 1000;

                number = arabicNumber / 100;
                result += Hundreds[number];
                arabicNumber %= 100;

                number = arabicNumber / 10;
                result += Tens[number];
                arabicNumber %= 10;

                result += Ones[arabicNumber];

                return result;
            }
        }

        public static string RomanianInput()
        {
            Console.Clear();
            Console.WriteLine("Введите римское значение числа: ");
            string romanianNumber = Console.ReadLine();
            return romanianNumber;
        }
        public static Dictionary<char, int> CharValues = null;

        public static int RomanianToArabic(string roman)
        {
            if (CharValues == null)
            {
                CharValues = new Dictionary<char, int>();
                CharValues.Add('I', 1);
                CharValues.Add('V', 5);
                CharValues.Add('X', 10);
                CharValues.Add('L', 50);
                CharValues.Add('C', 100);
                CharValues.Add('D', 500);
                CharValues.Add('M', 1000);
            }

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

            if (roman[0] == '(')
            {
                int pos = roman.LastIndexOf(')');
                string part1 = roman.Substring(1, pos - 1);
                string part2 = roman.Substring(pos + 1);
                return 1000 * RomanianToArabic(part1) + RomanianToArabic(part2);
            }
            int total = 0;
            int last_value = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int new_value = CharValues[roman[i]];
                if (new_value < last_value)
                    total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }
            return total;
        }
    }

    class SummaryInAnySystem
    {
        public static void Summary()
        {
            Console.Clear();
            Console.WriteLine("Введите первое число:");
            bool num1 = int.TryParse(Console.ReadLine(), out int number1);
            Console.Clear();
            Console.WriteLine("Введите второе число:");
            bool num2 = int.TryParse(Console.ReadLine(), out int number2);
            Console.Clear();
            Console.WriteLine("Введите систему счисления:");
            bool sys = int.TryParse(Console.ReadLine(), out int system);
            if (number1 <= 0 || system <= 0 || number1 <= 0)
            {
                Console.Clear();
                Console.WriteLine("Введите число больше нуля!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Summary();
            }
            if (num1 == true && sys == true)
            {
                int verification = number1;
                while (verification > 0)
                {
                    int proverka = verification % 10;
                    if (proverka >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Summary();
                    }
                    verification = verification / 10;
                }
            }
            if (num2 == true && sys == true)
            {
                int verification = number1;
                while (verification > 0)
                {
                    int proverka = verification % 10;
                    if (proverka >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Summary();
                    }
                    verification = verification / 10;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введите именно арабское число!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Summary();
            }
            Console.Clear();
            char[] truNum1 = number1.ToString().ToCharArray();
            char[] truNum2 = number2.ToString().ToCharArray();
            Console.WriteLine($"Берем последний элемент числа(в данном случае {truNum1[truNum1.Length - 1]})");
            Console.WriteLine($"И умножаем его ({truNum1[truNum1.Length - 1]}) на систему счисления (в данном случае {system}) в степени начиная с 0");
            int ans = Convert.ToInt32(truNum1[truNum1.Length - 1].ToString()) * Convert.ToInt32(Math.Pow(system, 0));
            Console.WriteLine($"В данном случае ответ будет {ans}");
            Console.WriteLine("Дальше берем следующий элемент и домножаем на систему счисления в степени на 1 больше.");
            Console.WriteLine($"В конце складываем полученные результаты и получаем ответ(в десятичной системе):{ConvertingToAnyBase.ConvertToDec(truNum1, system)}");
            Console.WriteLine($"Ответ для второго (в десятичной системе):{ConvertingToAnyBase.ConvertToDec(truNum2, system)}");
            int finalNum = ConvertingToAnyBase.ConvertToDec(truNum2, system) + ConvertingToAnyBase.ConvertToDec(truNum1, system);
            Console.WriteLine($"Их сумма (в десятичной системе):{finalNum}");
            var a = ConvertingToAnyBase.ConvertFromDec(finalNum, system);
            Console.WriteLine($"Ответ в {system}-ой системе:{a}");
        }
    }

    class SubstractionInAnySystem
    {
        public static void Subtraction()
        {
            Console.Clear();
            Console.WriteLine("Введите первое число:");
            bool num1 = int.TryParse(Console.ReadLine(), out int number1);
            Console.Clear();
            Console.WriteLine("Введите второе число:");
            bool num2 = int.TryParse(Console.ReadLine(), out int number2);
            Console.Clear();
            Console.WriteLine("Введите систему счисления:");
            bool sys = int.TryParse(Console.ReadLine(), out int system);
            if (number2 > number1)
            {
                Console.Clear();
                Console.WriteLine("Первое число должно быть больше второго!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Subtraction();
            }
            if (number1 <= 0 || system <= 0 || number1 <= 0)
            {
                Console.Clear();
                Console.WriteLine("Введите число больше нуля!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Subtraction();
            }
            if (num1 == true && sys == true)
            {
                int verification = number1;
                while (verification > 0)
                {
                    int proverka = verification % 10;
                    if (proverka >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Subtraction();
                    }
                    verification = verification / 10;
                }
            }
            if (num2 == true && sys == true)
            {
                int verification = number1;
                while (verification > 0)
                {
                    int proverka = verification % 10;
                    if (proverka >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Subtraction();
                    }
                    verification = verification / 10;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введите именно арабское число!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Subtraction();
            }
            Console.Clear();
            char[] truNum1 = number1.ToString().ToCharArray();
            char[] truNum2 = number2.ToString().ToCharArray();
            Console.WriteLine($"Берем последний элемент числа(в данном случае {truNum1[truNum1.Length - 1]})");
            Console.WriteLine($"И умножаем его ({truNum1[truNum1.Length - 1]}) на систему счисления (в данном случае {system}) в степени начиная с 0");
            int ans = Convert.ToInt32(truNum1[truNum1.Length - 1].ToString()) * Convert.ToInt32(Math.Pow(system, 0));
            Console.WriteLine($"В данном случае ответ будет {ans}");
            Console.WriteLine("Дальше берем следующий элемент и домножаем на систему счисления в степени на 1 больше.");
            Console.WriteLine($"В конце складываем полученные результаты и получаем ответ(в десятичной системе):{ConvertingToAnyBase.ConvertToDec(truNum1, system)}");
            Console.WriteLine($"Ответ для второго (в десятичной системе):{ConvertingToAnyBase.ConvertToDec(truNum2, system)}");
            int finalNum = ConvertingToAnyBase.ConvertToDec(truNum1, system) - ConvertingToAnyBase.ConvertToDec(truNum2, system);
            Console.WriteLine($"Их разность (в десятичной системе):{finalNum}");
            Console.WriteLine($"Ответ в {system}-ой системе:{ConvertingToAnyBase.ConvertFromDec(finalNum, system)}");
        }
    }

    class MultiplicationInAnySystem
    {
        public static void Multiplication()
        {
            Console.Clear();
            Console.WriteLine("Введите первое число:");
            bool num1 = int.TryParse(Console.ReadLine(), out int number1);
            Console.Clear();
            Console.WriteLine("Введите второе число:");
            bool num2 = int.TryParse(Console.ReadLine(), out int number2);
            Console.Clear();
            Console.WriteLine("Введите систему счисления:");
            bool sys = int.TryParse(Console.ReadLine(), out int system);
            if (number1 <= 0 || system <= 0 || number1 <= 0)
            {
                Console.Clear();
                Console.WriteLine("Введите число больше нуля!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Multiplication();
            }
            if (num1 == true && sys == true)
            {
                int verification = number1;
                while (verification > 0)
                {
                    int proverka = verification % 10;
                    if (proverka >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Multiplication();
                    }
                    verification = verification / 10;
                }
            }
            if (num2 == true && sys == true)
            {
                int verification = number1;
                while (verification > 0)
                {
                    int check = verification % 10;
                    if (check >= system)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели неправильное число. Число не должно содержать цифр больше или равных значению системы счисления.");
                        Console.WriteLine("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Multiplication();
                    }
                    verification = verification / 10;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введите именно арабское число!");
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Multiplication();
            }
            Console.Clear();
            char[] truNum1 = number1.ToString().ToCharArray();
            char[] truNum2 = number2.ToString().ToCharArray();
            Console.WriteLine($"Берем последний элемент числа(в данном случае {truNum1[truNum1.Length - 1]})");
            Console.WriteLine($"И умножаем его ({truNum1[truNum1.Length - 1]}) на систему счисления (в данном случае {system}) в степени начиная с 0");
            int ans = Convert.ToInt32(truNum1[truNum1.Length - 1].ToString()) * Convert.ToInt32(Math.Pow(system, 0));
            Console.WriteLine($"В данном случае ответ будет {ans}");
            Console.WriteLine("Дальше берем следующий элемент и домножаем на систему счисления в степени на 1 больше.");
            Console.WriteLine($"В конце складываем полученные результаты и получаем ответ(в десятичной системе):{ConvertingToAnyBase.ConvertToDec(truNum1, system)}");
            Console.WriteLine($"Ответ для второго (в десятичной системе):{ConvertingToAnyBase.ConvertToDec(truNum2, system)}");
            int finalNum = ConvertingToAnyBase.ConvertToDec(truNum2, system) * ConvertingToAnyBase.ConvertToDec(truNum1, system);
            Console.WriteLine($"Их произведение (в десятичной системе):{finalNum}");
            Console.WriteLine($"Ответ в {system}-ой системе:{ConvertingToAnyBase.ConvertFromDec(finalNum, system)}");
        }
    }
}
