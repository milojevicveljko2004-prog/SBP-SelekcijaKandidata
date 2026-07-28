using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using App.Entiteti;
using App.Forme;

namespace App
{
    public partial class PocetnaForma : Form
    {
        public PocetnaForma()
        {
            InitializeComponent();
        }

        private void btnOglasi_Click(object sender, EventArgs e)
        {
            OglasiForm form = new OglasiForm();
            form.ShowDialog();
        }

        private void btnCVPrijave_Click(object sender, EventArgs e)
        {
            SveCVPrijaveForm form = new SveCVPrijaveForm();
            form.ShowDialog();
        }
    }
}
