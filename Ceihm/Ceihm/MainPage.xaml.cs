using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Ceihm
{
	public partial class MainPage : ContentPage
	{
        double StepValue = 1.0;

        public MainPage()
		{
			InitializeComponent();

        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            ((Slider)(sender)).Value = newStep * StepValue;

        }
        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            
            frame1.BackgroundColor = Color.White;
            frame2.BackgroundColor = Color.White;
            frame3.BackgroundColor = Color.White;
            if (sender == img1)
            {
                frame1.BackgroundColor = Color.Black;

            }
            if (sender == img2)
            {
                frame2.BackgroundColor = Color.Black;

            }
            if (sender == img3)
            {
                frame3.BackgroundColor = Color.Black;

            }
            // watch the monkey go from color to black&white!

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Random r = new Random();
            
            using (IProgressDialog progress = UserDialogs.Instance.Progress("Envoi de l'incident", null, null, true, MaskType.Black))
            {
                for (int i = 0; i < 100; i++)
                {
                    progress.PercentComplete = i;
                    await Task.Delay(r.Next(30, 50));
                }
            }

            //using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            //{
            //    await Task.Delay(5000);
            //}
            var error = r.Next(0, 2);
            if (error == 0)
            {
                UserDialogs.Instance.HideLoading();

                UserDialogs.Instance.ShowError("Erreur dans l'envoi de l'incident", 3000); //Use ShowImage instead
            }
            else
            {
                UserDialogs.Instance.HideLoading();

                UserDialogs.Instance.ShowSuccess("Incident envoyé !", 3000); //Use ShowImage instead

            }
          
        }
    }
}
