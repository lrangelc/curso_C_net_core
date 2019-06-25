using System;
using CoreEscuela.Entidades;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Student:ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}