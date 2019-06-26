using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> dic)
        {
            if (dic  == null)
                throw new ArgumentNullException(nameof(dic));
            _diccionario = dic;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
                //generar registro en log de Auditoria
            }
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEval)
        {
            listaEval = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEval
                select ev.Asignatura.Name).Distinct();
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            //sobrecargando la funcion GetListaAsignaturas
            return GetListaAsignaturas(out var dummy);
            
        }

        public Dictionary<string,IEnumerable<Evaluacion>> GetDicEvalXAsig()
        {
            var dicRta = new Dictionary<string,IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                    where eval.Asignatura.Name == asig
                    select eval;

                dicRta.Add(asig,evalsAsig);
            }
            return dicRta;
        }

        public Dictionary<string,IEnumerable<AlumnoPromedio>> GetPromedioAlumnoPorAsignatura()
        {
            var rta = new Dictionary<string,IEnumerable<AlumnoPromedio>>();
            var dicEvalXAsig = GetDicEvalXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsalumn = from eval in asigConEval.Value
                    group eval by new {
                        eval.Alumno.Unique_Id,
                        eval.Alumno.Name} 
                    into grupoEvalsAlumno
                    select new AlumnoPromedio {
                        alumnoId = grupoEvalsAlumno.Key.Unique_Id,
                        alumnoNombre = grupoEvalsAlumno.Key.Name,
                        promedio = grupoEvalsAlumno.Average( evaluacion => evaluacion.Nota)
                    };

                rta.Add(asigConEval.Key,promsalumn);
            }

            return rta;
        }

        public Dictionary<string,IEnumerable<AlumnoPromedio>> GetListaTopPromedio(int x)
        {
            var resp = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var dicPromAlumPorAsignatura = GetPromedioAlumnoPorAsignatura();

            // foreach (var item in dicPromAlumPorAsignatura)
            // {
            //     var dummy = (from ap in item.Value
            //                  orderby ap.promedio descending
            //                  select ap).Take(x);

            //     resp.Add(item.Key, dummy);
            // }

            return resp;
        }

    }
}