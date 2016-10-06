using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }
  protected void cmdEnter_Click(object sender, EventArgs e)
  {
    txtText.BackColor = Color.Red;
    txtText.ForeColor = Color.White;
  }
  protected void cmdChange_Click(object sender, EventArgs e)
  {
    if (cmdChange.Text == "This Text")
      cmdChange.Text = "The Other Text";
    else
      cmdChange.Text = "This Text";
  }
  protected void rb1_CheckedChanged(object sender, EventArgs e)
  {
    //Clear the list then add item according to this radio button
    lstList.Items.Clear();
    lstList.Items.Add("First 1 rb");
    lstList.Items.Add("First 2 rb");
    lstList.Items.Add("First 3 rb");
    lstList.Items.Add("First 4 rb");
    lstList.Items.Add("First 5 rb");
  }
  protected void rb2_CheckedChanged(object sender, EventArgs e)
  {
    //Clear the list then add item according to this radio button
    lstList.Items.Clear();
    lstList.Items.Add("Second 1 rb");
    lstList.Items.Add("Second 2 rb");
    lstList.Items.Add("Second 3 rb");
    lstList.Items.Add("Second 4 rb");
    lstList.Items.Add("Second 5 rb");
  }
}
