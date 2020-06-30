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
using System.Timers;


namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para UserControlListarCliente.xaml
    /// </summary>
    public partial class UserControlListarCliente : UserControl
    {
        public UserControlListarCliente()
        {
            InitializeComponent();

            LimpiarListar();


        }

        // Funciona correctamente
        private void LimpiarListar()
        {
            CargarActividadEmpresa();
            CargarTipoEmpresa();
            CargarDataGridList();

        }

        // Funciona correctamente
        private void CargarActividadEmpresa()
        {
            cboTipoActividad.ItemsSource = new ActividadEmpresa().ReadAll();
            cboTipoActividad.DisplayMemberPath = "Descripcion";
            cboTipoActividad.SelectedValuePath = "IdActividadEmpresa";
            cboTipoActividad.SelectedIndex = 0;

        }

        // Funciona correctamente
        private void CargarTipoEmpresa()
        {
            cboTipoEmpresa.ItemsSource = new TipoEmpresa().ReadAll();
            cboTipoEmpresa.DisplayMemberPath = "Descripcion";
            cboTipoEmpresa.SelectedValuePath = "IdTipoEmpresa";
            cboTipoEmpresa.SelectedIndex = 0;
        }

        // Funciona correctamente
        private void CargarDataGridList()

        {
            dgListaClienteLcli.ItemsSource = new Cliente().ReadAll();

        }

        // Funciona correctamente pero deberia actualizar el datagrid de forma automatica
        // debe mejorarse
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

            dgListaClienteLcli.ItemsSource = null;
            dgListaClienteLcli.ItemsSource = new Cliente().ReadAll();

            txtRutLcli.Text = MyGlobals.rut;
            cboTipoActividad.SelectedIndex = MyGlobals.actividad;
            cboTipoEmpresa.SelectedIndex = MyGlobals.empresa;

        }


        // Solo se entrega un mensaje pero no tiene funciones incorporadas
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Debe conectarse a una impresora", "Atencion", MessageBoxButton.OK, MessageBoxImage.Error);

        }




        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                RutCliente = MyGlobals.rut,
                
            };

            if(txtRutLcli.Text != "")
            {
                cliente.RutCliente = txtRutLcli.Text;
            }
             

            if (cliente.Read())
            {
                if (cliente.Delete())
                {
                    MessageBox.Show("Cliente fue Borrado correctamente", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarListar();
                }
                else
                {
                    MessageBox.Show("No se puede ejecutar lo solicitado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimpiarListar();
                }
            }
            else
            {
                MessageBox.Show("Error, revise si ingreso el Rut correctamente", "Atencion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarListar();
            }
        }

        private void dgListaClienteLcli_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cliente cliente = dgListaClienteLcli.SelectedItem as Cliente;

            MyGlobals.rut = cliente.RutCliente;
            MyGlobals.actividad = cliente.IdActividadEmpresa;
            MyGlobals.empresa = cliente.IdTipoEmpresa;

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                RutCliente = txtRutLcli.Text
            };


            if (cliente.Read())
            {
                txtRutLcli.Text = cliente.RutCliente;
                cboTipoActividad.SelectedIndex = cliente.IdActividadEmpresa;
                cboTipoEmpresa.SelectedIndex = cliente.IdTipoEmpresa;

                MessageBox.Show("Cliente fue Encontrado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
            {
                MessageBox.Show("Cliente NO fue Encontrado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarListar();
            }
        }
    }
}
