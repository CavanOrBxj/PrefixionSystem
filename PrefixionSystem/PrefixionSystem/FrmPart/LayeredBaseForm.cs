using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace PrefixionSystem.FrmPart
{
    public partial class LayeredBaseForm : LayeredForm
    {
        public LayeredBaseForm()
        {
            InitializeComponent();
            this.BackgroundRender = new ShadowBackgroundRender();
        }

        private void LayeredBaseForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
