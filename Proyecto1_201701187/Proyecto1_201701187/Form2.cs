using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201701187
{
    public partial class Form2 : Form
    {
        public Form2(String ruta)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(ruta);
           


        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // this.Size = pictureBox1.Size;
        }
    }
}
