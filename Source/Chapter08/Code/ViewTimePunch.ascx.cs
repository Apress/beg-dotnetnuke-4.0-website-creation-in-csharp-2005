/*
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2005
' by Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

namespace YourCompany.Modules.TimePunch
{
  /// -----------------------------------------------------------------------------
  /// <summary>
  /// The ViewTimePunch class displays the content
  /// </summary>
  /// <remarks>
  /// </remarks>
  /// <history>
  /// </history>
  /// -----------------------------------------------------------------------------
  partial class ViewTimePunch : PortalModuleBase, IActionable
  {

    private static TimePunchController TimePunchs = null;
    private const bool P_IN = false;
    private const bool P_OUT = true;
    private bool mPunchState = P_IN;

    #region Event Handlers

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Page_Load runs when the control is loaded
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    protected void Page_Load(System.Object sender, System.EventArgs e)
    {
      if (this.Session["WeekIndex"] == null || cmbWeek.Items.Count == 0)
      {
        //Get the business layer going
        TimePunchs = new TimePunchController();

        //cmdPunch and cmbWeek have the attributes "runat=server"  Because of 
        //this we can access these controls here and fill in the data.
        cmbWeek.Items.Clear();
        cmbWeek.Items.Add("Last Week");
        cmbWeek.Items.Add("This Week");
        cmbWeek.SelectedIndex = 0;

        //Add this function call because in the Web changing the
        //selected index does not fire the selectedindexchanged event.
        DisplayWeek(cmbWeek.SelectedIndex);

        //Get the punch state from the database and save it in the session 
        //state for fast retrieval. The punch state is whatever the last punch 
        //was for the day for this person
        if (TimePunchs.GetPunchState(ModuleId, this.UserId) == 0)
        {
          //Person is currently punched in
          cmdPunch.Text = "Punch Out";
          mPunchState = P_OUT;
        }
        else
        {
          //Person is currently punched out
          cmdPunch.Text = "Punch In";
          mPunchState = P_IN;
        }
        //Save the mPuchState variable for use next time through
        this.Session["mPunchState"] = mPunchState;

        //If no-one is logged in then disable the button and dropdown
        if(this.UserId == -1)
        {
          cmdPunch.Text = "Disabled.  No log in";
          cmdPunch.Enabled = false;
          cmbWeek.Enabled = false;
        }
      }
      this.Session["WeekIndex"] = Server.HtmlEncode(cmbWeek.SelectedIndex.
                                                               ToString());
    }

    protected void cmdPunch_Click(object sender, EventArgs e)
    {
      //If the session variable is available then
      //refill the mPunchState with the saved value
      if (this.Session["mPunchState"] != null)
        mPunchState = (bool)this.Session["mPunchState"];

      if (mPunchState == P_OUT)
      {
        mPunchState = P_IN;
        cmdPunch.Text = "Punch In";

        //Save the out punch time
        TimePunchInfo tpi = new TimePunchInfo();
        tpi.ModuleId = ModuleId;
        tpi.Punch_User = this.UserId;
        tpi.Punch_Type = 1;
        TimePunchs.AddTimePunch(tpi);

        DisplayWeek(cmbWeek.SelectedIndex);
      }
      else
      {
        mPunchState = P_OUT;
        cmdPunch.Text = "Punch Out";

        //Save the in punch time
        TimePunchInfo tpi = new TimePunchInfo();
        tpi.ModuleId = ModuleId;
        tpi.Punch_User = this.UserId;
        tpi.Punch_Type = 0;
        TimePunchs.AddTimePunch(tpi);
      }
      //Save the mPuchState variable for use next time through
      this.Session["mPunchState"] = mPunchState;
    }

    protected void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
      DisplayWeek(cmbWeek.SelectedIndex);
    }

    #endregion

    private void DisplayWeek(int wk)
    {
      TimePunchs.FillData(ModuleId, this.UserId);
      WeekPunches Week = (WeekPunches)TimePunchs.PunchArray[wk];

      txtSun.Text = "";
      txtMon.Text = "";
      txtTue.Text = "";
      txtWed.Text = "";
      txtThu.Text = "";
      txtFri.Text = "";
      txtSat.Text = "";

      //Show the hours worked today in the text box
      txtHoursToday.Text = Week.TodaysHours.ToString("F2");

      txtSun.Text = Week.SundayHours.ToString("F2");
      txtMon.Text = Week.MondayHours.ToString("F2");
      txtTue.Text = Week.TuesdayHours.ToString("F2");
      txtWed.Text = Week.WednesdayHours.ToString("F2");
      txtThu.Text = Week.ThursdayHours.ToString("F2");
      txtFri.Text = Week.FridayHours.ToString("F2");
      txtSat.Text = Week.SundayHours.ToString("F2");
    }

    #region Optional Interfaces

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Registers the module actions required for interfacing with the portal framework
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public ModuleActionCollection ModuleActions
    {
      get
      {
        ModuleActionCollection Actions = new ModuleActionCollection();
        Actions.Add(this.GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile), ModuleActionType.AddContent, "", "", this.EditUrl(), false, SecurityAccessLevel.Edit, true, false);
        return Actions;
      }
    }

    #endregion

  }
}

