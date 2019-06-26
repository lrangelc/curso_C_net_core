using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion:ObjetoEscuelaBase
    {
        public Asignatura Asignatura { get; set; }
        public Student Alumno { get; set; }
        public double Nota { get; set; }
        public int Numero { get; set; }

        public override string ToString() 
        {
            return $"{Nota}, {Alumno.Name}, {Asignatura.Name}";
        }
    }
}