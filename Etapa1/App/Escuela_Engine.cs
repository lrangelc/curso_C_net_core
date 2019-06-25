using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class Escuela_Engine
    {
        public Escuela Escuela { get; set; }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, Types_School.Secundaria, country: "Colombia", city: "Bogota");
            Escuela.Type_School = Types_School.PreEscolar;
            Cargar_Cursos();
            Cargar_Asignaturas();
            Cargar_Evaluaciones();

            int conteoEvaluaciones,
                conteoAlumnos,
                conteoAsignaturas,
                conteoCursos = 0;

            var lista = GetObjetosEscuela(out conteoEvaluaciones,
                out conteoAlumnos,
                out conteoAsignaturas,
                out conteoCursos);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursosX = true)
        {
            return GetObjetosEscuela(out int dummy,out dummy, out dummy,out dummy,
                traeEvaluaciones:traeEvaluaciones,
                traeAlumnos:traeAlumnos,
                traeAsignaturas:traeAsignaturas,
                traeCursos:traeCursosX);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            conteoEvaluaciones =
                conteoAlumnos =
                conteoAsignaturas =
                conteoCursos =  0;
            var listaobj = new List<ObjetoEscuelaBase>();

            listaobj.Add(Escuela);
            if (traeCursos)
                listaobj.AddRange(Escuela.Lista_Cursos);

            foreach (var curso in Escuela.Lista_Cursos)
            {
                if (traeAsignaturas)
                    listaobj.AddRange(curso.Asignaturas);
                if (traeAlumnos)
                    listaobj.AddRange(curso.Students);

                if (traeEvaluaciones)
                    foreach (var estudiante in curso.Students)
                    {
                        conteoEvaluaciones += estudiante.Evaluaciones.Count;
                        listaobj.AddRange(estudiante.Evaluaciones);
                    }
            }
            return listaobj;
        }

        public Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>>();

            // diccionario.Add(LlaveDiccionario.Escuela, new[] {Escuela});
            // diccionario.Add("Escuela_Yeap",new List<ObjetoEscuelaBase> {Escuela});
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Lista_Cursos );
            // diccionario.Add("Cursos_Yeap", Escuela.Lista_Cursos.Cast<ObjetoEscuelaBase>() );

            var listaTmpEvaluacion = new List<Evaluacion>();
            var listaTmpEstudiante = new List<Student>();
            var listaTmpAsignatura = new List<Asignatura>();

            foreach (var cur in Escuela.Lista_Cursos)
            {
               listaTmpEvaluacion.AddRange(cur.Evaluaciones);
               listaTmpEstudiante.AddRange(cur.Students);
               listaTmpAsignatura.AddRange(cur.Asignaturas);
               
            }

            diccionario.Add(LlaveDiccionario.Evaluacion, listaTmpEvaluacion );
            diccionario.Add(LlaveDiccionario.Estudiante, listaTmpEstudiante );
            diccionario.Add(LlaveDiccionario.Asignatura, listaTmpAsignatura );

            return diccionario;
        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> dic,bool imprimirevaluaciones = false)
        {
            foreach (var obj in dic)
            {
                if (obj.Key == LlaveDiccionario.Evaluacion)
                {
                    if (imprimirevaluaciones)
                    {
                        Util.Printer.Dibujar_Titulo(obj.Key.ToString());
                        foreach (var val in obj.Value)
                        {
                            Console.WriteLine(val);
                        }
                    }

                }
                else
                {
                    Util.Printer.Dibujar_Titulo(obj.Key.ToString());
                    foreach (var val in obj.Value)
                    {
                        Console.WriteLine(obj.Key + ": " + val);
                    }
                }          
            }            
        }


        #region Metodos de Carga
        private void Cargar_Cursos()
        {
            Escuela.Lista_Cursos = new List<Course> {
                new Course() { Name = "101"},
                new Course() { Name = "201"},
                new Course { Name = "301", Tipo_Jornada = Tipos_Jornada.Morning},
                new Course { Name = "401", Tipo_Jornada = Tipos_Jornada.Afternoon},
                new Course { Name = "501", Tipo_Jornada = Tipos_Jornada.Afternoon}
            };
        }

        private void Cargar_Asignaturas()
        {
            foreach (var curso in Escuela.Lista_Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Name="Matemáticas"} ,
                            new Asignatura{Name="Educación Física"},
                            new Asignatura{Name="Castellano"},
                            new Asignatura{Name="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }

            Random rnd = new Random();
            foreach (var c in Escuela.Lista_Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Students = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        private List<Student> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Student { Name = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.Unique_Id).Take(cantidad).ToList();
        }

        // private List<Evaluacion> Generar_Evaluaciones()
        // {
        //     var listaEvaluaciones =  from n1 in Escuela.Lista_Cursos.Asignaturas
        //                         from n2 in Escuela.Lista_Cursos.Students
        //                         select new Evaluacion{ Student_Id=$"{n2}", Asignatura_Id = $"{n1}" };

        //     return listaEvaluaciones.ToList();
        // }

        private void Cargar_Evaluaciones()
        {
            foreach (var curso in Escuela.Lista_Cursos)
            {
                curso.Evaluaciones = new List<Evaluacion>();

                Random rnd = new Random();

                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var student in curso.Students)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int nota = rnd.Next(0, 5);
                            Evaluacion evaluacion = new Evaluacion{Asignatura = asignatura,
                                Nota = nota,
                                Numero = i + 1,
                                Alumno = student};

                            curso.Evaluaciones.Add(evaluacion);
                            student.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }
    #endregion Metodos de Carga  
    }
}