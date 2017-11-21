using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            List<string> lista = new List<string>();

            if (archivos.Leer(out lista)) {

                foreach (string i in lista) {

                    if (i != "") {

                        // Si no es una linea vacia se mete al listbox
                        lstHistorial.Items.Add(i);

                    }

                }

            } else {

                MessageBox.Show("No se pudo abrir el historial. Hubo un error con el archivo o el mismo aún no existe. Haga alguna búsqueda y vuelva a intentar.");
                this.Close();

            }

        }

    } 

}
