using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnBreak.Negocio
{
    public class TipoEmpresa
    {
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        public TipoEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoEmpresa = 0;
            Descripcion = string.Empty;
        }


        public List<TipoEmpresa> ReadAll()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                bbdd.Database.Connection.Open();
                List<Datos.TipoEmpresa> listaTipoEmpresa = bbdd.TipoEmpresa.ToList<Datos.TipoEmpresa>();
                return GenerarListado(listaTipoEmpresa);
            }
            catch (Exception)
            {
                return new List<TipoEmpresa>();
            }
        }

        private List<TipoEmpresa> GenerarListado(List<Datos.TipoEmpresa> listaTipoEmpresa)
        {
            List<TipoEmpresa> lista = new List<TipoEmpresa>();

            foreach (Datos.TipoEmpresa dato in listaTipoEmpresa)
            {
                TipoEmpresa tipoEmpresa = new TipoEmpresa();
                CommonBC.Syncronize(dato, tipoEmpresa);

                lista.Add(tipoEmpresa);

            }
            return lista;
        }

        public bool Read()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.TipoEmpresa tipoEmpresa = bbdd.TipoEmpresa.First(first => first.IdTipoEmpresa == IdTipoEmpresa);
                CommonBC.Syncronize(tipoEmpresa, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
