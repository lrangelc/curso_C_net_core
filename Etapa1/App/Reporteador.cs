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

        public IEnumerable<string> GetListaAsignaturas()
        {
            var listaEval = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEval
                select ev.Asignatura.Name).Distinct();
        }

        public Dictionary<string,IEnumerable<Evaluacion>> GetDicEvalXAsig()
        {
            var dicRta = new Dictionary<string,IEnumerable<Evaluacion>>();

            return dicRta;
        }
    }
}