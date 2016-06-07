using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms; 

namespace AISNesover
{
    class sql
    {
           // в строке подключения вместо Admin нужно nGadget
        public static String _connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Admin\Documents\GitHub\dip\AISNesover\AISNesover\Database1.mdf;Integrated Security=True"; 
        public void FillDataGridViewByQuery(DataGridView dgv, String query) 
        { 
            SqlConnection connection = new SqlConnection(); 
            connection.ConnectionString = _connectionString; 
            SqlCommand command = new SqlCommand(); 
            command.Connection = connection; 
            command.CommandText = query; 
            DataTable dataTable = new DataTable(); 
            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            adapter.Fill(dataTable); 
            dgv.DataSource = dataTable; 
        } 
    }
}
