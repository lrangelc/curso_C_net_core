using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public sealed class Escuela:ObjetoEscuelaBase, ILugar
    {
        //private string name;
        private List<Course> _lista_Cursos;

        /*
        public string Name
        {
            get { return Name; }
            set { Name = value.ToUpper(); }
        }
        */
        public int Foundation_Year { get; set; }
        public string Country { get; set; }

        public string City { get; set; }
        /*
                public Escuela(string name,int foundation_year)
                {
                    this.name = name;
                    this.foundation_year = foundation_year;
                }
                 */

        string ILugar.Address {get;set;}

        //void ILugar.LimpiarLugar()
        public void LimpiarLugar()
        {
            Printer.Dibujar_Linea();
            Console.WriteLine("Limpiando Establecimiento...");

            foreach (var curso in Lista_Cursos)
            {
                curso.LimpiarLugar();
            }
            
            Printer.Dibujar_Titulo($"Escuela {Name} esta limpia");
            //Printer.Ring_Bell();
        }

        public Types_School Type_School { get; set; }

        public Escuela(string name, int foundation_year) => (Name, Foundation_Year) = (name, foundation_year);

        // public Course[] Arreglo_Cursos { get; set; }

        public List<Course> Lista_Cursos { get => _lista_Cursos; set => _lista_Cursos = value; }

        public Escuela(string name,
            int foundation_year,
            Types_School type_school,
            string country = "",
            string city = "")
        {
            (Name, Foundation_Year) = (name, foundation_year);
            Type_School = type_school;
            Country = country;
            City = city;
        }

        public override string ToString()
        {
            // return $"Name: {Name}, Type: {Type_School}  \nCountry: {Country}, City: {City}";
            
            string newLine = System.Environment.NewLine;
            return $"Name: {Name}, Type: {Type_School}  {newLine}Country: {Country}, City: {City}";
        }
    }
}