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
    public partial class editNuomininkas : Window {

        //langas per kuri yra keiciamos nuomininko savybes
        
        private string sel;//identifikatorius
        private string connStr = "server=localhost;user id=root;database=jkm_baig;charset=utf8";
        
        public editNuomininkas(string nid) {
            InitializeComponent();

            this.sel = nid;
            nid_label.Content += " " + nid;

            //nustatome rastus kintamuosius
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open(); 
           

            string sql = "SELECT * FROM NUOMININKAI WHERE nid=" + sel;
            MySqlCommand comm = new MySqlCommand(sql, conn);

            MySqlDataReader eil = comm.ExecuteReader();

            while (eil.Read()) {
                n_name.Text = eil["vard"].ToString();
                n_surname.Text = eil["pav"].ToString();
                n_phone.Text = eil["tel_num"].ToString();
                n_email.Text = eil["email"].ToString();
                n_asmkod.Text = eil["asm_kod"].ToString();
                n_gyv.Text = eil["dek_gyv"].ToString();
            }

            conn.Close();      

        }

        //vykdo pakeitimus
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            MySqlConnection conn = new MySqlConnection(connStr);
            string sql = "UPDATE nuomininkai SET vard=@vard, pav=@pav, tel_num=@tel_num, email=@email, asm_kod=@asm_kod, dek_gyv=@dek_gyv WHERE nid=@nid;"; ;
            

            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@nid", sel);
            comm.Parameters.AddWithValue("@vard", n_name.Text);
            comm.Parameters.AddWithValue("@pav", n_surname.Text);
            comm.Parameters.AddWithValue("@tel_num", n_phone.Text);
            comm.Parameters.AddWithValue("@email", n_email.Text);
            comm.Parameters.AddWithValue("@asm_kod", n_asmkod.Text);
            comm.Parameters.AddWithValue("@dek_gyv", n_gyv.Text);



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
