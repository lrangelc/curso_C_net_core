using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Course:ObjetoEscuelaBase, ILugar
    {
        public Tipos_Jornada Tipo_Jornada { get; set; }

        public List<Student> Students { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }

        public string Address { get; set; }

        public void LimpiarLugar()
        {
            Printer.Dibujar_Linea();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Name} esta limpio");
        }
    }
}