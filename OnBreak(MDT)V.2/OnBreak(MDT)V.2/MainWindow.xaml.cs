using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using OnBreak.Negocio;
using System;

namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()

        {
            InitializeComponent();

            var menuInicio = new List<SubItem>();
            var item0 = new ItemMenu("Inicio",menuInicio,PackIconKind.House);
            

            var menuCliente = new List<SubItem>();
            menuCliente.Add(new SubItem("Ingresar Cliente" , new UserControlCrearCliente()));
            menuCliente.Add(new SubItem("Lista de Clientes", new UserControlListarCliente()));

            var item1 = new ItemMenu("Adm Clientes", menuCliente, PackIconKind.Account);


            var menuContrato = new List<SubItem>();
            menuContrato.Add(new SubItem("Ingresar Contrato", new UserControlAgregarContratos()));
            menuContrato.Add(new SubItem("Lista de Contratos", new UserControlListarContratos()));

            var item2 = new ItemMenu("Adm Contratos", menuContrato, PackIconKind.Contract);

            //var menuCuenta = new List<SubItem>();
            //menuCuenta.Add(new SubItem("Perfil usuario"));
            //menuCuenta.Add(new SubItem("Social"));
            //menuCuenta.Add(new SubItem("Tarea"));

            //var item3 = new ItemMenu("Cuenta", menuCuenta, PackIconKind.FaceProfileWoman);

            //var menuConfig = new List<SubItem>();
            //menuConfig.Add(new SubItem("Temas"));
            //menuConfig.Add(new SubItem("Ayuda"));
            //menuConfig.Add(new SubItem("Comentarios"));

            //var item4 = new ItemMenu("Personalización", menuConfig, PackIconKind.Theme);


            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            //Menu.Children.Add(new UserControlMenuItem(item3, this));
            //Menu.Children.Add(new UserControlMenuItem(item4, this));

        }

        internal void SwitchScreen (object sender)
        {
            var screen = ((UserControl)sender);
            if(screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void ButtonPopUpSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Metodos
        //Actividad empresa

       
         
    }

      
    
}

public static class MyGlobals
{
    public static string xd;
    public static string rut;
    public static string razon;
    public static string contacto;
    public static string email;
    public static string direccion;
    public static string telefono;
    public static int actividad;
    public static int empresa;
    public static int total;
}

public static class MyGlobalContrato
{
    public static string numero;
    public static DateTime creacion;
    public static DateTime termino;
    public static string rutCliente;
    public static string idModalidad;
    public static int idTipoEvento;
    public static DateTime fechaHoraInicio;
    public static DateTime fechaHoraTermino;
    public static int asistentes;
    public static int personalAdicional;
    public static bool realizado;
    public static double valorTotalContrato;
    public static string observaciones;
}
