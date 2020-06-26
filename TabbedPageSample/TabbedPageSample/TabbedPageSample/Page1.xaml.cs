using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageSample
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this,"remove");
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "add");
        }
    }
}