using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supremes;

namespace Loterias {
    class Resultados {
        string megasena;
        string lotomania;
        string lotofacil;
        string quina;
        string duplasena;
        string federal;
        string timemania;
        enum Loteria { MegaSena, Lotofacil, }
        public Resultados() {
            var pagina = Dcsoup.Parse(new Uri("http://loterias.caixa.gov.br/wps/portal/loterias/landing"), 10000);
            var divSorteios = pagina.Select("div.products");
            string txtSorteios = divSorteios.Text;
            megasena = txtSorteios.Substring(txtSorteios.IndexOf("MEGA-SENA"), txtSorteios.IndexOf("LOTOFÁCIL"));
            txtSorteios = txtSorteios.Replace(megasena, "");

            lotofacil = txtSorteios.Substring(txtSorteios.IndexOf("LOTOFÁCIL"), txtSorteios.IndexOf("QUINA"));
            txtSorteios = txtSorteios.Replace(lotofacil, "");

            quina = txtSorteios.Substring(txtSorteios.IndexOf("QUINA"), txtSorteios.IndexOf("LOTOMANIA"));
            txtSorteios = txtSorteios.Replace(quina, "");

            lotomania = txtSorteios.Substring(txtSorteios.IndexOf("LOTOMANIA"), txtSorteios.IndexOf("TIMEMANIA"));
            txtSorteios = txtSorteios.Replace(lotomania, "");

            timemania = txtSorteios.Substring(txtSorteios.IndexOf("TIMEMANIA"), txtSorteios.IndexOf("DUPLA"));
            txtSorteios = txtSorteios.Replace(timemania, "");

            duplasena = txtSorteios.Substring(txtSorteios.IndexOf("DUPLA"), txtSorteios.IndexOf("FEDERAL"));
            txtSorteios = txtSorteios.Replace(duplasena, "");

            federal = txtSorteios.Substring(txtSorteios.IndexOf("FEDERAL"), txtSorteios.IndexOf("LOTECA"));

            return;
        }
        //public string GetResultados(Loteria loteria) {



        //}
        public string MegaSena {
            get { return megasena; }
        }
        public string LotoFacil {
            get { return lotofacil; }
        }
        public string DuplaSena {
            get { return duplasena; }
        }
        public string Lotomania {
            get { return lotomania; }
        }
        public string Quina {
            get { return quina; }
        }
        public string Federal {
            get { return federal; }
        }
        public string TimeMania {
            get { return timemania; }
        }
    }
    

}
