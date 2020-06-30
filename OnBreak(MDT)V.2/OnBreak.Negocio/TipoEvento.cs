using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnBreak.Negocio
{
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoEvento = 0;
            Descripcion = string.Empty;
        }


        public List<TipoEvento> ReadAll()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                bbdd.Database.Connection.Open();
                List<Datos.TipoEvento> listaTipoEvento = bbdd.TipoEvento.ToList<Datos.TipoEvento>();
                bbdd.Database.Connection.Close();
                return GenerarListado(listaTipoEvento);
            }
            catch (Exception)
            {
                bbdd.Database.Connection.Close();
                return new List<TipoEvento>();
            }
        }

        private List<TipoEvento> GenerarListado(List<Datos.TipoEvento> listaTipoEvento)
        {
            List<TipoEvento> lista = new List<TipoEvento>();

            foreach (Datos.TipoEvento dato in listaTipoEvento)
            {
                TipoEvento tipoEvento = new TipoEvento();
                CommonBC.Syncronize(dato, tipoEvento);

                lista.Add(tipoEvento);

            }
            return lista;
        }

        public bool Read()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                bbdd.Database.Connection.Open();
                Datos.TipoEvento tipoEvento = bbdd.TipoEvento.First(first => first.IdTipoEvento == IdTipoEvento);
                CommonBC.Syncronize(tipoEvento, this);
                bbdd.Database.Connection.Close();
                return true;
            }
            catch (Exception)
            {

                bbdd.Database.Connection.Close();
                return false;
            }


            /*
             Lista, traiga todos los tipos modalividad,

             
             */

        }
    }
}
