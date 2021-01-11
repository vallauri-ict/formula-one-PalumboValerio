using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClassUtilities;

namespace FormulaOneWebForm
{
    public partial class Default : Page
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // Al primo giro IsPostBack è false, mentre dopo sarà sempre true
            {
                lstNazione.DataSource = utilities.TablesNames();
                lstNazione.DataBind();
                lstNazione.Items.Insert(0, new ListItem("Please select", ""));
            }
            else
            {
                // Elaborazioni da eseguire ogni volta che la pagina viene ricaricata
                //string[] aus = txtUserName.Text.Split().Select(x => x.Replace(" ", "_")).ToArray();

                //if (txtUserName.Text != string.Empty) lblMessaggio.Text = $"Benvenuto al sig. {txtUserName.Text}";
                
            }
        }

        protected void lstNazione_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstNazione.Items.Contains(new ListItem("Please select", "")))
            {
                lstNazione.Items.Remove(new ListItem("Please select", ""));
            }
            dgvNazione.DataSource = utilities.GetDataTable(lstNazione.SelectedValue);
            dgvNazione.DataBind();
        }
    }
}