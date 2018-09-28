using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Ausgabe(double tempcelsius, double tempfarenheit, double tempreamur, double tempkelvin)
        {
            Console.WriteLine("Celsius: " + tempcelsius);
            Console.WriteLine("Fahrenheit: " + tempfarenheit);
            Console.WriteLine("Reamur: " + tempreamur);
            Console.WriteLine("Kelvin: " + tempkelvin);
            Console.ReadLine();
            //return "Hello World!";
        }

        static void Main(string[] args)
        {
            int inputType = 0; 
            double inputValue = 0;
            double tempCelsius = 0;
            double tempFahrenheit = 0;
            double tempReamur = 0;
            double tempKelvin = 0;


            while (inputType < 1 || inputType > 4)
            {
                Console.WriteLine("Select input type: \n1 for Celsius, \n2 for Fahrenheit, \n3 for Reamur, \n4 for Kelvin");
                Int32.TryParse(Console.ReadLine(), out inputType);
            }

            do
            {
                Console.WriteLine("Provide value: ");
            } while (!Double.TryParse(Console.ReadLine(), out inputValue));

            switch (inputType)
            {
                case 1:
                    tempFahrenheit = inputValue * 9 / 5 + 32;
                    tempReamur = inputValue * 4 / 5;
                    tempKelvin = inputValue + 273.15;
                    Ausgabe(inputValue, tempFahrenheit, tempReamur, tempKelvin);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;


            }


            //Console.WriteLine(inputValue);
            //Console.WriteLine(inputType);
            //Console.ReadLine();

        }
    }
}
