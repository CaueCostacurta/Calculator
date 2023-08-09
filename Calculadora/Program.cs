using System;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Calculadora
{
    internal class Program
    {
        delegate float Calculo(float a, float b); 
        static void Main(string[] args)
        {
            Intro();
        }

        static void Intro()
        {
            string calculadoraLoop;
            do
            {
                Console.WriteLine("Digite um valor:");
                string aInput = Console.ReadLine();
                float aNum;
                while(!float.TryParse(aInput, out aNum))
                {
                    Console.WriteLine("Não é um número válido, por favor tente novamente");
                    aInput = Console.ReadLine();
                }
                Console.WriteLine();


                Console.WriteLine("Digite um segundo valor:");
                string bInput = Console.ReadLine();
                float bNum;
                while (!float.TryParse(bInput, out bNum))
                {
                    Console.WriteLine("Não é um número válido, por favor tente novamente");
                    bInput = Console.ReadLine();
                }
                Console.WriteLine();


                Console.WriteLine("Escolha um dos seguintes operadores para prosseguir: (+ - * / %) ");
                string operadorInput = Console.ReadLine();

                bool loopBreak = true;
                while (loopBreak == true)
                {
                    switch (operadorInput)
                    {
                        case "+":
                            Console.WriteLine($"{aNum} + {bNum} = {Calcular(aNum, bNum, Add)}");
                            loopBreak = false;
                            break;
                        case "-":
                            Console.WriteLine($"{aNum} - {bNum} = {Calcular(aNum, bNum, Sub)}");
                            loopBreak = false;
                            break;
                        case "*":
                            Console.WriteLine($"{aNum} * {bNum} = {Calcular(aNum, bNum, Mult)}");
                            loopBreak = false;
                            break;
                        case "/":
                            Console.WriteLine($"{aNum} / {bNum} = {Calcular(aNum, bNum, Div)}");
                            loopBreak = false;
                            break;
                        case "%":
                            Console.WriteLine($"{aNum} % {bNum} = {Calcular(aNum, bNum, Mod)}");
                            loopBreak = false;
                            break;
                        default: 
                            Console.WriteLine("Por favor escolha um dos operadores acima");
                            operadorInput = Console.ReadLine();
                            break;
                    }
                }                
                Console.WriteLine();                
                Console.WriteLine("Quer continuar? Digite (s) para Sim ou aperte qualquer outra tecla para sair:");
                calculadoraLoop = Console.ReadLine();
                Console.WriteLine("-----------------------");

            }
            while (calculadoraLoop is "s" or "S");                     
        }

        static float Calcular(float x, float y, Calculo calculo)
        {
            return calculo(x, y);
        }

        static float Add(float x, float y) => x + y;
        static float Sub(float x, float y) => x - y;
        static float Mult(float x, float y) => x * y;
        static float Div(float x, float y)
        {           
            if (y == 0)
            {
                Console.WriteLine("Erro: Não se pode dividir por zero");
                Console.WriteLine("'8' = infinito");
            }
            return x / y;
        }
        static float Mod(float x, float y) => x % y;
    }
}