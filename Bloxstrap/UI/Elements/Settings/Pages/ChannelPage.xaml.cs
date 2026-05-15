using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Bloxstrap.UI.ViewModels.Settings;

namespace Bloxstrap.UI.Elements.Settings.Pages
{
    /// <summary>
    /// Interaction logic for ChannelPage.xaml
    /// </summary>
    public partial class ChannelPage
    {
        private readonly ChannelViewModel _viewModel;

        public ChannelPage()
        {
            InitializeComponent();

            _viewModel = new ChannelViewModel();
            _viewModel.RequestNotificationEvent += (_, message) => ShowChannelNotification(message);
            _viewModel.RequestUpdateAvailableEvent += (_, version) => ShowUpdateAvailable(version);
            _viewModel.RequestHideUpdateAvailableEvent += (_, _) => HideUpdateAvailableCard();

            DataContext = _viewModel;
        }

        private void ShowChannelNotification(string message)
        {
            ChannelSnackbar.Message = message;
            ChannelSnackbar.Visibility = Visibility.Visible;
            ChannelSnackbar.Show();
        }

        private void ShowUpdateAvailable(string version)
        {
            UpdateAvailableMessage.Text = $"Pembaruan tersedia: {version}. Klik untuk membuka halaman rilis.";
            UpdateAvailableCard.Visibility = Visibility.Visible;
            ShowChannelNotification(UpdateAvailableMessage.Text);
        }

        private void HideUpdateAvailableCard()
        {
            UpdateAvailableCard.Visibility = Visibility.Collapsed;
        }

        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
