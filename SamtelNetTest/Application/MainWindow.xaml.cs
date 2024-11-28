using SamtelNetTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;
using TestSamtelNET.Domain.Services;
using TestSamtelNET.Infraestructure.Entities;

namespace SamtelNetTest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService _userService;
        private readonly AreaService _areaService;
        private Guid _selectedUserId;
        // Constructor con inyección de dependencias
        public MainWindow(UserService userService, AreaService areaService)
        {
            InitializeComponent();
            _userService = userService;
            _areaService = areaService;
            RefreshCombosAndGrid();
        }

        // Evento de click en el botón
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!validateFieldsRequired())
            {
                MessageBox.Show($"Por favor complete los campos necesarios");
                return;
            }

            if (UsersDataGrid.SelectedItem != null) // Si hay un usuario seleccionado, editamos
            {
                var idUserEdited = _selectedUserId;
                EditUser(idUserEdited, NameTxt.Text, LastNameTxt.Text, AddressTxt.Text, BirthDatePicker.SelectedDate.GetValueOrDefault());
            }
            else // Si no hay selección, creamos un nuevo usuario
                CreateUser(NameTxt.Text, LastNameTxt.Text, AddressTxt.Text, BirthDatePicker.SelectedDate.GetValueOrDefault());

            // Limpiar los campos después de agregar o editar
            ClearFields();
        }

        // Manejar el evento de doble clic en una fila del DataGrid de Usuarios para cargar los datos en los campos
        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedUser = (UserDTO)UsersDataGrid.SelectedItem;
            if (selectedUser.Id == Guid.Empty)
                return;
            if (selectedUser != null)
            {
                // Cargar los datos del usuario seleccionado en los campos de texto
                NameTxt.Text = selectedUser.Name?.Trim();
                LastNameTxt.Text = selectedUser.LastName?.Trim();
                AddressTxt.Text = selectedUser.Address?.Trim();
                BirthDatePicker.SelectedDate = selectedUser?.Birthday;
                _selectedUserId = selectedUser.Id;
            }
        }

        // Manejar el evento de clic para asignar un área a un usuario
        private void AssignAreaButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (UserDTO)UsersComboBox.SelectedItem;
            if (selectedUser.Id == Guid.Empty)
                return;

            var selectedArea = (AreasDTO)AreasComboBox.SelectedItem;
            if (selectedArea.ID == Guid.Empty)
                return;
            if (selectedUser.Id != null && selectedArea.ID != null)
            {
                _areaService.AsignArea(selectedArea.ID, selectedUser.Id);
                MessageBox.Show("Área asignada correctamente");
                RefreshCombosAndGrid();
            }
            else
                MessageBox.Show("Por favor seleccione un usuario y un área");
        }

        private void CreateUser(string name, string lastName, string address, DateTime birthDate)
        {
            var userCreated = _userService.CreateUser(name, lastName, address, birthDate);
            if (userCreated)
            {
                MessageBox.Show($"Usuario creado: {name} {lastName}, {address}, Fecha de nacimiento: {birthDate.ToShortDateString()}");
                RefreshCombosAndGrid();
            }
            else
                MessageBox.Show("No fue posible crear el usuario");
        }

        private bool validateFieldsRequired()
        {
            if (NameTxt.Text.Trim() == string.Empty ||
            LastNameTxt.Text.Trim() == string.Empty ||
            AddressTxt.Text.Trim() == string.Empty ||
            BirthDatePicker.SelectedDate == null)
                return false;
            return true;

        }

        private void EditUser(Guid id, string name, string lastName, string address, DateTime birthDate)
        {
            var userEdit = _userService.EditUser(id, name, lastName, address, birthDate);
            if (userEdit)
            {
                MessageBox.Show($"Usuario editado con éxito: {name} {lastName}");
                RefreshCombosAndGrid();
            }
            else
                MessageBox.Show("No fue posible editar el usuario");
        }

        /* Función que refresca los campos y combos */
        private void RefreshCombosAndGrid()
        {
            List<UserDTO> userList = _userService.GetUsers();
            ObservableCollection<UserDTO> observableUserList = new ObservableCollection<UserDTO>(userList);
            UsersDataGrid.ItemsSource = observableUserList;
            UsersGridRelated.ItemsSource = observableUserList;

            List<AreasDTO> areasList = _areaService.GetArea();
            ObservableCollection<AreasDTO> observableAreaList = new ObservableCollection<AreasDTO>(areasList);
            UsersComboBox.ItemsSource = observableUserList;
            UsersComboBox.DisplayMemberPath = "Name";

            AreasComboBox.ItemsSource = observableAreaList;
            AreasComboBox.DisplayMemberPath = "Name";


        }

        /* Función que limpia los campos */
        private void ClearFields()
        {
            NameTxt.Clear();
            LastNameTxt.Clear();
            AddressTxt.Clear();
            BirthDatePicker.SelectedDate = null;
            _selectedUserId = Guid.Empty;
        }
    }
}
