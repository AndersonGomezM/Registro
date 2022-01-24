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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegistroG registro = new RegistroG();
            FechaTextBox.Text = Convert.ToString(registro.Fecha);
            var lista = RegistroBLL.GetLista();
            BaseDeDatos.ItemsSource = lista;
        }

        private void GuardarButton_Click(Object guardar, RoutedEventArgs e)
        {
            var rolId = RolIdNombreTextBox.Text;
            var descripcion = DescripcionTextBox.Text;

            RegistroG nuevo = new RegistroG(rolId, descripcion);

            FechaTextBox.Text = Convert.ToString(nuevo.Fecha);

            var confirmar = RegistroBLL.Insertar(nuevo);

            if(confirmar)
            {
                MessageBox.Show("Se guardo con exito.");
                var lista = RegistroBLL.GetLista();
                BaseDeDatos.ItemsSource = lista;
            }
            else
            {
                MessageBox.Show("No se pudo guardar.");
            }
        }

        private void EditarButton_Click(Object editar, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(Object eliminar, RoutedEventArgs e)
        {

        }
    }
}
