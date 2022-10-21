using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeallyApp.Resources.ViewIngredients
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy; 
        private string title;

        // Property usage in struct and class;
        public bool IsBusy
        {
            get { return isBusy; }
            
            set
            {
                if(isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Title
        {
            get { return title; }

            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
