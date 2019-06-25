using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string Unique_Id { get; private set; }

        public string Name { get; set; }

        public ObjetoEscuelaBase()
        {
            Unique_Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name}, {Unique_Id}";
        }
    }
}