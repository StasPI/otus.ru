using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CalcWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        ////Button number
        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();
            if (txtValue.Text == "0")
                txtValue.Text = num;
            else
                txtValue.Text += num;

            if (op == "")
                num1 = Double.Parse(txtValue.Text);
            else
                num2 = Double.Parse(txtValue.Text);
        }

        ////Operations
        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
            txtValue.Text = "0";
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
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
                    result = Pow(num1,(int) num2);
                    ZeroParam();
                    break;
            }
            txtValue.Text = result.ToString();
            num1 = result;
        }

        private double Pow(double x, int y)
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
            txtValue.Text = DropLastChar(txtValue.Text);
            if (op == "")
                num1 = double.Parse(txtValue.Text);
            else
                num2 = double.Parse(txtValue.Text);
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
                text = "0";
            else
            {
                text = text.Remove(text.Length -1, 1);
                if (text[text.Length - 1] == '.')
                    text = text.Remove(text.Length - 1, 1);
            }
            return text;
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

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                SetDot(num1);
            else
                SetDot(num2);
        }

        private void SetDot(double num)
        {
            if (!txtValue.Text.Contains('.'))
                txtValue.Text += ".";
            return;
        }
    }
}
