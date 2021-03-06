﻿using GifProjectXF.Core;
using GifProjectXF.Demos.UI.ForgotPassword;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GifProjectXF.Demos.UI.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private ICommand forgotPasswordCommand;
        public ICommand ForgotPasswordCommand => forgotPasswordCommand ?? (forgotPasswordCommand = new Command(async () =>
        {
            await Navigation.PushModalAsync(new NavigationPage(ViewContainer.Current.CreatePage<ForgotPasswordViewModel>()));
        }));

        private ICommand loginCommand;
        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () =>
        {
            if (IsBusy)
            {
                return;
            }

            if (string.IsNullOrEmpty(Username))
            {
                ShowAlert(Translate("Missing_Username"), Translate("Gen_Login"));
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                ShowAlert(Translate("Missing_Password"), Translate("Gen_Login"));
                return;
            }

            try
            {
                IsBusy = true;

                await Task.Delay(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                ex.Print();
            }
            finally
            {
                IsBusy = false;
            }
        }));

        private ICommand registerCommand;
        public ICommand RegisterCommand => registerCommand ?? (registerCommand = new Command(async () =>
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                await Navigation.PushAsync(ViewContainer.Current.CreatePage<Register.RegisterViewModel>());
            }
            catch (Exception ex)
            {
                ex.Print();
            }
            finally
            {
                IsBusy = false;
            }
        }));

        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
