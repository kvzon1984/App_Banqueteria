using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak_MDT_V._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak_MDT_V._2.Tests
{
    [TestClass()]
    public class UserControlAgregarContratosTests
    {
        [TestMethod()]
        public void CalcularValorContratoTest()
        {

            //se creo la pruebas unitarias pero no funciona como corresponde
            // ya que el metodo CalcularValorContrato Recibe la informacion desde el usuario
            // txt y este asigna el valor en una vaariable local y luego se ejecuta un 
            //metodo para poder actualizar el valor que se le muestra al usuario 
            //de forma inmediata, por lo tanto esta prueba unitaria no pudo realizarse
            // por falta de conocimiento y que no queriamos romper el codigo antes de entregarlo

            //Arrange
            var calcular = new UserControlAgregarContratos();
            //Act

             //calcular.CalcularValorContrato();
            //Assert


            //Assert.AreEqual(calcular.CalcularValorContrato());
            //Assert.A
        }
    }
}