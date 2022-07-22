using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace STimer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Загрузка из настроек Settings.settings
            if (Properties.Settings.Default.CurrentDynamicAppColor == null || Properties.Settings.Default.CurrentDynamicAppColor == string.Empty)
                Properties.Settings.Default.CurrentDynamicAppColor = new BrushConverter().ConvertToString(Application.Current.Resources["Brush_LightGray"]);

            Application.Current.Resources["DynamicAppColor"] = new BrushConverter().ConvertFromString(Properties.Settings.Default.CurrentDynamicAppColor);
        }

        /// <summary>
        /// Перемещение окна курсором
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
