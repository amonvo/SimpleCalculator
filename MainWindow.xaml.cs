using System;
using System.Windows;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private string previousNumber = string.Empty;
        private string currentNumber = string.Empty;
        private string operation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                currentNumber += button.Content.ToString();
                Display.Text = currentNumber;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                operation = button.Content.ToString();
                previousNumber = currentNumber;
                currentNumber = string.Empty;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(previousNumber) || string.IsNullOrEmpty(currentNumber))
            {
                MessageBox.Show("Neplatný vstup. Zadejte číslo pro výpočet.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                double num1 = double.Parse(previousNumber);
                double num2 = double.Parse(currentNumber);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            MessageBox.Show("Dělení nulou není povoleno!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        break;
                }

                Display.Text = result.ToString();
                currentNumber = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Chybný formát čísla. Zkuste zadat platné číslo.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = string.Empty;
            previousNumber = string.Empty;
            operation = string.Empty;
            Display.Text = string.Empty;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
                Display.Text = currentNumber;
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                Display.Text = currentNumber;
            }
        }
    }
}
