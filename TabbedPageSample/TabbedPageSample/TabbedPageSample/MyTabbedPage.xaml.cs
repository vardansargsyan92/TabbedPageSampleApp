using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage
    {
        private readonly MasterDetailPage _tab1;
        private readonly ContentPage _tab2;
        private readonly ContentPage _tab3;
        private readonly ContentPage _tab4;

        public MyTabbedPage()
        {
            InitializeComponent();

            _tab1 = new MyMasterDetailPage
                    {
                        Title = "Tab 1"
                    };
            _tab2 = new Page1
                    {
                        Title = "Tab 2"
                    };

            _tab3 = new Page2
                    {
                        Title = "Tab 3"
                    };
            _tab4 = new Page3
                    {
                        Title = "Tab 4"
                    };

            Children.Add(_tab1);
            Children.Add(_tab2);
            Children.Add(_tab3);
            Children.Add(_tab4);
            MessagingCenter.Subscribe<Page1>(this, "remove", sender => RemoveMiddleTab());
            MessagingCenter.Subscribe<Page1>(this, "add", sender => AddTabAtMiddle());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Page1>(this, "remove");
            MessagingCenter.Unsubscribe<Page1>(this, "add");
        }

        private void RemoveMiddleTab()
        {
            if(Children.Contains(_tab3))
            {
                Children.Remove(_tab3);
            }
        }

        private void AddTabAtMiddle()
        {
            if(!Children.Contains(_tab3))
            {
                Children.Insert(2, _tab3);
            }
        }
    }
}