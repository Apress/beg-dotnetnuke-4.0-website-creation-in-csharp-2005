using System;
using System.Data;

using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
  #region Private variables

  private const bool P_IN = false;
  private const bool P_OUT = true;
  private bool mPunchState = P_IN;

  private DateTime mStartPunch;
  private DateTime mEndPunch;

  private static ArrayList MyPunches = new ArrayList();

  private class WeekPunches
  {
    #region Class local variables

    private DateTime mMondayStart;
    private DateTime mMondayEnd;
    private DateTime mTuesdayStart;
    private DateTime mTuesdayEnd;
    private DateTime mWednesdayStart;
    private DateTime mWednesdayEnd;
    private DateTime mThursdayStart;
    private DateTime mThursdayEnd;
    private DateTime mFridayStart;
    private DateTime mFridayEnd;
    private DateTime mSaturdayStart;
    private DateTime mSaturdayEnd;
    private DateTime mSundayStart;
    private DateTime mSundayEnd;

    #endregion

    #region Accessor Get / Set Methods

    public DateTime MondayStart
    {
      get { return mMondayStart; }
      set { mMondayStart = value; }
    }
    public DateTime MondayEnd
    {
      get { return mMondayEnd; }
      set { mMondayEnd = value; }
    }
    public double MondayHours
    {
      get { return CalculateHours(mMondayStart, mMondayEnd); }
    }

    public DateTime TuesdayStart
    {
      get { return mTuesdayStart; }
      set { mTuesdayStart = value; }
    }
    public DateTime TuesdayEnd
    {
      get { return mTuesdayEnd; }
      set { mTuesdayEnd = value; }
    }
    public double TuesdayHours
    {
      get { return CalculateHours(mTuesdayStart, mTuesdayEnd); }
    }

    public DateTime WednesdayStart
    {
      get { return mWednesdayStart; }
      set { mWednesdayStart = value; }
    }
    public DateTime WednesdayEnd
    {
      get { return mWednesdayEnd; }
      set { mWednesdayEnd = value; }
    }
    public double WednesdayHours
    {
      get { return CalculateHours(mWednesdayStart, mWednesdayEnd); }
    }

    public DateTime ThursdayStart
    {
      get { return mThursdayStart; }
      set { mThursdayStart = value; }
    }
    public DateTime ThursdayEnd
    {
      get { return mThursdayEnd; }
      set { mThursdayEnd = value; }
    }
    public double ThursdayHours
    {
      get { return CalculateHours(mThursdayStart, mThursdayEnd); }
    }

    public DateTime FridayStart
    {
      get { return mFridayStart; }
      set { mFridayStart = value; }
    }
    public DateTime FridayEnd
    {
      get { return mFridayEnd; }
      set { mFridayEnd = value; }
    }
    public double FridayHours
    {
      get { return CalculateHours(mFridayStart, mFridayEnd); }
    }

    public DateTime SaturdayStart
    {
      get { return mSaturdayStart; }
      set { mSaturdayStart = value; }
    }
    public DateTime SaturdayEnd
    {
      get { return mSaturdayEnd; }
      set { mSaturdayEnd = value; }
    }
    public double SaturdayHours
    {
      get { return CalculateHours(mSaturdayStart, mSaturdayEnd); }
    }

    public DateTime SundayStart
    {
      get { return mSundayStart; }
      set { mSundayStart = value; }
    }
    public DateTime SundayEnd
    {
      get { return mSundayEnd; }
      set { mSundayEnd = value; }
    }
    public double SundayHours
    {
      get { return CalculateHours(mSundayStart, mSundayEnd); }
    }

    #endregion

    //This is where you would incorporate some rules such as 
    //lunch breaks 
    private double CalculateHours(DateTime Start, DateTime End)
    {

      //Check to see if end comes after start
      if (DateTime.Compare(Start, End) < 0)
      {
        TimeSpan diff = End.Subtract(Start);
        return (diff.TotalHours);
      }
      return 0.0;
    }

  }

  #endregion

  //This function is called when the web page loads
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["WeekIndex"] == null || cmbWeek.Items.Count ==0 )
    {
      FillData();

      //cmdPunch and cmbWeek have the attributes "runat=server"  Because of this
      //we can access these controls here and fill in the data.
      cmdPunch.Text = "Punch In";
      cmbWeek.Items.Clear();
      cmbWeek.Items.Add("Last Week");
      cmbWeek.Items.Add("This Week");
      cmbWeek.SelectedIndex = 0;

      //Add this function call because in the Web changing the
      //selected index does not fire the selectedindexchanged event.
      DisplayWeek(cmbWeek.SelectedIndex);

    }
    Session["WeekIndex"] = Server.HtmlEncode(cmbWeek.SelectedIndex.ToString());
  }

  private void DisplayWeek(int wk)
  {
    txtSun.Text = "";
    txtMon.Text = "";
    txtTue.Text = "";
    txtWed.Text = "";
    txtThu.Text = "";
    txtFri.Text = "";
    txtSat.Text = "";

    WeekPunches Week = (WeekPunches)MyPunches[wk];
    txtSun.Text = Week.SundayHours.ToString("F2");
    txtMon.Text = Week.MondayHours.ToString("F2");
    txtTue.Text = Week.TuesdayHours.ToString("F2");
    txtWed.Text = Week.WednesdayHours.ToString("F2");
    txtThu.Text = Week.ThursdayHours.ToString("F2");
    txtFri.Text = Week.FridayHours.ToString("F2");
    txtSat.Text = Week.SundayHours.ToString("F2");
  }

  private void FillData()
  {
    //This takes the place of getting data from a database.
    //We will hard code last weeks data and some of this weeks.

    //Create last week
    DateTime LastSunday = DateTime.Now;
    int Days2Subtract = 7 + (int)DateTime.Now.DayOfWeek;
    LastSunday = LastSunday.Subtract(new TimeSpan(
                                    Days2Subtract,
                                    LastSunday.Hour,
                                    LastSunday.Minute,
                                    LastSunday.Second,
                                    LastSunday.Millisecond));

    WeekPunches LastWeek = new WeekPunches();
    LastWeek.SundayStart = LastSunday;
    LastWeek.SundayEnd = LastSunday;
    LastWeek.MondayStart = LastSunday.Add(new TimeSpan(1, 8, 0, 0, 0));
    LastWeek.MondayEnd = LastSunday.Add(new TimeSpan(1, 15, 0, 0, 0));
    LastWeek.TuesdayStart = LastSunday.Add(new TimeSpan(2, 8, 0, 0, 0));
    LastWeek.TuesdayEnd = LastSunday.Add(new TimeSpan(2, 14, 0, 0, 0));
    LastWeek.WednesdayStart = LastSunday.Add(new TimeSpan(3, 8, 0, 0, 0));
    LastWeek.WednesdayEnd = LastSunday.Add(new TimeSpan(3, 13, 0, 0, 0));
    LastWeek.ThursdayStart = LastSunday.Add(new TimeSpan(4, 8, 0, 0, 0));
    LastWeek.ThursdayEnd = LastSunday.Add(new TimeSpan(4, 14, 20, 0, 0));
    LastWeek.FridayStart = LastSunday.Add(new TimeSpan(5, 8, 0, 0, 0));
    LastWeek.FridayEnd = LastSunday.Add(new TimeSpan(5, 15, 30, 0, 0));
    LastWeek.SaturdayStart = LastSunday.Add(new TimeSpan(6, 0, 0, 0, 0));
    LastWeek.SaturdayEnd = LastSunday.Add(new TimeSpan(6, 0, 0, 0, 0));

    MyPunches.Add(LastWeek);

    //Create this week
    DateTime ThisSunday = DateTime.Now;
    Days2Subtract = (int)DateTime.Now.DayOfWeek;
    ThisSunday = ThisSunday.Subtract(new TimeSpan(
                                    Days2Subtract,
                                    ThisSunday.Hour,
                                    ThisSunday.Minute,
                                    ThisSunday.Second,
                                    ThisSunday.Millisecond));
    WeekPunches ThisWeek = new WeekPunches();
    if (DateTime.Now.DayOfWeek > DayOfWeek.Sunday)
    {
      ThisWeek.SundayStart = ThisSunday;
      ThisWeek.SundayEnd = ThisSunday;
    }
    if (DateTime.Now.DayOfWeek > DayOfWeek.Monday)
    {
      ThisWeek.MondayStart = ThisSunday.Add(new TimeSpan(1, 7, 30, 0, 0));
      ThisWeek.MondayEnd = ThisSunday.Add(new TimeSpan(1, 16, 40, 0, 0));
    }
    if (DateTime.Now.DayOfWeek > DayOfWeek.Tuesday)
    {
      ThisWeek.TuesdayStart = ThisSunday.Add(new TimeSpan(2, 8, 20, 0, 0));
      ThisWeek.TuesdayEnd = ThisSunday.Add(new TimeSpan(2, 14, 50, 0, 0));
    }
    if (DateTime.Now.DayOfWeek > DayOfWeek.Wednesday)
    {
      ThisWeek.WednesdayStart = ThisSunday.Add(new TimeSpan(3, 0, 0, 0, 0));
      ThisWeek.WednesdayEnd = ThisSunday.Add(new TimeSpan(3, 0, 0, 0, 0));
    }
    if (DateTime.Now.DayOfWeek > DayOfWeek.Thursday)
    {
      ThisWeek.ThursdayStart = ThisSunday.Add(new TimeSpan(4, 0, 0, 0, 0));
      ThisWeek.ThursdayEnd = ThisSunday.Add(new TimeSpan(4, 0, 0, 0, 0));
    }
    if (DateTime.Now.DayOfWeek > DayOfWeek.Friday)
    {
      ThisWeek.FridayStart = ThisSunday.Add(new TimeSpan(5, 0, 0, 0, 0));
      ThisWeek.FridayEnd = ThisSunday.Add(new TimeSpan(5, 0, 0, 0, 0));
    }
    MyPunches.Add(ThisWeek);

  }

  protected void cmdPunch_Click(object sender, EventArgs e)
  {
    //If the session variable is available then
    //refill the mPunchState with the saved value
    if (Session["mPunchState"] != null)
      mPunchState = (bool)Session["mPunchState"];

    //If the session variable is available then
    //refill the mPunchState with the saved value
    if (Session["mStartPunch"] != null)
      mStartPunch = (DateTime)Session["mStartPunch"];

    //If the session variable is available then
    //refill the mPunchState with the saved value
    if (Session["mEndPunch"] != null)
      mEndPunch = (DateTime)Session["mEndPunch"];

    if (mPunchState == P_OUT)
    {
      mPunchState = P_IN;
      cmdPunch.Text = "Punch In";
      mEndPunch = DateTime.Today;

      mEndPunch = mEndPunch.Add(new TimeSpan(2, 5, 0));

      txtHoursToday.Text = CalculateHours(mStartPunch, mEndPunch).ToString("F2");

      WeekPunches Week = (WeekPunches)MyPunches[1];
      switch (DateTime.Now.DayOfWeek)
      {
        case DayOfWeek.Sunday:
          Week.SundayStart = mStartPunch;
          Week.SundayEnd = mEndPunch;
          break;
        case DayOfWeek.Monday:
          Week.MondayStart = mStartPunch;
          Week.MondayEnd = mEndPunch;
          break;
        case DayOfWeek.Tuesday:
          Week.TuesdayStart = mStartPunch;
          Week.TuesdayEnd = mEndPunch;
          break;
        case DayOfWeek.Wednesday:
          Week.WednesdayStart = mStartPunch;
          Week.WednesdayEnd = mEndPunch;
          break;
        case DayOfWeek.Thursday:
          Week.ThursdayStart = mStartPunch;
          Week.ThursdayEnd = mEndPunch;
          break;
        case DayOfWeek.Friday:
          Week.FridayStart = mStartPunch;
          Week.FridayEnd = mEndPunch;
          break;
        case DayOfWeek.Saturday:
          Week.SaturdayStart = mStartPunch;
          Week.SaturdayEnd = mEndPunch;
          break;
      }
      DisplayWeek(cmbWeek.SelectedIndex);
    }
    else
    {
      mPunchState = P_OUT;
      cmdPunch.Text = "Punch Out";
      mStartPunch = DateTime.Today;
    }
    //Save the mPuchState variable for use next time through
    Session["mPunchState"] = mPunchState;
    Session["mStartPunch"] = mStartPunch;
    Session["mEndPunch"] = mEndPunch;

  }

  private double CalculateHours(DateTime Start, DateTime End)
  {

    //Check to see if end comes after start
    if (DateTime.Compare(Start, End) < 0)
    {
      TimeSpan diff = End.Subtract(Start);
      return (diff.TotalHours);
    }
    return 0.0;
  }

  protected void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
  {
    DisplayWeek(cmbWeek.SelectedIndex);
  }
}
