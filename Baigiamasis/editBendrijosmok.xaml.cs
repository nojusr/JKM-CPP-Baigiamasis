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

    public partial class editBendrijosmok : Window {

        //langas, per kuri yra keiciami objekto bendrijos mokesciai

        private string connStr = "server=localhost;user id=root;database=jkm_baig;charset=utf8";

        public editBendrijosmok(string obid) {

            InitializeComponent();
            loadBenComboBox();

            if (obid != "") {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string sql = "SELECT ob_addr FROM objektai WHERE obid=" + obid + ";";

                MySqlCommand comm = new MySqlCommand(sql, conn);
                MySqlDataReader eil = comm.ExecuteReader();

                string buf;

                while (eil.Read()) {
                    buf = eil["ob_addr"].ToString();
                    buf += " (" + obid + ")";
                    ben_ob.Text = buf;
                }
                conn.Close();

            }

            reloadBendrMok();
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

        //uzkrauna pasirinkimus i kombobox
        private void loadBenComboBox() {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT obid, ob_addr FROM objektai";

            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader eil = comm.ExecuteReader();

            string buf;

            while (eil.Read()) {
                buf = eil["ob_addr"].ToString();
                buf += " (" + eil["obid"].ToString() + ")";
                ben_ob.Items.Add(buf);
            }
            conn.Close();
        }

        //bendrijos mokesciu perkrovimo funkcjia
        private void reloadBendrMok() {
            ben_list.IsEnabled = true;
            ben_list.Items.Clear();
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            
            string obid = get_strid(ben_ob.Text);

            if (obid != "null") {
                string sql = "SHOW COLUMNS FROM ben_" + obid + ";";
                MySqlCommand comm = new MySqlCommand(sql, conn);

                MySqlDataReader data = comm.ExecuteReader();

                while (data.Read()) {
                    if (data["Field"].ToString() != "timestamp" && data["Field"].ToString() != "kmokid") {
                        ben_list.Items.Add(data["Field"].ToString());
                    }

                    
                }
                if (ben_list.Items.Count == 0) {
                    ben_list.Items.Add("Nėra :(");
                    ben_list.IsEnabled = false;
                }



            }

            conn.Close();
        }

        //kai perkrauni combobox, perkrauna bendrijos mokescius
        private void ben_ob_DropDownClosed_1(object sender, EventArgs e) {
            reloadBendrMok();
        }

        //prideda bendrijos mokescius
        private void addBendrMok(object sender, RoutedEventArgs e) {

            MySqlConnection conn = new MySqlConnection(connStr);
            

            string obid = get_strid(ben_ob.Text);

            if (obid != "null" && !ben_name.Text.Contains(';') && !ben_name.Text.Contains('\'') && !ben_name.Text.Contains('"')&& !ben_name.Text.Contains('`')) {

                string sql = "ALTER TABLE `ben_" + obid + "` ADD `" + ben_name.Text + "` DOUBLE NOT NULL AFTER  `timestamp`";
                //ALTER TABLE `ben_26` ADD `test` DOUBLE NOT NULL AFTER `timestamp`;
                MySqlCommand comm = new MySqlCommand(sql, conn);

                conn.Open();
                try {
                    comm.ExecuteNonQuery();

                } catch (Exception ex) {
                    MessageBox.Show("Klaida: " + ex.ToString(), "");
                }
                conn.Close();
                reloadBendrMok();
            }
        }

        //trina bendrijos mokescius
        private void delBendrMok(object sender, RoutedEventArgs e) {
            MySqlConnection conn = new MySqlConnection(connStr);
            
            if (ben_list.SelectedItems.Count > 0 ) {
                conn.Open();
                string name;
                string sql;
                string obid = get_strid(ben_ob.Text);
                MySqlCommand comm;
                for (int i = 0; i < ben_list.SelectedItems.Count; i++) {
                    name = ben_list.SelectedItems[i].ToString();
                    sql = "ALTER TABLE `ben_" + obid + "` DROP COLUMN `" + name + "`;";
                    comm = new MySqlCommand(sql, conn);
                    try {
                        comm.ExecuteNonQuery();

                    } catch (Exception ex) {
                        MessageBox.Show("Klaida: " + ex.ToString(), "");
                    }

                }
                conn.Close();
                reloadBendrMok();
            }

            
            
        }



    }
}
