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
    public partial class editOperatorius : Window {

        //langas, keiciantis operatoriaus savybes
        
        string sel;
        private string connStr = "server=localhost;user id=root;database=jkm_baig;charset=utf8";
        
        public editOperatorius(string oid) {
            InitializeComponent();

            this.sel = oid;
            nid_label.Content += " " + oid;

            //nustatome rastus kintamuosius
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open(); 
           

            string sql = "SELECT * FROM operatoriai WHERE oid=" + sel;
            MySqlCommand comm = new MySqlCommand(sql, conn);

            MySqlDataReader eil = comm.ExecuteReader();

            while (eil.Read()) {
                o_pav.Text = eil["op_pav"].ToString();
                o_tipas.Text = eil["op_type"].ToString();
                o_rate.Text = eil["op_rate"].ToString();
            }

            conn.Close();  
        }
        

        //vykdo pakeitimus
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            MySqlConnection conn = new MySqlConnection(connStr);
            string sql = "UPDATE operatoriai SET op_pav=@pav, op_type=@type, op_rate=@rate WHERE oid=@oid;"; 
            

            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@oid", sel);
            comm.Parameters.AddWithValue("@pav", o_pav.Text);
            comm.Parameters.AddWithValue("@type", o_tipas.Text);
            comm.Parameters.AddWithValue("@rate", o_rate.Text);



            try {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex) {
                MessageBox.Show("Klaida: " + ex.ToString(), "");
                conn.Close();
            }
            this.Close();
        }
    }
}
