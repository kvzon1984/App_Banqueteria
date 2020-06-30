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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnBreak.Negocio;

namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para UserControlListarContratos.xaml
    /// </summary>
    public partial class UserControlListarContratos : UserControl
    {
        public UserControlListarContratos()
        {
            InitializeComponent();
            LimpiarListarContrato();
        }

        private void LimpiarListarContrato()
        {
            
            CargarTipoEvento();
            CargarDataGridListContrato();

        }

        private void CargarDataGridListContrato()

        {
            dgListaContratoLc.ItemsSource = new Contrato().ReadAll();

        }

        //funciona como corresponde
        private void CargarTipoEvento()
        {
            
            cboTipoEvento.ItemsSource = new TipoEvento().ReadAll();
            cboTipoEvento.DisplayMemberPath = "Descripcion";
            cboTipoEvento.SelectedValuePath = "IdTipoEvento";
            cboTipoEvento.SelectedIndex = 0;
        }


        //Funciona correctamente, solo emite un mensaje
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Debe conectarse a una impresora", "Atencion", MessageBoxButton.OK, MessageBoxImage.Error);
            LimpiarListarContrato();
        }

        //Funciona correctamente
        //solo es un boton para actualizar el data grid, esto debe mejorarse ya que deberia
        //Actualizarse a tiempo real para asi quitar este boton inecesario
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            dgListaContratoLc.ItemsSource = null;
            dgListaContratoLc.ItemsSource = new Contrato().ReadAll();

            txtRutLc.Text = MyGlobalContrato.rutCliente;
            cboTipoEvento.SelectedIndex = MyGlobalContrato.idTipoEvento;
            txtNroContrato.Text = MyGlobalContrato.numero;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato()
            {
                Numero = MyGlobalContrato.numero
            };

            if (txtNroContrato.Text != "")
            {
                contrato.Numero = txtNroContrato.Text;
            }


            if (contrato.Read())
            {
                if (contrato.Delete())
                {
                    MessageBox.Show("Contrato fue Borrado correctamente", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarListarContrato();
                }
                else
                {
                    MessageBox.Show("No se puede ejecutar lo solicitado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimpiarListarContrato();
                }
            }
            else
            {
                MessageBox.Show("Error, revise si ingreso el Numero de contrato correctamente", "Atencion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarListarContrato();
            }
        }

        private void dgListaContratoLc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contrato contrato = dgListaContratoLc.SelectedItem as Contrato;

            MyGlobalContrato.numero = contrato.Numero;
            MyGlobalContrato.rutCliente = contrato.RutCliente;
            MyGlobalContrato.idTipoEvento = contrato.IdTipoEvento;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato()
            {
                Numero = txtNroContrato.Text
            };


            if (contrato.Read())
            {
                txtNroContrato.Text = contrato.Numero;
                txtRutLc.Text = contrato.Numero;
                cboTipoEvento.SelectedIndex = contrato.IdTipoEvento;

                MessageBox.Show("Contrato fue Encontrado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Contrato NO fue Encontrado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarListarContrato();
            }
        }
    }
}
