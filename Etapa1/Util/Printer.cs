using System;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void Dibujar_Linea(int tam = 20)
        {
            Console.WriteLine("".PadLeft(tam,'='));
        }   
        
        public static void Dibujar_Titulo(string titulo)
        {
            var tam = titulo.Length + 4;
            Dibujar_Linea(tam);
            Console.WriteLine($"| {titulo} |");
            Dibujar_Linea(tam);
        }

        public static void presioneEnter()
        {
            Console.WriteLine("Presione ENTER para continuar...");
        }

        public static void Beep(int frequency = 1000,int duration = 500,int cantidad = 1)
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.Beep(frequency,duration);
            }
        }

        public static void Ring_Bell()
        {
            Console.Beep(987, 1000); //Si
            Console.Beep(1174, 500); //Re'
            Console.Beep(880, 1500); //La

            Console.Beep(783, 250); //Sol
            Console.Beep(880, 250); //La
            Console.Beep(987, 1000); //Si

            Console.Beep(1174, 500); //Re'
            Console.Beep(880, 1500); //La

            Console.Beep(987, 1000); //Si
            Console.Beep(1174, 500); //Re'
            Console.Beep(1760, 1000); //La'
            Console.Beep(1567, 500); //Sol'
            Console.Beep(1174, 1000); //Re'

            Console.Beep(1046, 250); //Do
            Console.Beep(987, 250); //Si
            Console.Beep(880, 1000); //La

        }
    }
}