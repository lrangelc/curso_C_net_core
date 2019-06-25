using System;
using System.Collections.Generic;
using CoreEscuela;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using System.Linq;
using CoreEscuela.App;

namespace Etapa1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += SaliendoApp;
            AppDomain.CurrentDomain.ProcessExit += (obj,s) => Printer.Beep(1000,1000,1);
            AppDomain.CurrentDomain.ProcessExit -= SaliendoApp;

            // var escuela = new Escuela("Platzi Academy",foundation_year: 2012);
            // var escuela = new Escuela("Platzi Academy", 2012, Types_School.Secundaria, country: "Colombia", city: "Bogota");
            // escuela.Country = "Colombia";
            // escuela.City = "Bogota";
            // escuela.Type_School = Types_School.PreEscolar;

            // var curso1 = new Course() {
            //     Name = "101"
            // };

            // var curso2 = new Course() {
            //     Name = "201"
            // };

            // var curso3 = new Course() {
            //     Name = "301"
            // };

            // Console.WriteLine(escuela.Name);
            // Console.WriteLine(escuela);

            // System.Console.WriteLine("==========================");
            // // System.Console.WriteLine(curso1.Name + "," + curso1.Unique_Id);
            // // System.Console.WriteLine($"{curso2.Name},{curso2.Unique_Id}");
            // // System.Console.WriteLine(curso3);


            // var cursos = new Course[3];

            // cursos[0] = new Course() {
            //     Name = "101"
            // };

            // cursos[1] = curso2;

            // cursos[2] = new Course {
            //     Name = "101"
            // };
            // System.Console.WriteLine("While ==========================>");
            // ImprimirCursosWhile(cursos);

            // System.Console.WriteLine("DoWhile ==========================>");
            // ImprimirCursosDoWhile(cursos);

            // System.Console.WriteLine("For ==========================>");
            // ImprimirCursosFor(cursos);

            // System.Console.WriteLine("ForEach ==========================>");
            // ImprimirCursosForEach(cursos);


            // escuela.Arreglo_Cursos = new Course[] {
            //     new Course() { Name = "101"},
            //     new Course() { Name = "201"},
            //     new Course { Name = "301", Tipo_Jornada = Tipos_Jornada.Morning}
            // };

            // escuela.Lista_Cursos = new List<Course> {
            //     new Course() { Name = "101"},
            //     new Course() { Name = "201"},
            //     new Course { Name = "301", Tipo_Jornada = Tipos_Jornada.Morning}
            // };

            // escuela.Lista_Cursos.Add(new Course() { Name = "402", Tipo_Jornada = Tipos_Jornada.Afternoon });
            // escuela.Lista_Cursos.Add(new Course { Name = "102", Tipo_Jornada = Tipos_Jornada.Afternoon });

            // var otros_cursos = new List<Course> {
            //     new Course() { Name = "401"},
            //     new Course() { Name = "501"},
            //     new Course { Name = "601"}
            // };

            // escuela.Lista_Cursos.AddRange(otros_cursos);



            // otros_cursos.RemoveAt(2);

            // otros_cursos.Clear();

            // var otro = new Course() { Name = "602", Tipo_Jornada = Tipos_Jornada.Evening };

            // Console.WriteLine($"HashCode: {otro.GetHashCode()}");
            // escuela.Lista_Cursos.Add(otro);

            // escuela = null;
            // escuela.Cursos = null;

            // ImprimirCursos(escuela);
            // Console.WriteLine("================");
            // escuela.Lista_Cursos.Remove(otro);
            // escuela.Lista_Cursos.RemoveAll(Predicado);
            // escuela.Lista_Cursos.RemoveAll(x => x.Tipo_Jornada == Tipos_Jornada.Pending_Assignment);

            // ImprimirCursos(escuela);


            var engine = new Escuela_Engine();
            engine.Inicializar();
            Printer.Dibujar_Titulo("Bienvenidos a la Escuela");
            
            ImprimirCursos(engine.Escuela);

            //ObjetoEscuelaBase xx = new ObjetoEscuelaBase();
            //Printer.Ring_Bell();

            int conteoEvaluaciones,
                conteoAlumnos,
                conteoAsignaturas,
                conteoCursos = 0;

            var tt = engine.GetObjetosEscuela(false,false,false,false);

            var listaObjetos = engine.GetObjetosEscuela(out conteoEvaluaciones,
                out conteoAlumnos,
                out conteoAsignaturas,
                out conteoCursos,
                traeCursos:false,
                traeEvaluaciones:false);

            var listaILugar = from obj in listaObjetos
                where obj is ILugar
                select (ILugar) obj;

            engine.Escuela.LimpiarLugar();

            Dictionary<int,string> dic = new Dictionary<int,string>();

            dic[88] = "Hola";
            dic[40] = "Rangel";

            foreach (var item in dic)
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }

            var dictmp = engine.GetDiccionarioObjetos();

            engine.ImprimirDiccionario(dictmp);

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());

            reporteador.GetListaEvaluaciones();

            var listaAsig = reporteador.GetListaAsignaturas();
            
        }

        private static void SaliendoApp(object sender, EventArgs e)
        {
            Printer.Dibujar_Titulo("SALIENDO");
            Printer.Beep(2000,1000,3);
            Printer.Dibujar_Titulo("SALIO");
        }

        private static bool Predicado(Course obj)
        {
            return obj.Name == "101";
        }

        ///IMPRIME LOS CURSOS
        static void ImprimirCursos(Escuela escuela)
        {
            Printer.Dibujar_Titulo("Cursos de la Escuela");
            // if (escuela?.Cursos != null)
            if (escuela != null && escuela.Lista_Cursos != null)
            {
                // foreach (var curso in escuela.Arreglo_Cursos)
                foreach (var curso in escuela.Lista_Cursos)
                {
                    System.Console.WriteLine($"Nombre: {curso.Name} Id: {curso.Unique_Id} Jornada: {curso.Tipo_Jornada} HashCode: {curso.GetHashCode()}");
                }
            }
        }


        // static void ImprimirCursosWhile(Course[] cursos)
        // {
        //     int contador = 0;

        //     while (contador < cursos.Length)
        //     {
        //         System.Console.WriteLine($"Nombre: {cursos[contador].Name} Id: {cursos[contador].Unique_Id}");
        //         contador++;
        //     }
        // }

        // static void ImprimirCursosDoWhile(Course[] cursos)
        // {
        //     int contador = 0;

        //     do
        //     {
        //         System.Console.WriteLine($"Nombre: {cursos[contador].Name} Id: {cursos[contador].Unique_Id}");
        //         contador++;
        //     } while (contador < cursos.Length);
        // }

        // static void ImprimirCursosFor(Course[] cursos)
        // {

        //     for (int i = 0; i < cursos.Length; i++)
        //     {
        //         System.Console.WriteLine($"Nombre: {cursos[i].Name} Id: {cursos[i].Unique_Id}");
        //     }
        // }

        // static void ImprimirCursosForEach(Course[] cursos)
        // {
        //     foreach (var curso in cursos)
        //     {
        //         System.Console.WriteLine($"Nombre: {curso.Name} Id: {curso.Unique_Id}");
        //     }
        // }
    }
}
