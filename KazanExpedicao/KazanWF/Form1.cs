using System;
using KazanWF.Helper;
using System.Windows.Forms;
using KazanWF.Models;
using System.Collections.Generic;

namespace KazanWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            var listVenda = new List<VendaModel>();
            listVenda = await VendaHelper.ObterStatusVenda();
            listVenda.ForEach(x =>
            {
                    listBox1.Items.Add($"  Id= {x.VendaId}  -  Status= {x.Status}");
                    //envia notificação para o app!
            });
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
