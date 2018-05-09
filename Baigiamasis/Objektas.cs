using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Baigiamasis {
    class Objektas {

        //kintamieji, matomi datagrid
        public int ID { get; set; }
        public string Address { get; set; }
        public double Kvad { get; set; }
        public double Nuoma { get; set; }
        public string Nuom { get; set;}
        public string Elek { get; set; }
        public string Duj { get; set; }
        public string Vand { get; set; }
        public string Int { get; set; }

        //'vidiniai' kintamieji
        public int corr_nid { get; set; }
        public int ce_oid { get; set; }
        public int cd_oid { get; set; }
        public int cv_oid { get; set; }
        public int ci_oid { get; set; }
        
        private string connStr = "server=localhost;user id=root;database=jkm_baig;charset=utf8";
        
        public void clear() {
            this.ID = -1;
            this.Address = "";
            this.Kvad = -1;
            this.corr_nid = -1;
            this.ce_oid = -1;
            this.cd_oid = -1;
            this.cv_oid = -1;
            this.ci_oid = -1;
        }

        public void set_variables() {
            get_nuom();
            this.Elek = get_operator("Elektra");
            this.Duj = get_operator("Dujos");
            this.Vand = get_operator("Vanduo");
            this.Int = get_operator("Internetas");
        }


        private void get_nuom(){
            if (this.corr_nid >= 0) {
                MySqlConnection conn = new MySqlConnection(connStr);


                conn.Open();

                //nuomininkai
                string sql = "SELECT  vard, pav FROM nuomininkai WHERE nid=@nid;";

                MySqlCommand comm = new MySqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@nid", this.corr_nid.ToString());

                MySqlDataReader data = comm.ExecuteReader();

                string output = "";
                while (data.Read()) {
                    output = data["vard"].ToString();
                    output += " " + data["pav"].ToString();
                    output += " (" + this.corr_nid.ToString() + ")";
                }
                conn.Close();
                this.Nuom = output;

            } else {
                this.Nuom = "Nėra";
            }
        }



        private string get_operator(string type) {
            MySqlConnection conn = new MySqlConnection(connStr);
            if (type != "") {
                int which = 0;
                switch (type) {
                    case "Vanduo":
                        which = this.cv_oid;
                        break;
                    case "Dujos":
                        which = this.cd_oid;
                        break;
                    case "Elektra":
                        which = this.ce_oid;
                        break;
                    case "Internetas":
                        which = this.ci_oid;
                        break;
                }
                conn.Open();

                string sql = "SELECT op_pav FROM operatoriai WHERE oid=@oid;";

                MySqlCommand comm = new MySqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@oid", which.ToString());

                MySqlDataReader data = comm.ExecuteReader();

                string output = "";

                while (data.Read()) {
                    output = data["op_pav"].ToString();
                }

                if (output == "") {
                    output = "Nėra";
                }

                conn.Close();
                return output;
            }
            return "Nėra";
        }


    }
}
