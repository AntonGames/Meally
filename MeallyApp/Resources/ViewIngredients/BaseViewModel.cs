using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Google.Crypto.Tink.Signature;

namespace MeallyApp.Resources.ViewIngredients
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        private string title;

        public bool IsBusy
        {
            get { return isBusy; }
            
            set
            {
                if(isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotBusy));
                }
            }
        }

        public string Title
        {
            get { return title; }

            set 
            { 
                if(title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }


        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
