using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MeallyApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void LoginButton_OnClicked(object sender, EventArgs e) 
    {
		if(UsernameField.Text == "admin" & PasswordField.Text == "admin")
		{
            Application.Current.MainPage = new AppShell();
        }
    }
}