using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loadingtimer_Tick(object sender, EventArgs e)
        {
            while (Loadingpanel.Width < 2776)
            {
                Loadingpanel.Width += 1;

                if (Loadingpanel.Width >= 2776)
                {
                    LogIn form = new LogIn();
                    this.Hide();
                    form.Show();
                }
            }
        }
    }
}
