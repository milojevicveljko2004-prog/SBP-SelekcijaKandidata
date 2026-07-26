using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forme
{
    public partial class DodajIntervju_zaCV_Form : Form
    {
        public DodajIntervju_zaCV_Form()
        {
            InitializeComponent();

            //omogucava da se u vreme unese tacan sat
            dateVreme.Format = DateTimePickerFormat.Custom;
            dateVreme.CustomFormat = "dd.MM.yyyy. HH:mm";
        }
    }
}
