using Microsoft.Maui.Controls;

namespace ScrollViewMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnHideKeyboardButtonClicked(object sender, EventArgs e)
        {
#if ANDROID
        var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
        if (activity?.CurrentFocus != null)
        {
            var imm = (Android.Views.InputMethods.InputMethodManager?)activity.GetSystemService(Android.Content.Context.InputMethodService);
            imm?.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);
            activity.CurrentFocus.ClearFocus();
        }
#endif
            await PageScrollView.ScrollToAsync(ContentPanel, ScrollToPosition.MakeVisible, true);
        }

    }
}
