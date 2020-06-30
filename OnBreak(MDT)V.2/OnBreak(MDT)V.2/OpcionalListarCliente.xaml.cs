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
using OnBreak.Negocio;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;

namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para Opcional.xaml
    /// </summary>
    public partial class Opcional : Window
    {
        public Opcional()
        {
            InitializeComponent();
            CargarListaClienteDg();
        }

        // Funciona correctamente
        private void CargarListaClienteDg()
        {
            dgListarCliente.ItemsSource = new Cliente().ReadAll();

        }



        // Funciona correctamente el metodo para poder extrar una fila desde el data grid
        public void dgListarCliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            
           
            Cliente cliente = dgListarCliente.SelectedItem as Cliente;

            
            MyGlobals.rut= cliente.RutCliente;
            MyGlobals.razon = cliente.RazonSocial;
            MyGlobals.contacto = cliente.NombreContacto;
            MyGlobals.email = cliente.MailContacto;
            MyGlobals.direccion = cliente.Direccion;
            MyGlobals.telefono = cliente.Telefono;
            MyGlobals.actividad = cliente.IdActividadEmpresa;
            MyGlobals.empresa = cliente.IdTipoEmpresa;


            Close();

        }


        // Funciona correctamente pero siento que no es necesario falta modificar 
        private void Window_Closed(object sender, EventArgs e)
        {
            
            Close();
        }
    }



}
