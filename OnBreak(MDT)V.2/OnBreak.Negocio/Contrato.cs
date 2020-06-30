using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnBreak.Negocio
{
    public class Contrato
    {
        public string Numero { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            Creacion = DateTime.Today;
            Termino = DateTime.Today;
            RutCliente = string.Empty;
            IdModalidad = string.Empty;
            IdTipoEvento = 0;
            FechaHoraInicio = DateTime.Today;
            FechaHoraTermino = DateTime.Today;
            Asistentes = 0;
            PersonalAdicional = 0;
            Realizado = false;
            ValorTotalContrato = 0;
            Observaciones = string.Empty;

        }


        public List<Contrato> ReadAll()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Contrato> listaContrato = bbdd.Contrato.ToList<Datos.Contrato>();
                return GenerarListado(listaContrato);
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        private List<Contrato> GenerarListado(List<Datos.Contrato> listaContrato)
        {
            List<Contrato> lista = new List<Contrato>();

            foreach (Datos.Contrato dato in listaContrato)
            {
                Contrato contrato = new Contrato();
                CommonBC.Syncronize(dato, contrato);

                lista.Add(contrato);

            }
            return lista;
        }



        public bool Read()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.Contrato contrato = bbdd.Contrato.First(first => first.Numero == Numero);
                CommonBC.Syncronize(contrato, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool Create()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            Datos.Contrato contrato = new Datos.Contrato();

            try
            {
                CommonBC.Syncronize(this, contrato);
                bbdd.Contrato.Add(contrato);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bbdd.Contrato.Remove(contrato);
                return false;
            }
        }

        public bool Update()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();

            try
            {
                Datos.Contrato contrato = bbdd.Contrato.First(first => first.Numero == Numero);
                CommonBC.Syncronize(this, contrato);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Delete()
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                Datos.Contrato contrato = bbdd.Contrato.First(first => first.Numero == Numero);
                bbdd.Contrato.Remove(contrato);
                bbdd.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Contrato> ReadAllByNumeroContrato(string numero)
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Contrato> listaContratos = bbdd.Contrato.Where(qwert => qwert.Numero == numero).ToList<Datos.Contrato>();
                List<Contrato> lista = GenerarListado(listaContratos);
                return lista;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> ReadAllByRut(String rutCliente)
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Contrato> listaContratos = bbdd.Contrato.Where(qwert => qwert.RutCliente == rutCliente).ToList<Datos.Contrato>();
                List<Contrato> lista = GenerarListado(listaContratos);
                return lista;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> ReadAllByTipo(int idTipoEvento)
        {
            Datos.OnBreakDBEntities bbdd = new Datos.OnBreakDBEntities();
            try
            {
                List<Datos.Contrato> listaContratos = bbdd.Contrato.Where(qwert => qwert.IdTipoEvento == idTipoEvento).ToList<Datos.Contrato>();
                List<Contrato> lista = GenerarListado(listaContratos);
                return lista;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

    }

} 