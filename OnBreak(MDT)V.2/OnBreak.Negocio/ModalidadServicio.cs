using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnBreak.Negocio
{
    public class ModalidadServicio
    {

        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public ModalidadServicio()
        {
            this.Init();
        }

        private void Init()
        {
            IdModalidad = string.Empty;
            IdTipoEvento = 0;
            Nombre = string.Empty;
            ValorBase = 0;
            PersonalBase = 0;
        }


        public List<ModalidadServicio> ReadAll()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {   
                List<Datos.ModalidadServicio> listaModalidad = bbdd.ModalidadServicio.ToList<Datos.ModalidadServicio>();
                return GenerarListado(listaModalidad);
            }
            catch (Exception)
            {
                return new List<ModalidadServicio>();
            }
        }

        private List<ModalidadServicio> GenerarListado(List<Datos.ModalidadServicio> listaModalidad)
        {
            List<ModalidadServicio> lista = new List<ModalidadServicio>();

            foreach (Datos.ModalidadServicio dato in listaModalidad)
            {
                ModalidadServicio modalidadServicio = new ModalidadServicio();
                CommonBC.Syncronize(dato, modalidadServicio);

                lista.Add(modalidadServicio);

            }
            return lista;
        }

        public bool Read()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.ModalidadServicio modalidadServicio = bbdd.ModalidadServicio.First(first => first.IdModalidad == IdModalidad);
                CommonBC.Syncronize(modalidadServicio, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



    }
}
