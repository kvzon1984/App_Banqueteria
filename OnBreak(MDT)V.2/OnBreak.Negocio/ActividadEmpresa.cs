using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace OnBreak.Negocio
{
    public class ActividadEmpresa
    {
        public int IdActividadEmpresa { get; set;}
        public string Descripcion { get; set; }



        public ActividadEmpresa() 
        {
            this.Init();
        }

        private void Init()
        {
            IdActividadEmpresa = 0;
            Descripcion = string.Empty;
        }

        public List<ActividadEmpresa> ReadAll()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                bbdd.Database.Connection.Open();
                List<Datos.ActividadEmpresa> listaActividadEmpresa = bbdd.ActividadEmpresa.ToList<Datos.ActividadEmpresa>();
                bbdd.Database.Connection.Close();
                return GenerarListado(listaActividadEmpresa);
            }
            catch (Exception)
            {
                return new List<ActividadEmpresa>();
            }
        }

        private List<ActividadEmpresa> GenerarListado(List<Datos.ActividadEmpresa> listaActividadEmpresa)
        {
            List<ActividadEmpresa> lista = new List<ActividadEmpresa>();

            foreach (Datos.ActividadEmpresa dato in listaActividadEmpresa)
            {
                ActividadEmpresa actividadEmpresa = new ActividadEmpresa();
                CommonBC.Syncronize(dato, actividadEmpresa);
                lista.Add(actividadEmpresa);

            }
            return lista;
        }

        public bool Read()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.ActividadEmpresa actividadEmpresa = bbdd.ActividadEmpresa.First(first => first.IdActividadEmpresa == IdActividadEmpresa);
                CommonBC.Syncronize(actividadEmpresa, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



    }
}
