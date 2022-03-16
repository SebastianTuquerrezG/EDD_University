using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;

namespace uTestDemoColecciones
{
    [TestClass]
    public class uTestPilaVector
    {
        #region Atributos de prueba
        private clsPilaVector<int> testPila;
        private int[] testItems;
        private int testItem;
        #endregion
        #region Casos de prueba
        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        [TestMethod]
        public void uTestConstructorNoParametrizado()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        #endregion
        #region Constructor Con Capacidad
        [TestMethod]
        public void uTestConstructor1CapacidadNegativa()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(-100);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor1CapacidadCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar 
            testPila = new clsPilaVector<int>(0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor1CapacidadNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darItems().Length);
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor1CapacidadEnBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar 
            testPila = new clsPilaVector<int>(int.MaxValue / 64);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(int.MaxValue / 64, testPila.darItems().Length);
            Assert.AreEqual(int.MaxValue / 64, testPila.darCapacidad());
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor1CapacidadFueraDeBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor1CapacidadEnMaxValue()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        #endregion
        #region Constructor con Capacidad y Tipo de Flexibilidad
        [TestMethod]
        public void uTestConstructor2CapacidadNegativaFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar 
            testPila = new clsPilaVector<int>(-100, true);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadNegativaNoFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar 
            testPila = new clsPilaVector<int>(-100, false);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadCeroFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar 
            testPila = new clsPilaVector<int>(0, true);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadCeroNoFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(0, false); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadNormalFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500, true); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darItems().Length);
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadNormalNoFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500, false); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darItems().Length);
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadMasAllaBordeFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1, true); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadMasAllaBordeNOFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1, false); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadEnMaxValueFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue, true); 
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor2CapacidadEnMaxValueNoFlexible()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar 
            testPila = new clsPilaVector<int>(int.MaxValue, false);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        #endregion
        #region Constructor con Capacidad y Factor de Crecimiento
        [TestMethod]
        public void uTestConstructor3CapacidadNegativaFactorCrecimientoNegativo()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(-100,-10);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadNegativaFactorCrecimientoCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(-100, 0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadNegativaFactorCrecimientoNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(-100, 10);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadNegativaFactorCrecimientoMasAllaBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(-100, int.MaxValue / 64 + 1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }

        [TestMethod]
        public void uTestConstructor3CapacidadCeroFactorCrecimientoNegativo()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(0, -1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadCeroFactorCrecimientoCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(0, 0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadCeroFactorCrecimientoNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(0, 500);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(500, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadCeroFactorCrecimientoMasAllaBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(0, int.MaxValue / 64 + 1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }

        [TestMethod]
        public void uTestConstructor3CapacidadNormalFactorCrecimientoNegativo()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500, -1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadNormalFactorCrecimientoCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500, 0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darItems().Length);
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadNormalFactorCrecimientoNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500, 500);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darItems().Length);
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(500, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadNormalFactorCrecimientoMasAllaBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(500, int.MaxValue / 64 + 1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }

        [TestMethod]
        public void uTestConstructor3CapacidadEnBordeFactorCrecimientoNegativo()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64, -1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadEnBordeFactorCrecimientoCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64, 0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(int.MaxValue / 64, testPila.darItems().Length);
            Assert.AreEqual(int.MaxValue / 64, testPila.darCapacidad());
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadEnBordeFactorCrecimientoNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64, 500);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadEnBordeFactorCrecimientoMasAllaBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64, int.MaxValue / 64 + 1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }

        [TestMethod]
        public void uTestConstructor3CapacidadFueraDeBordeFactorCrecimientoNegativo()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1, -1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadFueraDeBordeFactorCrecimientoCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1, 0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadFueraDeBordeFactorCrecimientoNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1, 500);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadFueraDeBordeFactorCrecimientoMasAllaBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue / 64 + 1, int.MaxValue / 64 + 1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }

        [TestMethod]
        public void uTestConstructor3CapacidadEnMaxValueFactorCrecimientoNegativo()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue, -1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadEnMaxValueFactorCrecimientoCero()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue, 0);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadEnMaxValueFactorCrecimientoNormal()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue, 500);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestConstructor3CapacidadEnMaxValueFactorCrecimientoMasAllaBorde()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testPila = new clsPilaVector<int>(int.MaxValue, int.MaxValue / 64 + 1);
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        #endregion
        #endregion
        #region Accesores
        [TestMethod]
        public void uTestDarItems()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3] { 1, 2, 3 };
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(3, testPila.darItems().Length);
            Assert.AreEqual(1, testPila.darItems()[0]);
            Assert.AreEqual(2, testPila.darItems()[1]);
            Assert.AreEqual(3, testPila.darItems()[2]);
            #endregion
        }
        [TestMethod]
        public void uTestDarCapacidad()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3] { 1, 2, 3 };
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(3, testPila.darCapacidad());
            #endregion
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3] { 1, 2, 3 };
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(3, testPila.darLongitud());
            #endregion
        }
        [TestMethod]
        public void uTestDarFactorCrecimiento()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItemsConLongitudCero()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[0];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ponerItems(testItems));
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudNormal()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ponerItems(testItems));
            Assert.AreEqual(3, testPila.darCapacidad());
            Assert.AreEqual(3, testPila.darLongitud());
            Assert.AreEqual(1, testPila.darItems()[0]);
            Assert.AreEqual(2, testPila.darItems()[1]);
            Assert.AreEqual(3, testPila.darItems()[2]);
            Assert.AreEqual(3, testPila.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudEnBorde()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[int.MaxValue / 64];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ponerItems(testItems));
            Assert.AreEqual(int.MaxValue / 64, testPila.darCapacidad());
            Assert.AreEqual(int.MaxValue / 64, testPila.darLongitud());
            for (int varIterador = 0; varIterador < int.MaxValue / 64; varIterador++)
                Assert.AreEqual(0, testPila.darItems()[varIterador]);
            Assert.AreEqual(int.MaxValue / 64, testPila.darItems().Length);
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudMasAlladelBorde()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[int.MaxValue / 64 + 1];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.ponerItems(testItems));
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darItems().Length);
            #endregion
        }

        [TestMethod]
        public void uTestAjustarFlexibilidadCapacidadEnBorde()
        {
            #region Configurar
            testPila = new clsPilaVector<int>(int.MaxValue / 64);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.ajustarFlexibilidad(true));
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(int.MaxValue / 64, testPila.darCapacidad());
            Assert.AreEqual(int.MaxValue / 64, testPila.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestAjustarFlexibilidadCapacidadCero()
        {
            #region Configurar
            testPila = new clsPilaVector<int>(0);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.ajustarFlexibilidad(false));
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(0, testPila.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestAjustarFlexibilidadCapacidadNormal()
        {
            #region Configurar
            testPila = new clsPilaVector<int>(500);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ajustarFlexibilidad(false));
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(500, testPila.darItems().Length);
            #endregion
        }

        [TestMethod]
        public void uTestAjustarFactorCrecimientoNormalEnCapacidadNormal()
        {
            #region Configurar
            testPila = new clsPilaVector<int>(500);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ajustarFactorCrecimiento(3000));
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(3000, testPila.darFactorCrecimiento());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(500, testPila.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestAjustarFactorCrecimientoEnBordeEnCapacidadNormal()
        {
            #region Configurar
            testPila = new clsPilaVector<int>(500);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ajustarFactorCrecimiento((int.MaxValue / 64)-testPila.darItems().Length));
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(int.MaxValue / 64 - testPila.darItems().Length, testPila.darFactorCrecimiento());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(500, testPila.darCapacidad());
            Assert.AreEqual(500, testPila.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestAjustarFactorCrecimientoEnBordeConCapacidadEnBorde()
        {
            #region Configurar
            testPila = new clsPilaVector<int>(int.MaxValue / 64);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.ajustarFactorCrecimiento(int.MaxValue / 64));
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(int.MaxValue / 64, testPila.darCapacidad());
            Assert.AreEqual(int.MaxValue / 64, testPila.darItems().Length);
            #endregion
        }
        #endregion
        #region Consultores
        [TestMethod]
        public void uTestEsDinamica()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.esDinamica());
            #endregion
        }
        #endregion
        #region CRUDS
        #region Apilar
        [TestMethod]
        public void uTestApilarEnTADVacio()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();    
            #endregion 
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.apilar(123));
            Assert.AreEqual(123, testPila.darItems()[0]);
            Assert.AreEqual(1, testPila.darLongitud());
            Assert.AreEqual(1000, testPila.darCapacidad());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            Assert.AreEqual(true, testPila.esDinamica());
            #endregion
        }
        [TestMethod]
        public void uTestApilarEnTADConItems()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testPila.apilar(123);
            testPila.apilar(456);
            testPila.apilar(789);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.apilar(777));
            Assert.AreEqual(1000, testPila.darCapacidad());
            Assert.AreEqual(4,testPila.darLongitud());
            Assert.AreEqual(777, testPila.darItems()[0]);
            Assert.AreEqual(789, testPila.darItems()[1]);
            Assert.AreEqual(456, testPila.darItems()[2]);
            Assert.AreEqual(123, testPila.darItems()[3]);
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            Assert.AreEqual(true, testPila.esDinamica());
            #endregion
        }
        [TestMethod]
        public void uTestApilarEnTADLleno()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3];
            testItems[0] = 123;
            testItems[1] = 456;
            testItems[2] = 789;
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.apilar(777));
            Assert.AreEqual(1003, testPila.darCapacidad());
            Assert.AreEqual(4, testPila.darLongitud());
            Assert.AreEqual(777, testPila.darItems()[0]);
            Assert.AreEqual(123, testPila.darItems()[1]);
            Assert.AreEqual(456, testPila.darItems()[2]);
            Assert.AreEqual(789, testPila.darItems()[3]);
            for (int i = 4; i <= testPila.darItems().Length - 1; i++)
                Assert.AreEqual(0, testPila.darItems()[i]);
            #endregion
        }
        [TestMethod]
        public void uTestApilarItemEnTADLlenoEnBorde()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[int.MaxValue / 64];
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.apilar(777));
            Assert.AreEqual(int.MaxValue / 64, testPila.darCapacidad());
            Assert.AreEqual(int.MaxValue / 64, testPila.darLongitud());
            Assert.AreEqual(false, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darFactorCrecimiento());
            Assert.AreEqual(int.MaxValue / 64, testPila.darItems().Length);
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        #endregion
        #region Desapilar
        [TestMethod]
        public void uTestDesapilarEnTADVacio()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItem = -1;
            #endregion 
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.desapilar(ref testItem));
            Assert.AreEqual(-1, testItem);
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(0, testPila.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestDesapilarEnTADConItems()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testPila.apilar(123);
            testPila.apilar(456);
            testPila.apilar(789);
            testItem = 0;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.desapilar(ref testItem));
            Assert.AreEqual(789, testItem);
            Assert.AreEqual(2, testPila.darLongitud());
            Assert.AreEqual(1000, testPila.darCapacidad());
            Assert.AreEqual(1000, testPila.darItems().Length);
            Assert.AreEqual(456, testPila.darItems()[0]);
            Assert.AreEqual(123, testPila.darItems()[1]);
            #endregion
        }
        [TestMethod]
        public void uTestDesapilarEnTADLleno()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3];
            testItems[0] = 123;
            testItems[1] = 456;
            testItems[2] = 789;
            testPila.ponerItems(testItems);
            testItem = 0;
            #endregion 
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.desapilar(ref testItem));
            Assert.AreEqual(123, testItem);
            Assert.AreEqual(2, testPila.darLongitud());
            Assert.AreEqual(3, testPila.darCapacidad());
            Assert.AreEqual(456, testPila.darItems()[0]);
            Assert.AreEqual(789, testPila.darItems()[1]);
            Assert.AreEqual(789, testPila.darItems()[2]);
            #endregion
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisarEnTADVacio()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[0];
            testItem = -1;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.revisar(ref testItem));
            Assert.AreEqual(-1, testItem);
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(0, testPila.darCapacidad());
            Assert.AreEqual(0, testPila.darItems().Length);
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestRevisarEnTADConItems()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testPila.apilar(123);
            testPila.apilar(456);
            testPila.apilar(789);
            testItem = -1;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.revisar(ref testItem));
            Assert.AreEqual(789, testItem);
            Assert.AreEqual(3, testPila.darLongitud());
            Assert.AreEqual(1000, testPila.darCapacidad());
            Assert.AreEqual(1000, testPila.darItems().Length);
            Assert.AreEqual(789, testPila.darItems()[0]);
            Assert.AreEqual(456, testPila.darItems()[1]);
            Assert.AreEqual(123, testPila.darItems()[2]);
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            #endregion
        }
        [TestMethod]
        public void uTestRevisarEnTADLleno()
        {
            #region Configurar
            testPila = new clsPilaVector<int>();
            testItems = new int[3];
            testItems[0] = 123;
            testItems[1] = 456;
            testItems[2] = 789;
            testPila.ponerItems(testItems);
            testItem = 0;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.revisar(ref testItem));
            Assert.AreEqual(123, testItem);
            Assert.AreEqual(3, testPila.darLongitud());
            Assert.AreEqual(3, testPila.darCapacidad());
            Assert.AreEqual(3, testPila.darItems().Length);
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            Assert.AreEqual(123, testPila.darItems()[0]);
            Assert.AreEqual(456, testPila.darItems()[1]);
            Assert.AreEqual(789, testPila.darItems()[2]);
            #endregion
        }
        #endregion
        #region Reversar
        [TestMethod]
        public void testReversarConTADSemilleno()
        {
            #region Inicializar
            testPila = new clsPilaVector<int>(5);
            testPila.apilar(1);
            testPila.apilar(2);
            testPila.apilar(3);
            testPila.apilar(4);
            testItems = new int[5] { 1, 2, 3, 4, 0 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.reversar());
            Assert.AreEqual(4, testPila.darLongitud());
            Assert.AreEqual(5, testPila.darCapacidad());
            Assert.AreEqual(5, testPila.darItems().Length);
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void testReversarConTADLleno()
        {
            #region Inicializar
            testPila = new clsPilaVector<int>();
            testItems = new int[4] { 1, 2, 3, 4 };
            testPila.ponerItems(testItems);
            testItems = new int[4] { 4, 3, 2, 1 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.reversar());
            Assert.AreEqual(4, testPila.darLongitud());
            Assert.AreEqual(4, testPila.darCapacidad());
            Assert.AreEqual(4, testPila.darItems().Length);
            Assert.AreEqual(true, testPila.esDinamica());
            Assert.AreEqual(1000, testPila.darFactorCrecimiento());
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void testReversarConTADVacio()
        {
            #region Inicializar
            testItems = new int[4] { 0, 0, 0, 0 };
            testPila = new clsPilaVector<int>(4);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.reversar());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(4, testPila.darCapacidad());
            Assert.AreEqual(4, testPila.darItems().Length);
            Assert.AreEqual(true, testPila.esDinamica());
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        #endregion
        #endregion
        #endregion
    }
}