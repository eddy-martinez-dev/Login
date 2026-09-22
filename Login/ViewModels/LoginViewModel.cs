using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace Login.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string usuario = string.Empty;

        [ObservableProperty]
        private string mensajeError = string.Empty;

        [ObservableProperty]
        private bool errorVisible;

        // Evento que la View escucha para saber cuándo abrir la siguiente ventana y cerrarse
        public event Action? LoginExitoso;

        [RelayCommand]
        private void Login(string password)
        {
            if (ValidarCredenciales(Usuario, password))
            {
                ErrorVisible = false;
                LoginExitoso?.Invoke();
            }
            else
            {
                MensajeError = "Usuario o contraseña incorrectos.";
                ErrorVisible = true;
            }
        }

        private bool ValidarCredenciales(string usuario, string password)
        {
            // TODO: reemplazar por IAuthService.ValidateAsync(usuario, password)
            return usuario == "admin" && password == "1234";
        }
    }
}