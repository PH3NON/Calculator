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

namespace CALC
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static List<string> li = new List<string>();
        public static char op = '0';
        static string cn = "";

        private void button_Click(object sender, RoutedEventArgs e) // pi
        {
            li.Add(cn);
            cn = "";
            cn = Math.PI.ToString();
            tb.Text = cn;
        }

        private void wLast()
        {
            last.Text = li[0];
            if (op != '0')
            {
                last.Text += $" {op}";
            }
        }

        static bool isDouble(string s)
        {
            try
            {
                double.Parse(s);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static string result()
        {
            double a = double.Parse(li[0]),
                b = 0,
                result = 0;
            try
            {
                b = double.Parse(li.Last());
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            if (op == '+')
            {
                result = a + b;
            }
            else if (op == '-')
            {
                result = a - b;
            }
            else if (op == '×')
            {
                result = a * b;
            }
            else if (op == '÷')
            {
                result = a / b;
            }
            li.Clear();
            li.Add(result.ToString());
            li.Add("");
            return result.ToString();
        }

        static void error(string msg)
        {

        }

        private void button_eq_Click(object sender, RoutedEventArgs e)
        {
            li.Add(cn);
            cn = "";
            tb.Text = result();
            last.Text = "";
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            cn += b.Content;
            tb.Text = cn;
        }

        private void button_op_Click(object sender, RoutedEventArgs e) // Operator click
        {
            Button b = (Button)sender;
            li.Add(cn);
            cn = "";
            op = char.Parse((string)b.Content);
            wLast();
        }

        private void button_c_Click(object sender, RoutedEventArgs e)
        {
            li.Clear();
            tb.Text = "";
            cn = "";
            last.Text = "";
        }

        private void button_bs_Click(object sender, RoutedEventArgs e) // Backspace
        {
            //cn.Remove(cn.LastOrDefault());
        }

        private void button_point_Click(object sender, RoutedEventArgs e)
        {
            if (!cn.Contains(","))
            {
                cn += ",";
            }
            tb.Text = cn;
        }
    }
}
