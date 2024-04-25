using System;

namespace Zahlensystemumrechner
{
    class NummerSystem
    {
        private string value;
        private int baseValue;

        public NummerSystem(string value, int baseValue)
        {
            this.value = value.ToUpper();
            this.baseValue = baseValue;
        }

        public string GetValue()
        {
            return value;
        }

        public string ToBinary()
        {
            return Convert.ToString(Convert.ToInt32(value, baseValue), 2);
        }

        public string ToOctal()
        {
            return Convert.ToString(Convert.ToInt32(value, baseValue), 8);
        }

        public string ToDecimal()
        {
            return Convert.ToInt32(value, baseValue).ToString();
        }

        public string ToHexadecimal()
        {
            return Convert.ToString(Convert.ToInt32(value, baseValue), 16);
        }

        public static NummerSystem operator +(NummerSystem num1, NummerSystem num2)
        {
            int ergebnis = Convert.ToInt32(num1.value, num1.baseValue) + Convert.ToInt32(num2.value, num2.baseValue);
            return new NummerSystem(ergebnis.ToString(), 10);
        }

        public static NummerSystem operator -(NummerSystem num1, NummerSystem num2)
        {
            int ergebnis = Convert.ToInt32(num1.value, num1.baseValue) - Convert.ToInt32(num2.value, num2.baseValue);
            return new NummerSystem(ergebnis.ToString(), 10);
        }

        public static NummerSystem operator *(NummerSystem num1, NummerSystem num2)
        {
            int ergebnis = Convert.ToInt32(num1.value, num1.baseValue) * Convert.ToInt32(num2.value, num2.baseValue);
            return new NummerSystem(ergebnis.ToString(), 10);
        }

        public static NummerSystem operator /(NummerSystem num1, NummerSystem num2)
        {
            int ergebnis = Convert.ToInt32(num1.value, num1.baseValue) / Convert.ToInt32(num2.value, num2.baseValue);
            return new NummerSystem(ergebnis.ToString(), 10);
        }
    }


    class Zahlensystem
    {
        // Methode zur Umwandlung einer Zahl in das Dezimalsystem
        public static int UmwandelnInDezimal(string zahl, string system)
        {
            switch (system.ToLower())
            {
                case "binär":
                    return Convert.ToInt32(zahl, 2);
                case "oktal":
                    return Convert.ToInt32(zahl, 8);
                case "dezimal":
                    return Convert.ToInt32(zahl, 10);
                case "hexadezimal":
                    return Convert.ToInt32(zahl, 16);
                default:
                    Console.WriteLine("Ungültiges Zahlensystem!");
                    return 0;
            }
        }

        // Methode zur Umwandlung einer Zahl vom Dezimalsystem in ein anderes Zahlensystem
        public static string UmwandelnInAnderesSystem(int dezimal, string system)
        {
            switch (system.ToLower())
            {
                case "binär":
                    return Convert.ToString(dezimal, 2);
                case "oktal":
                    return Convert.ToString(dezimal, 8);
                case "dezimal":
                    return Convert.ToString(dezimal, 10);
                case "hexadezimal":
                    return Convert.ToString(dezimal, 16);
                default:
                    Console.WriteLine("Ungültiges Zahlensystem!");
                    return "";
            }
        }

        // Methode zur Addition zweier Zahlen im Dezimalsystem
        public static int Addition(int zahl1, int zahl2)
        {
            return zahl1 + zahl2;
        }

        // Methode zur Subtraktion zweier Zahlen im Dezimalsystem
        public static int Subtraktion(int zahl1, int zahl2)
        {
            return zahl1 - zahl2;
        }

        // Methode zur Multiplikation zweier Zahlen im Dezimalsystem
        public static int Multiplikation(int zahl1, int zahl2)
        {
            return zahl1 * zahl2;
        }

        // Methode zur Division zweier Zahlen im Dezimalsystem
        public static int Division(int zahl1, int zahl2)
        {
            if (zahl2 == 0)
            {
                Console.WriteLine("Division durch Null ist nicht erlaubt!");
                return 0;
            }
            return zahl1 / zahl2;
        }
    }

    class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zum Zahlensystemumrechner!");

            Console.Write("Tippen Sie ihre erste und zweite Zahl in ihrer gewünschten form von Zahlensystem ein \n Bei 'Basis der ersten Zahl' ist ihre Wahl von Zahlensystem gefragt: Binär = 2, Oktal = 8, Dezimal = 10, Hexadezimal = 16\n");
            Console.Write("Geben Sie die erste Zahl ein: ");
            string zahl1 = Console.ReadLine();

            Console.Write("Geben Sie die Basis der ersten Zahl ein: ");
            int basis1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Geben Sie die zweite Zahl ein: ");
            string zahl2 = Console.ReadLine();

            Console.Write("Geben Sie die Basis der zweiten Zahl ein: ");
            int basis2 = Convert.ToInt32(Console.ReadLine());

            if (basis1 < 2 || basis1 > 16 || basis2 < 2 || basis2 > 16)
            {
                Console.WriteLine("Ungültige Basis. Die Basis muss zwischen 2 und 16 liegen.");
                Console.WriteLine("Das Programm wird beendet.");
                return;
            }

            NummerSystem num1 = new NummerSystem(zahl1, basis1);
            NummerSystem num2 = new NummerSystem(zahl2, basis2);

            NummerSystem sum = num1 + num2;
            NummerSystem difference = num1 - num2;
            NummerSystem product = num1 * num2;
            NummerSystem quotient = num1 / num2;

            Console.WriteLine("Addition: " + sum.GetValue());
            Console.WriteLine("Subtraktion: " + difference.GetValue());
            Console.WriteLine("Multiplikation: " + product.GetValue());
            Console.WriteLine("Division: " + quotient.GetValue());

            Console.WriteLine("Binär: " + num1.ToBinary());
            Console.WriteLine("Oktal: " + num1.ToOctal());
            Console.WriteLine("Dezimal: " + num1.ToDecimal());
            Console.WriteLine("Hexadezimal: " + num1.ToHexadecimal());

            Console.WriteLine("Drücken Sie eine Taste, um das Programm zu beenden...");
            Console.ReadKey();
        }
    }
}

