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
        try
        {
            ErrorLine.TextColor = Colors.Transparent;

            var responseString = await $"{User.BaseUrl}/api/user/verifyuser/?username={UsernameField.Text}&password={PasswordField.Text}"
                                        .PostAsync()
                                        .ReceiveString();


            User.inventory = JsonConvert.DeserializeObject<List<Ingredient>>(responseString);

            User.UserName = UsernameField.Text;

            Application.Current.MainPage = new AppShell();
        }
        catch(FlurlHttpException ex)
        {
            ErrorLine.TextColor = Colors.Red;
            Debug.WriteLine(ex.Message);
        }

        // Clear user input
        UsernameField.Text = string.Empty;
        PasswordField.Text = string.Empty;
    }
}