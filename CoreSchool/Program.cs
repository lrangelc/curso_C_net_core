using System;

namespace coreschool
{
    class School
    {
        public string name;
        public string address;
        public int foundation_year;

        public string ceo;

        public void Ring_Bell()
        {
            Console.Beep(1000,3000);


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
    class Program
    {
        static void Main(string[] args)
        {
            var mySchool = new School();
            mySchool.name = "Platzi Academy";
            mySchool.Ring_Bell();
            Console.WriteLine("Hello World!");
        }
    }
}
