namespace PhonewordTranslator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string translatedNumber;
        public MainPage()
        {
            InitializeComponent();
        }

       

        private void  OnTranslate_Clicked(object sender, EventArgs e)
        {
            string entryNumber = PhoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(entryNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                CallButton.IsEnabled = true;
                CallButton.Text = "Call " + translatedNumber;
            }
            else
            {
                CallButton.IsEnabled = false;
                CallButton.Text = "Call " ;
            }
        }

        private async void OnCall_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(translatedNumber))
                    if (await this.DisplayAlert(
                        "Dial a Number",
                        "Would you like to call " + translatedNumber + " ?",
                        "Yes",
                        "No"
                        ))
                    {
                        //check if phonedialer is available
                        if (PhoneDialer.Default.IsSupported)
                        {
                            PhoneDialer.Default.Open(translatedNumber);
                        }
                        else
                        {
                            await DisplayAlert("Unable to dial", "Phone dialing failed", "ok");
                        }
                        //dial the phonenumber

                    }
                    else
                        await DisplayAlert("Unable to dial", "Phone number is incorrect", "ok");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Unable to dial", ex.Message, "ok");
            }
        }

    }

}
