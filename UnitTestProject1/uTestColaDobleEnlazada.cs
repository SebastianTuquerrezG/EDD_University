using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTestDemoColecciones
{
    [TestClass]
    public class uTestColaDobleEnlazada
    {
        #region Atributos de prueba
        private clsColaDobleEnlazada<int> testCola;
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
            testCola = new clsColaDobleEnlazada<int>();
            Assert.AreEqual(null, testCola.darItems());
            Assert.AreEqual(0, testCola.darLongitud());
            Assert.AreEqual(null, testCola.darPrimero());
            Assert.AreEqual(null, testCola.darUltimo());
            #endregion
        }
        #endregion
        #endregion
        #region Accesores
        [TestMethod]
        public void uTestDarItems()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testCola.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreNotEqual(null, testCola.darItems());
            Assert.AreEqual(3, testCola.darItems().Length);
            Assert.AreEqual(1, testCola.darItems()[0]);
            Assert.AreEqual(2, testCola.darItems()[1]);
            Assert.AreEqual(3, testCola.darItems()[2]);
            #endregion
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testCola.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(3, testCola.darLongitud());
            #endregion
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItemsConLongitudCero()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[0];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testCola.ponerItems(testItems));
            Assert.AreEqual(0, testCola.darLongitud());
            Assert.AreEqual(null, testCola.darPrimero());
            Assert.AreEqual(null, testCola.darUltimo());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudNormal()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.ponerItems(testItems));
            Assert.AreEqual(3, testCola.darLongitud());
            Assert.AreEqual(1, testCola.darItems()[0]);
            Assert.AreEqual(2, testCola.darItems()[1]);
            Assert.AreEqual(3, testCola.darItems()[2]);
            Assert.AreEqual(3, testCola.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudEnBorde()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.ponerItems(testItems));
            Assert.AreEqual(int.MaxValue / 16, testCola.darLongitud());
            Assert.AreEqual(int.MaxValue / 16, testCola.darItems().Length);
            CollectionAssert.AreEqual(testItems, testCola.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudMasAlladelBorde()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16 + 1];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testCola.ponerItems(testItems));
            Assert.AreEqual(0, testCola.darLongitud());
            Assert.AreEqual(null, testCola.darItems());
            #endregion
        }
        #endregion
        #region Consultores
        #endregion
        #region CRUDS
        #region Encolar
        [TestMethod]
        public void uTestEncolarItemEnTADVacio()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.encolar(123));
            Assert.AreEqual(123, testCola.darItems()[0]);
            Assert.AreEqual(1, testCola.darLongitud());
            #endregion
        }
        [TestMethod]
        public void uTestEncolarItemEnTADConItems()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 789;
            testItems[1] = 456;
            testItems[2] = 123;
            testCola.ponerItems(testItems);

            testItems = new int[4];
            testItems[0] = 789;
            testItems[1] = 456;
            testItems[2] = 123;
            testItems[3] = 777;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.encolar(777));
            Assert.AreEqual(4, testCola.darLongitud());
            CollectionAssert.AreEqual(testItems, testCola.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestEncolarItemEnTADLlenoEnBorde()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16];
            testCola.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testCola.encolar(777));
            Assert.AreEqual(int.MaxValue / 16, testCola.darLongitud());
            Assert.AreEqual(int.MaxValue / 16, testCola.darItems().Length);
            CollectionAssert.AreEqual(testItems, testCola.darItems());
            #endregion
        }
        #endregion
        #region Desencolar
        [TestMethod]
        public void uTestDesencolarEnTADVacio()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItem = -1;
            #endregion 
            #region Probar y Comprobar
            Assert.AreEqual(false, testCola.desencolar(ref testItem));
            Assert.AreEqual(-1, testItem);
            Assert.AreEqual(0, testCola.darLongitud());
            Assert.AreEqual(null, testCola.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestDesencolarEnTADConItems()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 123;
            testItems[1] = 456;
            testItems[2] = 789;
            testCola.ponerItems(testItems);

            testItems = new int[2];
            testItems[0] = 456;
            testItems[1] = 789;
            testItem = 0;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.desencolar(ref testItem));
            Assert.AreEqual(123, testItem);
            Assert.AreEqual(2, testCola.darLongitud());
            CollectionAssert.AreEqual(testItems, testCola.darItems());
            #endregion
        }
        #endregion
        #region Revisar
        [TestMethod]
        public void uTestRevisarEnTADVacio()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[0];
            testItem = -1;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testCola.revisar(ref testItem));
            Assert.AreEqual(-1, testItem);
            Assert.AreEqual(0, testCola.darLongitud());
            Assert.AreEqual(null, testCola.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestRevisarEnTADConItems()
        {
            #region Configurar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 123;
            testItems[1] = 456;
            testItems[2] = 789;
            testCola.ponerItems(testItems);
            testItem = 0;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.revisar(ref testItem));
            Assert.AreEqual(123, testItem);
            Assert.AreEqual(3, testCola.darLongitud());
            Assert.AreEqual(3, testCola.darItems());
            CollectionAssert.AreEqual(testItems, testCola.darItems());
            #endregion
        }
        #endregion
        #region Reversar
        [TestMethod]
        public void testReversarEnTADConItems()
        {
            #region Inicializar
            testCola = new clsColaDobleEnlazada<int>();
            testItems = new int[4] { 1, 2, 3, 4 };
            testCola.ponerItems(testItems);
            testItems = new int[4] { 4, 3, 2, 1 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testCola.reversar());
            Assert.AreEqual(4, testCola.darLongitud());
            Assert.AreEqual(4, testCola.darItems().Length);
            CollectionAssert.AreEqual(testItems, testCola.darItems());
            #endregion
        }
        [TestMethod]
        public void testReversarConTADVacio()
        {
            #region Inicializar
            testCola = new clsColaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testCola.reversar());
            Assert.AreEqual(0, testCola.darLongitud());
            Assert.AreEqual(null, testCola.darItems().Length);
            #endregion
        }
        #endregion
        #endregion
        #endregion
    }
}