using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using MaterialDesignThemes.Wpf;
using Microsoft.SqlServer.Server;
using OnBreak.Negocio;

namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para UserControlCrearCliente.xaml
    /// </summary>
    public partial class UserControlCrearCliente : UserControl
    {

       
        public UserControlCrearCliente()
        {
            InitializeComponent();
            LimpiarCliente();

        }

        // Funciona correctamente
        private void LimpiarCliente()
        {
            txtRutCli.Text = string.Empty;
            txtRazonSocialCli.Text = string.Empty;
            txtNombreContactoCli.Text = string.Empty;
            txtMailContactoCli.Text = string.Empty;
            txtDireccionCli.Text = string.Empty;
            txtTelefonoCli.Text = string.Empty;


            CargarActividadEmpresa();
            CargarTipoEmpresa();
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
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Cliente guardarCliente = new Cliente()
            {
                RutCliente = txtRutCli.Text,
                RazonSocial = txtRazonSocialCli.Text,
                NombreContacto = txtNombreContactoCli.Text,
                MailContacto = txtMailContactoCli.Text,
                Direccion = txtDireccionCli.Text,
                Telefono = txtTelefonoCli.Text,
                IdActividadEmpresa = (int)cboTipoActividad.SelectedValue,
                IdTipoEmpresa = (int)cboTipoEmpresa.SelectedValue
            };

            if (!guardarCliente.Read())
            {
                if (guardarCliente.Create())
                {
                    MessageBox.Show("Cliente guardado correctamente", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCliente();
                }
                else
                {
                    MessageBox.Show("No se puede ejecutar lo solicitado", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimpiarCliente();
                }
            }
            else
            {
                MessageBox.Show("Error el cliente ya existe", "Atencion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarCliente();
            }


        }
        // Funciona correctamente
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Cliente buscarCliente = new Cliente()
            {
                RutCliente = txtRutCli.Text
            };



            if (buscarCliente.Read() == true)
            {
                MessageBox.Show("Cliente encontratado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);

                txtRutCli.Text = buscarCliente.RutCliente;
                txtRazonSocialCli.Text = buscarCliente.RazonSocial;
                txtNombreContactoCli.Text = buscarCliente.NombreContacto;
                txtMailContactoCli.Text = buscarCliente.MailContacto;
                txtDireccionCli.Text = buscarCliente.Direccion;
                txtTelefonoCli.Text = buscarCliente.Telefono;
                cboTipoActividad.SelectedIndex = buscarCliente.IdActividadEmpresa;
                cboTipoEmpresa.SelectedIndex = buscarCliente.IdTipoEmpresa;

            }
            else
            {
                MessageBox.Show("Cliente no se encuentra registrado", "Atecion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarCliente();
            }

        }
        //Falta modificar y arreglar 
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente actualizar = new Cliente()
            {
                RutCliente = txtRutCli.Text
            };

            if (actualizar.Update() == true)
            {

                actualizar.RutCliente = txtRutCli.Text;
                actualizar.RazonSocial = txtRazonSocialCli.Text ;
                actualizar.NombreContacto = txtNombreContactoCli.Text;
                actualizar.MailContacto = txtMailContactoCli.Text;
                actualizar.Direccion = txtDireccionCli.Text;
                actualizar.Telefono = txtTelefonoCli.Text;
                actualizar.IdActividadEmpresa = cboTipoActividad.SelectedIndex;
                actualizar.IdTipoEmpresa = cboTipoEmpresa.SelectedIndex;
                 MessageBox.Show("Cliente Actualizado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCliente();

            } 
            else
            {
                MessageBox.Show("Cliente no se puede Actualizar UPDATE", "Atecion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarCliente();
            }


        }
        // Funciona correctamente pero aun se puede mejorar
        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            Opcional opcional = new Opcional();
         
            opcional.Show();
        }
        // Funciona correctamente pero todavia se tiene que mejorar para 
        // que funcione de forma automatica y no seleccionando un boton Actualizar
        public void StearClase()
        {
            txtRutCli.Text = MyGlobals.rut;
            txtRazonSocialCli.Text = MyGlobals.razon;
            txtNombreContactoCli.Text = MyGlobals.contacto;
            txtMailContactoCli.Text = MyGlobals.email;
            txtDireccionCli.Text = MyGlobals.direccion;
            txtTelefonoCli.Text = MyGlobals.telefono;
            cboTipoActividad.SelectedIndex = MyGlobals.actividad;
            cboTipoEmpresa.SelectedIndex = MyGlobals.empresa;   
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            StearClase();
        }


    }
}
