using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using Microsoft.SqlServer.Server;
using OnBreak.Negocio;



namespace OnBreak_MDT_V._2
{
    /// <summary>
    /// Lógica de interacción para UserControlAgregarContratos.xaml
    /// </summary>
    public partial class UserControlAgregarContratos : UserControl
    {
        public UserControlAgregarContratos()
        {
            InitializeComponent();
            LimpiarContratos();
            

        }

        // Funciona correctamente pero aun tiene que modifcarse ya existe problemas 
        //para regisrar un contrato entonces e stearon algunos valores para pruebas habra que editarlos
        private void LimpiarContratos()
        {
            txtRut.Text = string.Empty;
            txtNumeroContrato.Text = string.Empty;
            dtpFechaInicio.DisplayDateEnd = DateTime.Today;
            dtpFechaTermino.DisplayDateStart = DateTime.Today;
            txtAsistentes.Text = string.Empty;
            txtPersonalAdicional.Text = string.Empty;
            dtpHoraInicio.Text = DateTime.Now.ToString("MM / dd / aaaa"); 
            dtpHoraTermino.Text = DateTime.Now.ToString("MM / dd / aaaa");
            txbTotal.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            rbtRealizado.IsChecked= false;
            
       
            CargarModalidadServicio();
            CargarTipoEvento();
        }



        // Funciona correctamente
        private void CargarModalidadServicio()
        {
            cboModalidad.ItemsSource = new ModalidadServicio().ReadAll();
            cboModalidad.DisplayMemberPath = "Nombre";
            cboModalidad.SelectedValuePath = "IdModalidad";
            cboModalidad.SelectedIndex = 0;
        }


        // Funciona correctamente
        private void CargarTipoEvento()
        {
            cboTipoEvento.ItemsSource = new TipoEvento().ReadAll();
            cboTipoEvento.DisplayMemberPath = "Descripcion";
            cboTipoEvento.SelectedValuePath = "IdTipoEvento";
            cboTipoEvento.SelectedIndex = 0;
        }



      
        // Funciona correctamente guardar un cliente tiene que revisarse
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bool realizado1 = false;

                if (rbtRealizado.IsChecked == true)
                {
                    realizado1 = true;

                }
                else
                {
                    realizado1 = false;
                }
                Cliente checkCliente = new Cliente();
                Contrato guardarContrato = new Contrato()
                {

                    Numero = txtNumeroContrato.Text,
                    Creacion = Convert.ToDateTime(dtpFechaInicio.SelectedDate),
                    Termino = Convert.ToDateTime(dtpFechaTermino.SelectedDate),
                    RutCliente = txtRut.Text,
                    IdModalidad = (string)cboModalidad.SelectedValue,
                    IdTipoEvento = (int)cboTipoEvento.SelectedValue,
                    FechaHoraInicio = Convert.ToDateTime(dtpHoraInicio.Value),
                    FechaHoraTermino = Convert.ToDateTime(dtpHoraTermino.Value),
                    Asistentes = int.Parse(txtAsistentes.Text),
                    PersonalAdicional = int.Parse(txtPersonalAdicional.Text),
                    Realizado = realizado1,
                    ValorTotalContrato = MyGlobals.total,
                    Observaciones = txtObservaciones.Text

                };

                if (checkCliente.Read())
                {
                    if (!guardarContrato.Read())
                    {
                        if (guardarContrato.Create())
                        {
                            MessageBox.Show("Contrato guardado correctamente", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarContratos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el contrato, revise si la informacion esta ingresada correctamente", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Error);
                            LimpiarContratos();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error este contrato ya existe", "Atencion", MessageBoxButton.OK, MessageBoxImage.Warning);
                        LimpiarContratos();
                    }
                }
                else
                {
                    MessageBox.Show("Error, el cliente no registrado y no es posible realizar la accion", "Atencion", MessageBoxButton.OK, MessageBoxImage.Warning);
                    LimpiarContratos();
                }
                
            }
            catch (Exception )
            {
                MessageBox.Show("Error tiene que Ingresar todos los datos", "Atencion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarContratos();
                
            }
            

        }


        // Aun sin terminar pero se tiene un idea del desarrollo
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Contrato buscarContrato = new Contrato()
            {
                Numero = txtNumeroContrato.Text
            };



            if (buscarContrato.Read() == true)
            {
                MessageBox.Show("Contrato encontratado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);

                if (buscarContrato.Realizado == true)
                {
                    rbtRealizado.IsChecked = buscarContrato.Realizado;
                }
                else
                {
                    rbtRealizado.IsChecked = buscarContrato.Realizado;
                }

                txtNumeroContrato.Text = buscarContrato.Numero;
                dtpFechaInicio.SelectedDate = buscarContrato.Creacion;
                dtpFechaTermino.SelectedDate = buscarContrato.Termino;
                txtRut.Text = buscarContrato.RutCliente;
                cboModalidad.SelectedValue = buscarContrato.IdModalidad;
                cboTipoEvento.SelectedValue = buscarContrato.IdTipoEvento;
                dtpHoraInicio.Value = buscarContrato.FechaHoraInicio;
                dtpHoraTermino.Value = buscarContrato.FechaHoraTermino;
                txtAsistentes.Text = buscarContrato.Asistentes.ToString();
                txtPersonalAdicional.Text = buscarContrato.PersonalAdicional.ToString();
                txbTotal.Text = buscarContrato.ValorTotalContrato.ToString();
                txtObservaciones.Text = buscarContrato.Observaciones;



            }
            else
            {
                MessageBox.Show("Contrato no se encuentra registrado", "Atecion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarContratos();
            }
        }



        // El metodo funciona correctamente el  calculo
        //Falta Agregar valor de eventos
        private void CalcularValorContrato()
        {
            int totalAsistentes = 0;
            int totalAdicional = 0;
            int UF = 30000;

            int _asistentes = Convert.ToInt32(txtAsistentes.Text);
            int _personalAdicional = Convert.ToInt32(txtPersonalAdicional.Text);

            if ((_asistentes >= 1) &(_asistentes <= 20))
            {
                totalAsistentes = UF * 3;
            }else if ((_asistentes >= 21) & (_asistentes <= 50))
            {
                totalAsistentes = UF * 5;
            }else if (_asistentes >= 51)
            {
                int adicional = 0;
                int contador = 0;

                adicional = _asistentes - 50;

                //Se divide por 20 ya que son los grupos de personas para cobrar un valor adicional
                contador= adicional / 20;
                contador = contador * 2;
                totalAsistentes = UF * (contador + 5);
            }

            //Calculo Personal Adicional

           

            if (_personalAdicional == 2)
            {
                totalAdicional = UF * 2;
            }else if (_personalAdicional == 3)
            {
                totalAdicional = UF * 3;
            }else if(_personalAdicional == 4)
            {
                totalAdicional = UF * (int)3.5;
            }else if(_personalAdicional > 4)
            {
                double adicionalPersonal = 0;
                
                adicionalPersonal = _personalAdicional - 4;

                // aca obtengo la cantidad total de uf segun el contrato adicional de empleados
                adicionalPersonal = adicionalPersonal * 0.5;

                adicionalPersonal=  adicionalPersonal + 3.5;

                totalAdicional = UF * (int)adicionalPersonal; 
            }


           int total = totalAsistentes + totalAdicional;

            MyGlobals.total = total;

            txbTotal.Text = total.ToString();

        }



        //Funciona Correctamente
        private void btnListar_Click(object sender, RoutedEventArgs e)
        {

            OpcionalListarContratos opcionalContratos = new OpcionalListarContratos();

            opcionalContratos.Show();

        }


        // Funciona Correctamente
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            Contrato actualizarContrato = new Contrato()
            {
                RutCliente = txtRut.Text
            };

            if (actualizarContrato.Update() == true)
            {

                bool realizado1 = false;

                if (rbtRealizado.IsChecked == true)
                {
                    realizado1 = true;

                }
                else
                {
                    realizado1 = false;
                }


                actualizarContrato.Numero = txtNumeroContrato.Text;
                actualizarContrato.Creacion = Convert.ToDateTime(dtpFechaInicio.SelectedDate);
                actualizarContrato.Termino = Convert.ToDateTime(dtpFechaTermino.SelectedDate);
                actualizarContrato.RutCliente = txtRut.Text;
                actualizarContrato.IdModalidad = (string)cboModalidad.SelectedValue;
                actualizarContrato.IdTipoEvento = (int)cboTipoEvento.SelectedValue;
                actualizarContrato.FechaHoraInicio = Convert.ToDateTime(dtpHoraInicio.Value);
                actualizarContrato.FechaHoraTermino = Convert.ToDateTime(dtpHoraTermino.Value);
                actualizarContrato.Asistentes = int.Parse(txtAsistentes.Text);
                actualizarContrato.PersonalAdicional = int.Parse(txtPersonalAdicional.Text);
                actualizarContrato.Realizado = realizado1;
                actualizarContrato.ValorTotalContrato = MyGlobals.total;
                actualizarContrato.Observaciones = txtObservaciones.Text;



                MessageBox.Show("Cliente Actualizado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarContratos();

            }
            else
            {
                MessageBox.Show("Cliente no se puede Actualizar UPDATE", "Atecion", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarContratos();
            }
        }


        //INICIO KEY UP AND DOWN
        //Terminado
        private void txtPersonalAdicional_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularValorContrato();
        }


        //Setear clases globales
        public void setearContrato()
        {
            txtNumeroContrato.Text = MyGlobalContrato.numero ;
            dtpFechaInicio.SelectedDate = MyGlobalContrato.creacion;
            dtpFechaTermino.SelectedDate = MyGlobalContrato.termino;
            txtRut.Text = MyGlobalContrato.rutCliente;
            cboModalidad.SelectedValue = MyGlobalContrato.idModalidad;
            cboTipoEvento.SelectedValue = MyGlobalContrato.idTipoEvento;
            dtpHoraInicio.Value = MyGlobalContrato.fechaHoraInicio;
            dtpHoraTermino.Value = MyGlobalContrato.fechaHoraTermino;
            txtAsistentes.Text = MyGlobalContrato.asistentes.ToString();
            txtPersonalAdicional.Text = MyGlobalContrato.personalAdicional.ToString();
            rbtRealizado.IsChecked = MyGlobalContrato.realizado;
            txbTotal.Text = MyGlobalContrato.valorTotalContrato.ToString();
            txtObservaciones.Text = MyGlobalContrato.observaciones ;
        }


        //Actualizar completo pero no es necesario
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            setearContrato();
        }
    }

}
         
    
            
        
    



