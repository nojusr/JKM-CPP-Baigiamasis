using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Baigiamasis {
    public partial class editObjektas : Window {
        
        string sel;
        private string connStr = "server=localhost;user id=root;database=jkm_baig;charset=utf8";
        
        //langas per kuri yra keiciamos objekto savybes

        public editObjektas(string obid) {
            InitializeComponent();

            this.sel = obid;
            obid_label.Content += " " + obid;

            //nustatome rastus kintamuosius
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();


            string sql = "SELECT * FROM objektai WHERE obid=" + sel + " LIMIT 1";
            MySqlCommand comm = new MySqlCommand(sql, conn);

            MySqlDataReader eil = comm.ExecuteReader();

            while (eil.Read()) {
                ob_addr.Text = eil["ob_addr"].ToString();
                ob_kvad.Text = eil["ob_kvad"].ToString();
                ob_nkaina.Text = eil["Nuoma"].ToString();
                obLoadComboBox();
                getNuomininkas(eil["corr_nid"].ToString(), ob_nuom);
                getOperator(eil["cv_oid"].ToString(), ob_void);
                getOperator(eil["ce_oid"].ToString(), ob_eoid);
                getOperator(eil["ci_oid"].ToString(), ob_ioid);
                getOperator(eil["cd_oid"].ToString(), ob_doid);

                
            }

            conn.Close();


        }

        //gauna nuomininko varda bei pavarde nuo jo id
        private void getNuomininkas(string nid, ComboBox cb) {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT vard, pav FROM nuomininkai WHERE nid=" + nid +" LIMIT 1;";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader eil = comm.ExecuteReader();

            string output = "";

            while (eil.Read()) {
                output = eil["vard"].ToString();
                output += " " + eil["pav"].ToString();
                output += " (" + nid + ")";
                
            }

            cb.Text = output;
            conn.Close();        
        }

        //gauna operatoriaus pavadinima nuo oid
        private void getOperator(string oid, ComboBox cb) {
            MySqlConnection conn = new MySqlConnection(connStr); 
            conn.Open();

            string sql = "SELECT op_pav FROM operatoriai WHERE oid=@oid;";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@oid", oid);

            MySqlDataReader data = comm.ExecuteReader();

            string output = "";

            while (data.Read()) {
                output = data["op_pav"].ToString();
            }

            output += " (" + oid + ")";

            conn.Close();
            cb.Text = output;
         

        }

        private void obLoadComboBox() {
            MySqlConnection conn = new MySqlConnection(connStr);
            ob_nuom.Items.Clear();
            ob_void.Items.Clear();
            ob_doid.Items.Clear();
            ob_eoid.Items.Clear();
            ob_ioid.Items.Clear();


            conn.Open();

            //nuomininkai
            string sql = "SELECT nid, vard, pav FROM nuomininkai;";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader data = comm.ExecuteReader();

            string buf;

            while (data.Read()) {
                buf = data["vard"].ToString();
                buf += " " + data["pav"].ToString();
                buf += " (" + data["nid"].ToString() + ")";
                ob_nuom.Items.Add(buf);
            }

            //vanduo

            sql = "SELECT oid, op_pav FROM operatoriai WHERE op_type='Vanduo';";
            comm = new MySqlCommand(sql, conn);
            data.Dispose();
            data = comm.ExecuteReader();

            while (data.Read()) {
                buf = data["op_pav"].ToString();
                buf += " (" + data["oid"].ToString() + ")";
                ob_void.Items.Add(buf);
            }

            //dujos/siluma

            sql = "SELECT oid, op_pav FROM operatoriai WHERE op_type='Dujos';";
            comm = new MySqlCommand(sql, conn);
            data.Dispose();
            data = comm.ExecuteReader();

            while (data.Read()) {
                buf = data["op_pav"].ToString();
                buf += " (" + data["oid"].ToString() + ")";
                ob_doid.Items.Add(buf);
            }

            //elektra

            sql = "SELECT oid, op_pav FROM operatoriai WHERE op_type='Elektra';";
            comm = new MySqlCommand(sql, conn);
            data.Dispose();
            data = comm.ExecuteReader();

            while (data.Read()) {
                buf = data["op_pav"].ToString();
                buf += " (" + data["oid"].ToString() + ")";
                ob_eoid.Items.Add(buf);
            }

            //internetas

            sql = "SELECT oid, op_pav FROM operatoriai WHERE op_type='Internetas';";
            comm = new MySqlCommand(sql, conn);
            data.Dispose();
            data = comm.ExecuteReader();

            while (data.Read()) {
                buf = data["op_pav"].ToString();
                buf += " (" + data["oid"].ToString() + ")";
                ob_ioid.Items.Add(buf);
            }
            conn.Close();
            data.Close();
        }      


        //gauna paskutini aplskliausta skaiciu is string
        //pvz: asdf1234543(1234)(4444)asdf(55) grazins 55
        private string get_strid(string input) {
            string buf = "null";
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == '(') {
                    buf = "";
                    i++;
                    while (input[i] != ')') {
                        buf += input[i];
                        i++;
                    }
                }
            }

            return buf;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            MySqlConnection conn = new MySqlConnection(connStr);
            string sql = "UPDATE objektai SET ob_addr=@addr, ob_kvad=@kvad, Nuoma=@nuom, corr_nid=@nid, ce_oid=@eoid, cd_oid=@doid, cv_oid=@void, ci_oid=@ioid WHERE obid=@obid";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@obid", sel);
            comm.Parameters.AddWithValue("@addr", ob_addr.Text);
            comm.Parameters.AddWithValue("@kvad", ob_kvad.Text);
            comm.Parameters.AddWithValue("@nuom", ob_nkaina.Text);
            comm.Parameters.AddWithValue("@nid", get_strid(ob_nuom.Text));
            comm.Parameters.AddWithValue("@eoid", get_strid(ob_eoid.Text));
            comm.Parameters.AddWithValue("@doid", get_strid(ob_doid.Text));
            comm.Parameters.AddWithValue("@void", get_strid(ob_void.Text));
            comm.Parameters.AddWithValue("@ioid", get_strid(ob_ioid.Text));
            try {
                conn.Open();
                comm.ExecuteNonQuery();

            } catch (Exception ex) {
                MessageBox.Show("Klaida: " + ex.ToString(), "");
            }
            conn.Close();
            this.Close();
        }
    }
}
