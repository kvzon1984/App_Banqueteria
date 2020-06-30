using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class Cliente
    {
        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }


        public Cliente()
        {
            this.Init();

        }



        private void Init()
        {
            RutCliente = string.Empty;
            RazonSocial = string.Empty;
            NombreContacto = string.Empty;
            MailContacto = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            IdActividadEmpresa = 0;
            IdTipoEmpresa = 0;
        }



        public List<Cliente> ReadAll()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Cliente> listaCliente = bbdd.Cliente.ToList<Datos.Cliente>();
                return GenerarListado(listaCliente);
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        private List<Cliente> GenerarListado(List<Datos.Cliente> listaCliente)
        {
            List<Cliente> lista = new List<Cliente>();

            foreach (Datos.Cliente dato in listaCliente)
            {
                Cliente cliente = new Cliente();
                CommonBC.Syncronize(dato, cliente);

                lista.Add(cliente);

            }
            return lista;
        }



        public bool Read()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.Cliente cliente = bbdd.Cliente.First(first => first.RutCliente == RutCliente);
                CommonBC.Syncronize(cliente, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool Create()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            Datos.Cliente cliente = new Datos.Cliente();

            try
            {
                CommonBC.Syncronize(this, cliente);
                bbdd.Cliente.Add(cliente);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bbdd.Cliente.Remove(cliente);
                return false;
            }
        }

        public bool Update()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();

            try
            {
                Datos.Cliente cliente = bbdd.Cliente.First(first => first.RutCliente == RutCliente);
                CommonBC.Syncronize(this, cliente);
                bbdd.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Delete()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.Cliente cliente = bbdd.Cliente.First(first => first.RutCliente == RutCliente);
                bbdd.Cliente.Remove(cliente);
                bbdd.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<Cliente> ReadAllByTipoEmpresa(int tipoEmpresa)
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Cliente> listaClientes = bbdd.Cliente.Where(qwert => qwert.IdTipoEmpresa == tipoEmpresa).ToList<Datos.Cliente>();
                List<Cliente> lista = GenerarListado(listaClientes);
                return lista;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> ReadAllByRut(String rutCliente)
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Cliente> listaClientes = bbdd.Cliente.Where(qwert => qwert.RutCliente == rutCliente).ToList<Datos.Cliente>();
                List<Cliente> lista = GenerarListado(listaClientes);
                return lista;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> ReadAllByTipoActividad( int idActividad)
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Cliente> listaClientes = bbdd.Cliente.Where(qwert => qwert.IdActividadEmpresa == idActividad).ToList<Datos.Cliente>();
                List<Cliente> lista = GenerarListado(listaClientes);
                return lista;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

    
    }

}
