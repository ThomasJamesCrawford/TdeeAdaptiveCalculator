using TDEE.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDEE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeightGraph : ContentPage
    {
        public WeightGraph()
        {
            InitializeComponent();
            BindingContext = new WeightGraphViewModel();
        }
    }
}