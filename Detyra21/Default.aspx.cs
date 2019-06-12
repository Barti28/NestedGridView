using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Detyra21
{
    public partial class _Default : Page
    {
        string connectionString = @"Data Source=BARTI-PC;Initial Catalog=Biblioteka;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGridView();
                this.BindDropDownList();

            }
        }

        private void BindGridView()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM personi"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();


                        }
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvLibri = (GridView)e.Row.FindControl("gvLibri");

                //gvLibri.RowEditing += new GridViewEditEventHandler(gvLibri_RowEditing_test);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    int lexuesiID = Convert.ToInt32(((DataRowView)e.Row.DataItem)["LexuesiID"].ToString());
                    string query = "SELECT * FROM libri where LexuesiID=" + lexuesiID;
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    gvLibri.DataSource = ds;
                    gvLibri.DataBind();

                }
            }
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            //{
            //    string del = (e.Row.Cells[7].Controls[2] as LinkButton).Text;
            //    if (del == "Delete")
            //    {
            //        (e.Row.Cells[7].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Deshironi ta fshini?');";
            //    } 
            //}
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            this.BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int lexuesiID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string emri = (row.FindControl("txtEmri") as TextBox).Text;
            string mbiemri = (row.FindControl("txtMbiemri") as TextBox).Text;
            string celulari = (row.FindControl("txtCelulari") as TextBox).Text;
            string emaili = (row.FindControl("txtEmaili") as TextBox).Text;
            string dataDorezimit = (row.FindControl("txtDataDorezimit") as TextBox).Text;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE personi SET Emri=@Emri,Mbiemri=@Mbiemri,Celulari=@Celulari,Emaili=@Emaili,[Data e Dorezimit]=@Data_e_Dorezimit WHERE LexuesiID=@id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Emri", emri);
                sqlCmd.Parameters.AddWithValue("@Mbiemri", mbiemri);
                sqlCmd.Parameters.AddWithValue("@Celulari", celulari);
                sqlCmd.Parameters.AddWithValue("@Emaili", emaili);
                sqlCmd.Parameters.AddWithValue("@Data_e_dorezimit", dataDorezimit);
                sqlCmd.Parameters.AddWithValue("@id", lexuesiID);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            GridView1.EditIndex = -1;
            this.BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int lexuesiID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM personi WHERE LexuesiID=@id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", lexuesiID);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            this.BindGridView();
        }

        protected void btnShto_Click(object sender, EventArgs e)
        {
            string emri = txtEmri1.Text;
            string mbiemri = txtMbiemri1.Text;
            string celulari = txtCelulari1.Text;
            string emaili = txtEmaili1.Text;
            string dataDorezimit = txtDataDorezimit1.Text;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO personi (Emri,Mbiemri,Celulari,Emaili,[Data e Dorezimit]) VALUES (@Emri,@Mbiemri,@Celulari,@Emaili,@Data_e_Dorezimit)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Emri", emri);
                sqlCmd.Parameters.AddWithValue("@Mbiemri", mbiemri);
                sqlCmd.Parameters.AddWithValue("@Celulari", celulari);
                sqlCmd.Parameters.AddWithValue("@Emaili", emaili);
                sqlCmd.Parameters.AddWithValue("@Data_e_dorezimit", dataDorezimit);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            this.BindDropDownList();
            this.BindGridView();
            this.ClearGridviewData();
        }
        private void BindDropDownList()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT [LexuesiID],Emri FROM [personi]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DbListLexuesiID.DataSource = ds;
                DbListLexuesiID.DataBind();

            }
        }
        private void ClearGridviewData()
        {
            txtEmri1.Text = "";
            txtMbiemri1.Text = "";
            txtCelulari1.Text = "";
            txtEmaili1.Text = "";
            txtDataDorezimit1.Text = "";
        }

        /*CHILD*/




        protected void gvLibri_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvLibri = sender as GridView;
            gvLibri.EditIndex = e.NewEditIndex;
            //this.BindGridView();
            
        }

        protected void gvLibri_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gvLibri = sender as GridView;
            gvLibri.EditIndex = -1;
        }

        protected void gvLibri_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView gvLibri = sender as GridView;
            GridViewRow row = gvLibri.Rows[e.RowIndex];
            int liberID = Convert.ToInt32(gvLibri.DataKeys[e.RowIndex].Values[0]);
            string titulli = (row.FindControl("txtTitulli") as TextBox).Text;
            string autori = (row.FindControl("txtAutori") as TextBox).Text;
            string lloji = (row.FindControl("txtLloji") as TextBox).Text;
            string nrfaqeve = (row.FindControl("txtNrFaqeve") as TextBox).Text;
            string vitibotimit = (row.FindControl("txtVitiBotimit") as TextBox).Text;
            string gjendjalibrit = (row.FindControl("txtGjendjaLibrit") as TextBox).Text;
            string isbn = (row.FindControl("txtISBN") as TextBox).Text;
            string dataMarre = (row.FindControl("txtDataEMarre") as TextBox).Text;


            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE libri SET [Titulli i Librit]=@Titulli_i_Librit,Autori=@Autori,Lloji=@Lloji,[Nr i faqeve]=@Nr_i_faqeve,[Viti i Botimit]=@Viti_i_Botimit, [Gjendja e Librit]=@Gjendja_e_Librit,[ISBN  e librit]=@ISBN_e_Librit,[Data e marre]=@Data_e_marre WHERE LiberID=@id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Titulli_i_Librit", titulli);
                sqlCmd.Parameters.AddWithValue("@Autori", autori);
                sqlCmd.Parameters.AddWithValue("@Lloji", lloji);
                sqlCmd.Parameters.AddWithValue("@Nr_i_faqeve", nrfaqeve);
                sqlCmd.Parameters.AddWithValue("@Viti_i_Botimit", vitibotimit);
                sqlCmd.Parameters.AddWithValue("@Gjendja_e_Librit", gjendjalibrit);
                sqlCmd.Parameters.AddWithValue("@ISBN_e_Librit", isbn);
                sqlCmd.Parameters.AddWithValue("@Data_e_marre", dataMarre);
                sqlCmd.Parameters.AddWithValue("@id", liberID);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            gvLibri.EditIndex = -1;
            this.BindGridView();
        }

        protected void gvLibri_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvLibri = sender as GridView;
            GridViewRow row = gvLibri.Rows[e.RowIndex];
            int liberID = Convert.ToInt32(gvLibri.DataKeys[e.RowIndex].Values[0]);
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM libri WHERE LiberID=@id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", liberID);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            this.BindGridView();
        }
        protected void btn1Shto_Click(object sender, EventArgs e)
        {
            string titulli1 = txttitulli1.Text;
            string autori1 = txtautori1.Text;
            string lloji1 = txtlloji1.Text;
            string numri1 = txtnumri1.Text;
            string viti1 = txtviti1.Text;
            string gjendja1 = txtgjendja1.Text;
            string ISBN1 = txtisbn1.Text;
            string data1 = txtdata1.Text;
            int lexuesiId = Convert.ToInt32(DbListLexuesiID.SelectedValue);
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO libri ([Titulli i Librit],Autori,Lloji,[Nr i faqeve],[Viti i Botimit], [Gjendja e Librit],[ISBN  e librit],[Data e marre],[LexuesiID]) VALUES (@Titulli_i_Librit,@Autori,@Lloji,@Nr_i_faqeve,@Viti_i_Botimit,@Gjendja_e_Librit,@ISBN_e_Librit,@Data_e_marre,@LexuesiID)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Titulli_i_Librit", titulli1);
                sqlCmd.Parameters.AddWithValue("@Autori", autori1);
                sqlCmd.Parameters.AddWithValue("@Lloji", lloji1);
                sqlCmd.Parameters.AddWithValue("@Nr_i_faqeve", numri1);
                sqlCmd.Parameters.AddWithValue("@Viti_i_Botimit", viti1);
                sqlCmd.Parameters.AddWithValue("@Gjendja_e_Librit", gjendja1);
                sqlCmd.Parameters.AddWithValue("@ISBN_e_Librit", ISBN1);
                sqlCmd.Parameters.AddWithValue("@Data_e_marre", data1);
                sqlCmd.Parameters.AddWithValue("@LexuesiID", lexuesiId);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            this.BindGridView();
            this.ClearGridviewData1();
            this.ClearGridView2();
        }
        private void ClearGridviewData1()
        {
            txtEmri1.Text = "";
            txtMbiemri1.Text = "";
            txtCelulari1.Text = "";
            txtEmaili1.Text = "";
            txtDataDorezimit1.Text = "";
        }

        private void ClearGridView2()
        {

            txttitulli1.Text = "";
            txtautori1.Text = "";
            txtlloji1.Text = "";
            txtnumri1.Text = "";
            txtviti1.Text = "";
            txtgjendja1.Text = "";
            txtisbn1.Text = "";
            txtdata1.Text = "";
        }
    }
}