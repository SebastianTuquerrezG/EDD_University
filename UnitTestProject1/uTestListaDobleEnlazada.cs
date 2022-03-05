using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTestDemoColecciones
{
    [TestClass]
    public class uTestListaDobleEnlazada
    {
        #region Atributos de prueba
        private clsListaDobleEnlazada<int> testTAD;
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
            testTAD = new clsListaDobleEnlazada<int>();
            Assert.AreEqual(null, testTAD.darItems());
            Assert.AreEqual(0, testTAD.darLongitud());
            Assert.AreEqual(null, testTAD.darPrimero());
            Assert.AreEqual(null, testTAD.darUltimo());
            #endregion
        }
        #endregion
        #endregion
        #region Accesores
        [TestMethod]
        public void uTestDarItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreNotEqual(null, testTAD.darItems());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(3, testTAD.darLongitud());
            #endregion
        }
        #endregion
        #region Mutadores
        [TestMethod]
        public void uTestPonerItemsConLongitudCero()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[0];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.ponerItems(testItems));
            Assert.AreEqual(0, testTAD.darLongitud());
            Assert.AreEqual(null, testTAD.darPrimero());
            Assert.AreEqual(null, testTAD.darUltimo());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudNormal()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.ponerItems(testItems));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(1, testTAD.darItems()[0]);
            Assert.AreEqual(2, testTAD.darItems()[1]);
            Assert.AreEqual(3, testTAD.darItems()[2]);
            Assert.AreEqual(3, testTAD.darItems().Length);
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudEnBorde()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.ponerItems(testItems));
            Assert.AreEqual(int.MaxValue / 16, testTAD.darLongitud());
            Assert.AreEqual(int.MaxValue / 16, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestPonerItemsConLongitudMasAlladelBorde()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16 + 1];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.ponerItems(testItems));
            Assert.AreEqual(0, testTAD.darLongitud());
            Assert.AreEqual(null, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Consultores
        #endregion
        #region CRUDS
        #region agregar
        [TestMethod]
        public void uTestAgregarItemEnListaVacia()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[1];
            testItems[0] = 123;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.agregar(123));
            Assert.AreEqual(123, testTAD.darItems()[0]);
            Assert.AreEqual(1, testTAD.darLongitud());
            Assert.AreEqual(1, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestAgregarItemEnListaTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 789;
            testItems[1] = 456;
            testItems[2] = 123;
            testTAD.ponerItems(testItems);

            testItems = new int[4];
            testItems[0] = 789;
            testItems[1] = 456;
            testItems[2] = 123;
            testItems[3] = 777;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.agregar(777));
            Assert.AreEqual(4, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestAgregarItemEnListaEnBorde()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[int.MaxValue / 16];
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.agregar(777));
            Assert.AreEqual(int.MaxValue / 16, testTAD.darLongitud());
            Assert.AreEqual(int.MaxValue / 16, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Insertar Item en Indice
        #region Indice Negativo
        [TestMethod]
        public void uTestInsertarItemConIndiceNegativoEnTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.insertarEn(-1, 4));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestInsertarItemConIndiceNegativoEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.insertarEn(-1, 4));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Cero
        [TestMethod]
        public void uTestInsertarItemEnIndiceCeroConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[1];
            testItems[0] = 4;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.insertarEn(0, 4));
            Assert.AreEqual(1, testTAD.darLongitud());
            Assert.AreEqual(1, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestInsertarItemEnIndiceCeroEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);

            testItems = new int[4];
            testItems[0] = 4;
            testItems[1] = 1;
            testItems[2] = 2;
            testItems[3] = 3;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.insertarEn(0, 4));
            Assert.AreEqual(4, testTAD.darLongitud());
            Assert.AreEqual(4, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Mayor a Cero Menor que Longitud
        [TestMethod]
        public void uTestInsertarItemEnIndiceConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.insertarEn(2, 4));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestInsertarItemEnIndiceEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);

            testItems = new int[4];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 4;
            testItems[3] = 3;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.insertarEn(2, 4));
            Assert.AreEqual(4, testTAD.darLongitud());
            Assert.AreEqual(4, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Igual a Longitud
        [TestMethod]
        public void uTestInsertarItemEnLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[1];
            testItems[0] = 4;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.insertarEn(0, 4));
            Assert.AreEqual(1, testTAD.darLongitud());
            Assert.AreEqual(1, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestInsertarItemEnLongitudEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);

            testItems = new int[4];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testItems[3] = 4;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.insertarEn(3, 4));
            Assert.AreEqual(4, testTAD.darLongitud());
            Assert.AreEqual(4, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice mas Alla de Longitud
        [TestMethod]
        public void uTestInsertarItemMasAllaDeLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.insertarEn(4, 4));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestInsertarItemMasAllaDeLongitudEnTADConItemsFlexible()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.insertarEn(4, 4));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #endregion
        #region Extraer Item en Indice
        #region Indice Negativo
        [TestMethod]
        public void uTestExtraerItemConIndiceNegativoConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(-1, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestExtraerItemConIndiceNegativoEnTADConItems()
        {
            //Poner un metodo mutador para capacidad en vectoriales bool ponerCapacidad(int prmValor)
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(-1, ref testItem));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Cero
        [TestMethod]
        public void uTestExtraerItemEnIndiceCeroConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(0, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestExtraerItemEnIndiceCeroEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            testItems = new int[2] { 2, 3 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.extraerEn(0, ref testItem));
            Assert.AreEqual(1, testItem);
            Assert.AreEqual(2, testTAD.darLongitud());
            Assert.AreEqual(2, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Mayor a Cero Menor que Longitud
        [TestMethod]
        public void uTestExtraerItemEnIndiceConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(2, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestExtraerItemEnIndiceEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            testItems = new int[2] { 1, 2 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.extraerEn(2, ref testItem));
            Assert.AreEqual(3, testItem);
            Assert.AreEqual(2, testTAD.darLongitud());
            Assert.AreEqual(2, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Igual a Longitud
        [TestMethod]
        public void uTestExtraerItemEnLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(0, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestExtraerItemEnLongitudEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(3, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice mas Alla de Longitud
        [TestMethod]
        public void uTestExtraerItemMasAllaDeLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(4, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestExtraerItemMasAllaDeLongitudEnTADConItemsFlexible()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.extraerEn(4, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #endregion
        #region Modificar Item en Indice
        #region Indice Negativo
        [TestMethod]
        public void uTestModificarItemConIndiceNegativoConTADVacio()
        {
            #region Configurar
            //ToDo: metodos para configuar TAD vacio, con items, lleno para todas las implementaciones
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(-1, 777));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestModificarItemConIndiceNegativoEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(-1, 777));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Cero
        [TestMethod]
        public void uTestModificarItemEnIndiceCeroConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(0, 777));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestmodificarItemEnIndiceCeroEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            testItems[0] = 777;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.modificarEn(0, 777));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Mayor a Cero Menor que Longitud
        [TestMethod]
        public void uTestModificarItemEnIndiceConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(2, 777));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestmodificarItemEnIndiceEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            testItems[2] = 777;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.modificarEn(2,777));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Igual a Longitud
        [TestMethod]
        public void uTestModificarItemEnLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(0, 777));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestmodificarItemEnLongitudEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(3, 777));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice mas Alla de Longitud
        [TestMethod]
        public void uTestModificarItemMasAllaDeLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(4, 777));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestModificarItemMasAllaDeLongitudEnTADConItemsFlexible()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.modificarEn(4, 777));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #endregion
        #region Recuperar Item en Indice
        #region Indice Negativo
        [TestMethod]
        public void uTestRecuperarItemConIndiceNegativoConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(-1, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestRecuperarItemConIndiceNegativoEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3];
            testItems[0] = 1;
            testItems[1] = 2;
            testItems[2] = 3;
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(-1, ref testItem));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Cero
        [TestMethod]
        public void uTestRecuperarItemEnIndiceCeroConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(0, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestrecuperarItemEnIndiceCeroEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.recuperarEn(0, ref testItem));
            Assert.AreEqual(1, testItem);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Mayor a Cero Menor que Longitud
        [TestMethod]
        public void uTestrecuperarItemEnIndiceConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(2, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestrecuperarItemEnIndiceEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.recuperarEn(2, ref testItem));
            Assert.AreEqual(3, testItem);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice Igual a Longitud
        [TestMethod]
        public void uTestRecuperarItemEnLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(0, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestRecuperarItemEnLongitudEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(3, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Indice mas Alla de Longitud
        [TestMethod]
        public void uTestRecuperarItemMasAllaDeLongitudConTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(4, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestRecuperarItemMasAllaDeLongitudEnTADConItemsFlexible()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.recuperarEn(4, ref testItem));
            Assert.AreEqual(default(int), testItem);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #endregion
        #region Contiene Item
        [TestMethod]
        public void uTestContieneItemEnTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.contieneA(0));
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestContieneItemEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.contieneA(3));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestNOContieneItemConIndiceNegativoEnTADItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.contieneA(777));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Encontrar Item
        [TestMethod]
        public void uTestEncontrarItemEnTADVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.encontrarA(0) < 0);
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestEncontrarItemEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(2, testTAD.encontrarA(3));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestEncontrarItemEnTADConItemsVariasOcurrencias()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(1, testTAD.encontrarA(2));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void uTestEncontrarItemEnTADConItemsNingunaOcurrencia()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            testTAD.ponerItems(testItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.encontrarA(777) < 0);
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #region Reversar
        [TestMethod]
        public void testReversarEnTADConItems()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = new int[4] { 1, 2, 3, 4 };
            testTAD.ponerItems(testItems);
            testItems = new int[4] { 4, 3, 2, 1 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.reversar());
            Assert.AreEqual(4, testTAD.darLongitud());
            Assert.AreEqual(4, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        [TestMethod]
        public void testReversarEnTADConVacio()
        {
            #region Configurar
            testTAD = new clsListaDobleEnlazada<int>();
            testItems = null;
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.reversar());
            Assert.AreEqual(0, testTAD.darLongitud());
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }
        #endregion
        #endregion
        #endregion
    }
}