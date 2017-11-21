using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo {

    public class Descargador {

        private string _html;
        private Uri _direccion;
        private int _progreso;

        public int Progreso {

            get { return this._progreso; }

        }

        public string HTML {

            get { return this._html; }

        }

        public Descargador(Uri direccion) {

            this._html = "";
            this._direccion = direccion;
            this._progreso = 0;

        }

        public void IniciarDescarga() {

            try {

                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);

                cliente.DownloadStringAsync(this._direccion);

            } catch (Exception e) {

                throw e;

            }

        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {

            this._progreso = e.ProgressPercentage;

        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e) {

            this._html = e.Result;

        }

    }

}
