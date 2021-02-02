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

namespace CalcWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num1 = 0;
        int num2 = 0;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        ////Button number
        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Content.ToString();
            int num = Int32.Parse(str);
            if (op == "")
            {
                num1 = num1 * 10 + num;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + num;
                txtValue.Text = num2.ToString();
            }
        }

        ////Operations
        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    ZeroParam();
                    break;
                case "-":
                    result = num1 - num2;
                    ZeroParam();
                    break;
                case "*":
                    result = num1 * num2;
                    ZeroParam();
                    break;
                case "/":
                    result = num1 / num2;
                    ZeroParam();
                    break;
                case "min":
                    result = Math.Min(num1, num2);
                    ZeroParam();
                    break;
                case "max":
                    result = Math.Max(num1, num2);
                    ZeroParam();
                    break;
                case "avg":
                    result = (num1 + num2) / 2;
                    ZeroParam();
                    break;
                case "x^y":
                    result = Pow(num1, num2);
                    ZeroParam();
                    break;
            }
            txtValue.Text = result.ToString();
            num1 = result;
        }

        private int Pow(int x, int y)
        {
            if (y == 0)
                return 1;

            return Pow(x, y - 1) * x;
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            ZeroParam();
            txtValue.Text = "0";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                num1 = 0;
            else
                num2 = 0;
            txtValue.Text = "0";
        }

        private void btn_backspce_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 = num1 / 10;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 / 10;
                txtValue.Text = num2.ToString();
            }
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 *= -1;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtValue.Text = num2.ToString();
            }
        }

        private void ZeroParam()
        {
            num1 = 0;
            num2 = 0;
            op = "";
        }
    }
}
