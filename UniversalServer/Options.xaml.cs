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
using System.Windows.Shapes;
using UniversalServer.Model;

namespace UniversalServer
{
    /// <summary>
    /// Interaktionslogik für Options.xaml
    /// </summary>
    public partial class Options : Window
    {

        int runtime = 10;
        bool runtime_unlimited = true;


        public Options()
        {
            InitializeComponent();
        }


        private void Btn_save_mode_Click(object sender, RoutedEventArgs e)
        {
            switch (runtime_unlimited)
            {
                case true:
                    btn_save_mode.Content = "Mode: Upload";
                    runtime_unlimited = false;
                    break;
                case false:
                    btn_save_mode.Content = "Mode: Idle";
                    runtime_unlimited = true;
                    break;
            }
        }

        public bool Mode_Stop()
        {
            bool mode = runtime_unlimited;
            return mode;
        }

        private void Btn_show_content_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_increase_runtime_Click(object sender, RoutedEventArgs e)
        {
            runtime += 1;
            string converted_runtime = Convert.ToString(runtime);
            lbl_run_value.Content = converted_runtime;
        }

        private void Btn_decreade_runtime_Click(object sender, RoutedEventArgs e)
        {
            runtime -= 1;
            string converted_runtime = Convert.ToString(runtime);
            lbl_run_value.Content = converted_runtime;
        }

        private void Btn_save_setting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
