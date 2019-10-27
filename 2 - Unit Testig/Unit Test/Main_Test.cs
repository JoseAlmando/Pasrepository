using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace Unit_Test
{
    [TestClass]
    public class Main_Test
    {
        private int resultadoRequerido;
        private int resultadoObtenido;
        Main_app app = new Main_app();
        [TestMethod]
        public void Suma_test()
        {
            resultadoRequerido = 4;

            resultadoObtenido = app.suma(2, 2);

            Assert.AreEqual(resultadoRequerido, resultadoObtenido);
        }

        public void Numeros_Entereos_Test()
        {
            resultadoObtenido = (int)2;

        }
    }

}
