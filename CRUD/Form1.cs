using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRUD
{
    public partial class Form1 : Form
    {

        public void ClearAllText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        public void showTable()
        {
            SqlConnection connection = new SqlConnection("Data Source=COM-1214-3196;Initial Catalog=testDB;Integrated Security=True");
            SqlCommand selectQuery = new SqlCommand("Select * from Crud", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //Insert
        {
            SqlConnection connection = new SqlConnection("Data Source=COM-1214-3196;Initial Catalog=testDB;Integrated Security=True");
            connection.Open();

            string name = Convert.ToString(textBox1.Text);
            string id = Convert.ToString(textBox2.Text);
            string mobile = Convert.ToString(textBox3.Text);

            SqlCommand command = new SqlCommand("INSERT INTO Crud values (@name, @id, @mobile)", connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@mobile", mobile);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Successfully Inserted!");
            ClearAllText();

            showTable();
        }

        private void button2_Click(object sender, EventArgs e)  //Update
        {
            SqlConnection connection = new SqlConnection("Data Source=COM-1214-3196;Initial Catalog=testDB;Integrated Security=True");
            connection.Open();

            string name = Convert.ToString(textBox1.Text);
            string id = Convert.ToString(textBox2.Text);
            string mobile = Convert.ToString(textBox3.Text);

            SqlCommand command = new SqlCommand("Update Crud set name=@name, mobile=@mobile where id=@id", connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@mobile", mobile);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Successfully Updated!");

            showTable();

        }

        private void button3_Click(object sender, EventArgs e)  //delete
        {
            SqlConnection connection = new SqlConnection("Data Source=COM-1214-3196;Initial Catalog=testDB;Integrated Security=True");
            connection.Open();

            string id = Convert.ToString(textBox2.Text);

            SqlCommand command = new SqlCommand("Delete Crud where id=@id", connection);

            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Successfully Deleted!");

            showTable();
        }
    }
}