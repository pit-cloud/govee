using System.Linq;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Login(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(apiKeyEntry.Text))
            {
                if (PowerIT.Govee.Account.IsLoggedIn == false)
                {
                    try
                    {
                        await PowerIT.Govee.Account.LoginAsync(apiKeyEntry.Text);

                        var devices = await PowerIT.Govee.Devices.ListAsync();

                        devicePicker.ItemsSource = devices.Data.Devices.ToList();
                        devicePicker.ItemDisplayBinding = new Binding("Name");

                        devicePicker.IsEnabled = true;
                        onButton.IsEnabled = true;
                        offButton.IsEnabled = true;

                        successLabel.Text = "Login successful.";
                    }
                    catch
                    {
                        errorLabel.Text = "Login failed.";
                    }
                }
                else
                {
                    successLabel.Text = "Already logged in.";
                }
            }
            else
            {
                errorLabel.Text = "No API key provided.";
            }

        }

        async void LightOn(System.Object sender, System.EventArgs e)
        {
            if (devicePicker.SelectedIndex != -1)
            {
                try
                {
                    var device = (PowerIT.Govee.Models.List.Device)devicePicker.SelectedItem;

                    var result = await PowerIT.Govee.Device.OnAsync(device.Id, device.Model);

                    if (result.Status.ToLower() == "ok")
                    {
                        successLabel.Text = device.Name + " turned on successfully.";
                    }
                    else
                    {
                        errorLabel.Text = device.Name + "not turned on successfully.";
                    }
                }
                catch
                {
                    errorLabel.Text = "There has been an error turning on the light.";
                }
            }
            else
            {
                errorLabel.Text = "Need to select a device first.";
            }
        }

        async void LightOff(System.Object sender, System.EventArgs e)
        {
            if (devicePicker.SelectedIndex != -1)
            {
                try
                {
                    var device = (PowerIT.Govee.Models.List.Device)devicePicker.SelectedItem;

                    var result = await PowerIT.Govee.Device.OffAsync(device.Id, device.Model);

                    if (result.Status.ToLower() == "ok")
                    {
                        successLabel.Text = device.Name + " turned off successfully.";
                    }
                    else
                    {
                        errorLabel.Text = device.Name + "not turned off successfully.";
                    }
                }
                catch
                {
                    errorLabel.Text = "There has been an error turning off the light.";
                }
            }
            else
            {
                errorLabel.Text = "Need to select a device first.";
            }
        }

        async void ShowMessage(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                var label = (Xamarin.Forms.Label)sender;

                if (label.ClassId == "errorLabel" && errorLabel.Text != "")
                {
                    errorFrame.IsVisible = true;

                    await errorFrame.FadeTo(100, 0);
                    await errorFrame.FadeTo(0, 3000);

                    errorFrame.IsVisible = false;
                    errorLabel.Text = "";
                }
                else if (label.ClassId == "successLabel" && successLabel.Text != "")
                {
                    successFrame.IsVisible = true;

                    await successFrame.FadeTo(100, 0);
                    await successFrame.FadeTo(0, 3000);

                    successFrame.IsVisible = false;
                    successLabel.Text = "";
                }
            }
        }
    }
}

