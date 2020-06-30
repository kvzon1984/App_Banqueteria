using OnBreak.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para OpcionalListarContratos.xaml
    /// </summary>
    public partial class OpcionalListarContratos : Window
    {
        public OpcionalListarContratos()
        {
            InitializeComponent();
            CargarListaClienteDg();
        }

        //funciona correctamente
        private void CargarListaClienteDg()
        {
            dgListaContratos.ItemsSource = new Contrato().ReadAll();

        }

        // Funciona correctamente el metodo para poder extrar una fila desde el data grid
        private void dgListaContratos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contrato listarContrato = dgListaContratos.SelectedItem as Contrato;


            MyGlobalContrato.numero = listarContrato.Numero;
            MyGlobalContrato.creacion = listarContrato.Creacion;
            MyGlobalContrato.termino = listarContrato.Termino;
            MyGlobalContrato.rutCliente = listarContrato.RutCliente;
            MyGlobalContrato.idModalidad = listarContrato.IdModalidad;
            MyGlobalContrato.idTipoEvento = listarContrato.IdTipoEvento;
            MyGlobalContrato.fechaHoraInicio = listarContrato.FechaHoraInicio;
            MyGlobalContrato.fechaHoraTermino = listarContrato.FechaHoraTermino;
            MyGlobalContrato.asistentes = listarContrato.Asistentes;
            MyGlobalContrato.personalAdicional = listarContrato.PersonalAdicional;
            MyGlobalContrato.realizado = listarContrato.Realizado;
            MyGlobalContrato.valorTotalContrato = listarContrato.ValorTotalContrato;
            MyGlobalContrato.observaciones = listarContrato.Observaciones;

            Close();
        }


        // Funciona correctamente pero siento que no es necesario falta modificar 
        private void Window_Closed(object sender, EventArgs e)
        {
  
                Close();
        }
    }
}
