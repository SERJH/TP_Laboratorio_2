using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        private event ProgresoDescargaCallback Progress;
        private event FinDescargaCallback Finish;
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso) {

            if (statusStrip.InvokeRequired) {

                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });

            } else {

                tspbProgreso.Value = progreso;

            }

        }

        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html) {

            if (rtxtHtmlCode.InvokeRequired) {

                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });

            } else {

                rtxtHtmlCode.Text = html;

            }

        }

        private void btnIr_Click(object sender, EventArgs e) {

            // Compruebo que a la cadena no le falte el http://

            if (!this.txtUrl.Text.StartsWith("http://")) {

                this.txtUrl.Text = "http://" + this.txtUrl.Text;

            }

            // Declaro e inicializo el objeto Descargador para trabajar con el

            Descargador downloader = new Descargador(new Uri(this.txtUrl.Text));

            this.Progress += new ProgresoDescargaCallback(ProgresoDescarga);
            this.Finish += new FinDescargaCallback(FinDescarga);

            Thread hilo = new Thread(new ParameterizedThreadStart(ThreadProgreso));
            hilo.Start(downloader);
            
            // Guardo el historial en el archivo
                
            archivos.Guardar(this.txtUrl.Text);

        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e) {

            // Muestro el form del historial

            frmHistorial history = new frmHistorial();
            history.ShowDialog();

        }

        private void ThreadProgreso(object downloader) {

            // Inicio la descarga

            ((Descargador)downloader).IniciarDescarga();

            while (((Descargador)downloader).HTML == "") {

                // Mientras no se haya completado la descarga lanzo el evento del progreso

                this.Progress(((Descargador)downloader).Progreso);

            }

            // Al finalizar lanzo el evento de descarga terminada

            this.Finish(((Descargador)downloader).HTML);

        }

    }

}
