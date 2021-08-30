using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class FLoading : Form
    {
        public FLoading()
        {
            InitializeComponent();
        }

        private void FLoading_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ProgressBar.Value == 100)
            {
                timer.Stop();
            }
            else
            {
                ProgressBar.Increment(2);
                label_val.Text = (Convert.ToInt32(label_val.Text) + 2).ToString();
            }
        }
    }
}