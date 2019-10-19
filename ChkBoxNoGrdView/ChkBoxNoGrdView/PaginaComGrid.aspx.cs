using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkBoxNoGrdView
{
    public partial class PaginaComGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            //dr["Column1"] = "0";
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void CheckBox1_Click(object sender, System.EventArgs e)
        {
            // The CheckBox control's Text property is changed each time the   
            // control is clicked, indicating a checked or unchecked state.
            CheckBox chk = GridView1.FindControl("checkBox1") as CheckBox;
            bool c = true;
            if (chk.Checked)
            {
                c = true;
            }
            else
            {
                c = false;
            }

            if (c)
            {
                Label1.Text = "Checked";
            }
            else
            {
                Label1.Text = "Unchecked";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetCheck();
        }

        protected void Check_Change(object sender, EventArgs e)
        {
            GetCheck();
        }

        private void GetCheck()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                if (chk.Checked)
                {
                    Label1.Text = "checked";
                }
                else
                {
                    Label1.Text = "Unchecked";
                }
            }
        }
    }
}