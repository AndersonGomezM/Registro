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
using DAL;
using Entidades;

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
            var rolId = int.Parse(RolIdTextBox.Text);
            var descripcion = DescripcionTextBox.Text;

            RegistroG nuevo = new RegistroG(rolId, descripcion);

            FechaTextBox.Text = Convert.ToString(nuevo.Fecha);

            var confirmar = RegistroBLL.Insertar(nuevo);

            if (!confirmar)
                MessageBox.Show("No se pudo guardar.");
            else
            {
                MessageBox.Show("Se guardo con exito.");
                var lista = RegistroBLL.GetLista();
                BaseDeDatos.ItemsSource = lista;
            }
        }

        private void EditarButton_Click(Object editar, RoutedEventArgs e)
        {
            if (RegistroBLL.Existe(int.Parse(RolIdTextBox.Text)))
            {
                var rolId = int.Parse(RolIdTextBox.Text);
                var descripcion = DescripcionTextBox.Text;
                RegistroG registro = new RegistroG(rolId, descripcion);
                RegistroBLL.Editar(registro);
                var lista = RegistroBLL.GetLista();
                BaseDeDatos.ItemsSource = lista;
            }
            else
                MessageBox.Show("El id de la entrada no existe.");
        }

        private void EliminarButton_Click(Object eliminar, RoutedEventArgs e)
        {
            if (RegistroBLL.Eliminar(int.Parse(RolIdTextBox.Text)))
            {
                MessageBox.Show("Registro eliminado!", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                var lista = RegistroBLL.GetLista();
                BaseDeDatos.ItemsSource = lista;
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
