using System.Windows;
using System.Windows.Controls;


namespace bks_test_task_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement element in MainRoot.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string buttonText = (string)((Button)e.OriginalSource).Content;

            if (buttonText == "AC")
            {
                TextLable.Text = "";
                TextResult.Text = "";
            }
            else if(buttonText == "=")
            {
                TextLable.Text = ReversePolishNotation.ConvertToPolishNotation(TextLable.Text);
                TextResult.Text = PolishNotationCalculator.GetResultCalculate(TextLable.Text);
            }
            else
            {
                TextLable.Text += buttonText;
            }
        }
    }
}
