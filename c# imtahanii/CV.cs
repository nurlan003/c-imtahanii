using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahan_C_
{
    public class CV
    {
        public string Ixtisas { get; set; }
        public string OxuduguMekteb { get; set; }
        public string UniQebulBali { get; set; }
        public string[] Skills { get; set; }
        public string[] Companies { get; set; }
        public string CommonWorkTime { get; set; }
        public string[] Languages { get; set; }
        public bool FerqlenmeDiplomu { get; set; }
        public string GITLINK { get; set; }
        public string LINKEDIN { get; set; }
        public CV(string ıxtisas, string oxuduguMekteb, string uniQebulBali, string[] skills, string[] companies, string commonWorkTime, string[] languages, bool ferqlenmeDiplomu, string gITLINK, string lINKEDIN)
        {
            Ixtisas=ıxtisas;
            OxuduguMekteb=oxuduguMekteb;
            UniQebulBali=uniQebulBali;
            Skills=skills;
            Companies=companies;
            CommonWorkTime=commonWorkTime;
            Languages=languages;
            FerqlenmeDiplomu=ferqlenmeDiplomu;
            GITLINK=gITLINK;
            LINKEDIN=lINKEDIN;
        }
    }
}

