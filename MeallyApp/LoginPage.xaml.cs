using CommunityToolkit.Mvvm.Input;
using Flurl.Http;
using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace MeallyApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void LoginButton_OnClicked(object sender, EventArgs e) 
    {
        var responseString = await "https://localhost:44393/api/user/verifyuser/?username=admin&password=admin"
            .PostUrlEncodedAsync(new { username = "admin", password = "admin" })
            .ReceiveString();

        Debug.WriteLine("----------------------------------------" + responseString);
        // Clear user input
        UsernameField.Text = string.Empty;
        PasswordField.Text = string.Empty;
    }
}