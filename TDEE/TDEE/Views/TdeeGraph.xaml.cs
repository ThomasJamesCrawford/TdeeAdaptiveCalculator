using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDEE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TdeeGraph : ContentPage
    {
        public TdeeGraph()
        {
            InitializeComponent();
            BindingContext = new TdeeGraphViewModel();
        }
    }
}