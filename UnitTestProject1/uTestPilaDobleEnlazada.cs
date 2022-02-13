using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTestDemoColecciones
{
    [TestClass]
    public class uTestPilaDobleEnlazada
    {
        #region Atributos de prueba
        private clsPilaDobleEnlazada<int> testPila;
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
            testPila = new clsPilaDobleEnlazada<int>();
            Assert.AreNotEqual(null, testPila.darItems());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(null, testPila.darPrimero());
            Assert.AreEqual(null, testPila.darUltimo());
            #endregion
        }
        #endregion
        #endregion
        #region Accesores
        [TestMethod]
        public void uTestDarItems()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
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
        public void uTestDarLongitud()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(3, testPila.darLongitud());
            #endregion
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItemsConLongitudCero()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[0];
            #endregion
            #region Probar y Comprobar
            Assert.AreNotEqual(false, testPila.ponerItems(testItems));
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(null, testPila.darPrimero());
            Assert.AreEqual(null, testPila.darUltimo());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudNormal()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ponerItems(testItems));
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
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.ponerItems(testItems));
            Assert.AreEqual(int.MaxValue / 16, testPila.darLongitud());
            Assert.AreEqual(int.MaxValue / 16, testPila.darItems().Length);
            CollectionAssert.AreEqual(testItems, testPila.darItems());
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudMasAlladelBorde()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16 + 1];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.ponerItems(testItems));
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(null, testPila.darItems());
            #endregion
        }
        #endregion
        #endregion
        #region Consultores
        #endregion
        #region CRUDS
        #region apilar
        [TestMethod]
        public void uTestapilarItemEnTADVacio()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.apilar(123));
            Assert.AreEqual(123, testPila.darItems()[0]);
            Assert.AreEqual(1, testPila.darLongitud());
            #endregion
        }
        [TestMethod]
        public void uTestapilarItemEnTADConItems()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 789;
            testItems[1] = 456;
            testItems[2] = 123;
            testPila.ponerItems(testItems);

            testItems = new int[4];
            testItems[0] = 777;
            testItems[1] = 789;
            testItems[2] = 456;
            testItems[3] = 123;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.apilar(777));
            Assert.AreEqual(4, testPila.darLongitud());
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestapilarItemEnTADLlenoEnBorde()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16];
            testPila.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.apilar(777));
            Assert.AreEqual(int.MaxValue / 16, testPila.darLongitud());
            Assert.AreEqual(int.MaxValue / 16, testPila.darItems().Length);
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        #endregion
        #region Desapilar
        [TestMethod]
        public void uTestDesapilarEnTADVacio()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItem = -1;
            #endregion 
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.desapilar(ref testItem));
            Assert.AreEqual(-1, testItem);
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(null, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestDesapilarEnTADConItems()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
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
            Assert.AreEqual(456, testPila.darItems()[0]);
            Assert.AreEqual(789, testPila.darItems()[1]);
            #endregion
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisarEnTADVacio()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[0];
            testItem = -1;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.revisar(ref testItem));
            Assert.AreEqual(-1, testItem);
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(null, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestRevisarEnTADConItems()
        {
            #region Configurar
            testPila = new clsPilaDobleEnlazada<int>();
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
            Assert.AreEqual(1000, testPila.darItems().Length);
            Assert.AreEqual(123, testPila.darItems()[0]);
            Assert.AreEqual(456, testPila.darItems()[1]);
            Assert.AreEqual(789, testPila.darItems()[2]);
            #endregion
        }
        #endregion
        #region Reversar
        [TestMethod]
        public void testReversarEnTADConItems()
        {
            #region Inicializar
            testPila = new clsPilaDobleEnlazada<int>();
            testItems = new int[4] { 1, 2, 3, 4 };
            testPila.ponerItems(testItems);
            testItems = new int[4] { 4, 3, 2, 1 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testPila.reversar());
            Assert.AreEqual(4, testPila.darLongitud());
            Assert.AreEqual(4, testPila.darItems().Length);
            CollectionAssert.AreEqual(testItems, testPila.darItems());
            #endregion
        }
        [TestMethod]
        public void testReversarConTADVacio()
        {
            #region Inicializar
            testPila = new clsPilaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testPila.reversar());
            Assert.AreEqual(0, testPila.darLongitud());
            Assert.AreEqual(null, testPila.darItems());
            #endregion
        }
        #endregion
        #endregion
        #endregion
    }
}