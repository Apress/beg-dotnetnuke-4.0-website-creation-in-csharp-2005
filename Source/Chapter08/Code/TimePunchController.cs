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
using System.Configuration;
using System.Data;
using System.Xml;
using System.Web;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;

namespace YourCompany.Modules.TimePunch
{
  /// -------------------------------------------------------------
  ///<summary>
  /// The Controller class for the TimePunch
  /// </summary>
  /// <remarks>
  /// </remarks>
  /// <history>
  /// </history>
  /// --------------------------------------------------------------
  /// 

  public class WeekPunches
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

    //This is added from the WebPunchProgram
    public double TodaysHours
    {
      get
      {
        switch (DateTime.Now.DayOfWeek)
        {
          case DayOfWeek.Sunday:
            return CalculateHours(SundayStart, SundayEnd);
          case DayOfWeek.Monday:
            return CalculateHours(MondayStart, MondayEnd);
          case DayOfWeek.Tuesday:
            return CalculateHours(TuesdayStart, TuesdayEnd);
          case DayOfWeek.Wednesday:
            return CalculateHours(WednesdayStart, WednesdayEnd);
          case DayOfWeek.Thursday:
            return CalculateHours(ThursdayStart, ThursdayEnd);
          case DayOfWeek.Friday:
            return CalculateHours(FridayStart, FridayEnd);
          case DayOfWeek.Saturday:
            return CalculateHours(SaturdayStart, SaturdayEnd);
        }
        return 0.0;
      }
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

  public class TimePunchController
  {

    private ArrayList MyPunches = new ArrayList();
    private enum PunchType
    {
      PUNCH_IN,
      PUNCH_OUT
    };

    #region Constructors

    public TimePunchController()
    {
    }

    #endregion

    public ArrayList PunchArray
    {
      get { return MyPunches; }
    }


    #region Public Methods

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// adds an object to the database
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="objTimePunch">The TimePunchInfo object</param>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public void AddTimePunch(TimePunchInfo objTimePunch)
    {
      DataProvider.Instance().AddTimePunch(objTimePunch.ModuleId,
                                           objTimePunch.Punch_Type,
                                           objTimePunch.Punch_User);
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// deletes an object from the database
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="ModuleId">The Id of the module</param>
    /// <param name="ItemId">The Id of the item</param>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public void DeleteTimePunch(int ModuleId, int ItemId)
    {
      DataProvider.Instance().DeleteTimePunch(ModuleId, ItemId);
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// gets an object from the database
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="moduleId">The Id of the module</param>
    /// <param name="ItemId">The Id of the item</param>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public TimePunchInfo GetTimePunch(int ModuleId, int ItemId)
    {
      return CBO.FillObject<TimePunchInfo>(DataProvider.Instance().
                                                GetTimePunch(ModuleId, ItemId));
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// gets an object from the database
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="moduleId">The Id of the module</param>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public List<TimePunchInfo> GetTimePunchs(int ModuleId, int PunchUserID)
    {
      return CBO.FillCollection<TimePunchInfo>(DataProvider.Instance().
                                                GetTimePunchs(ModuleId,
                                                              PunchUserID));
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// saves an object to the database
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="objTimePunch">The TimePunchInfo object</param>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public void UpdateTimePunch(TimePunchInfo objTimePunch)
    {
      DataProvider.Instance().UpdateTimePunch(objTimePunch.ModuleId,
                                              objTimePunch.ItemId,
                                              objTimePunch.Punch_User,
                                              objTimePunch.Punch_Type,
                                              objTimePunch.Punch_Date);
    }

    public void FillData(int ModuleId, int PunchUserID)
    {
      //Set up a collection of TimePunchInfo objects
      List<TimePunchInfo> colTimePunchs;

      //Get the content from the TimePunch table
      colTimePunchs = GetTimePunchs(ModuleId, PunchUserID);

      //Reset the MyPunches array list
      MyPunches.Clear();

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

      //We now have a list of punches for this person forever.
      // (This is where a list of punches for a time span would be handy)
      // (also most programs like this would archive data so there would 
      // only be about 1 yrs worth in here anyway.)
      LastWeek.SundayStart    = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday, colTimePunchs);
      LastWeek.SundayEnd      = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday, colTimePunchs);
      LastWeek.MondayStart    = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday.AddDays(1), colTimePunchs);
      LastWeek.MondayEnd      = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday.AddDays(1), colTimePunchs);
      LastWeek.TuesdayStart   = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday.AddDays(2), colTimePunchs);
      LastWeek.TuesdayEnd     = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday.AddDays(2), colTimePunchs);
      LastWeek.WednesdayStart = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday.AddDays(3), colTimePunchs);
      LastWeek.WednesdayEnd   = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday.AddDays(3), colTimePunchs);
      LastWeek.ThursdayStart  = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday.AddDays(4), colTimePunchs);
      LastWeek.ThursdayEnd    = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday.AddDays(4), colTimePunchs);
      LastWeek.FridayStart    = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday.AddDays(5), colTimePunchs);
      LastWeek.FridayEnd      = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday.AddDays(5), colTimePunchs);
      LastWeek.SaturdayStart  = GetPunch(PunchType.PUNCH_IN, 
                                         LastSunday.AddDays(6), colTimePunchs);
      LastWeek.SaturdayEnd    = GetPunch(PunchType.PUNCH_OUT, 
                                         LastSunday.AddDays(6), colTimePunchs);

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
      WeekPunches ThisWeek    = new WeekPunches();
      ThisWeek.SundayStart    = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday, colTimePunchs);
      ThisWeek.SundayEnd      = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday, colTimePunchs);
      ThisWeek.MondayStart    = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday.AddDays(1), colTimePunchs);
      ThisWeek.MondayEnd      = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday.AddDays(1), colTimePunchs);
      ThisWeek.TuesdayStart   = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday.AddDays(2), colTimePunchs);
      ThisWeek.TuesdayEnd     = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday.AddDays(2), colTimePunchs);
      ThisWeek.WednesdayStart = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday.AddDays(3), colTimePunchs);
      ThisWeek.WednesdayEnd   = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday.AddDays(3), colTimePunchs);
      ThisWeek.ThursdayStart  = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday.AddDays(4), colTimePunchs);
      ThisWeek.ThursdayEnd    = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday.AddDays(4), colTimePunchs);
      ThisWeek.FridayStart    = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday.AddDays(5), colTimePunchs);
      ThisWeek.FridayEnd      = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday.AddDays(5), colTimePunchs);
      ThisWeek.SaturdayStart  = GetPunch(PunchType.PUNCH_IN, 
                                        ThisSunday.AddDays(6), colTimePunchs);
      ThisWeek.SaturdayEnd    = GetPunch(PunchType.PUNCH_OUT, 
                                        ThisSunday.AddDays(6), colTimePunchs);

      MyPunches.Add(ThisWeek);
    }

    public double CalculateHours(DateTime Start, DateTime End)
    {
      //Check to see if end comes after start
      if (DateTime.Compare(Start, End) < 0)
      {
        TimeSpan diff = End.Subtract(Start);
        return (diff.TotalHours);
      }
      return 0.0;
    }

    //This method will troll the collection looking for the earliest punch 
    //of the day if the punch type is punch_in.  It will look for the latest 
    //punch of the day if the punch type is punch_out.
    private DateTime GetPunch(PunchType pt, DateTime dt, 
                              List<TimePunchInfo> TimePunchs)
    {
      DateTime BaseTime = DateTime.MaxValue;
      bool found = false;

      //Set to min or max if punch in or out
      if (pt == PunchType.PUNCH_IN)
        BaseTime = DateTime.MaxValue;
      else
        BaseTime = DateTime.MinValue;

      foreach (TimePunchInfo tpi in TimePunchs)
      {
        if ((PunchType)tpi.Punch_Type == pt)
        {
          if (dt.ToShortDateString() == tpi.Punch_Date.ToShortDateString())
          {
            found = true;
            if (pt == PunchType.PUNCH_IN && tpi.Punch_Date <= BaseTime)
              BaseTime = tpi.Punch_Date;

            if (pt == PunchType.PUNCH_OUT && tpi.Punch_Date >= BaseTime)
              BaseTime = tpi.Punch_Date;
          }
        }
      }

      if (found)
        return BaseTime;
      else
        return DateTime.MinValue;
    }

    public int GetPunchState(int ModuleId, int PunchUserID)
    {
      int retval = 1;  //punch OUT state
      DateTime LastPunch = DateTime.MinValue;

      //Set up a collection of TimePunchInfo objects
      List<TimePunchInfo> colTimePunchs;

      //Get the content from the TimePunch table
      colTimePunchs = GetTimePunchs(ModuleId, PunchUserID);
      foreach (TimePunchInfo tpi in colTimePunchs)
      {
        if (DateTime.Today.ToShortDateString() == tpi.Punch_Date.ToShortDateString())
        {
          if (tpi.Punch_Date >= LastPunch)
          {
            LastPunch = tpi.Punch_Date;
            retval = tpi.Punch_Type;
          }
        }
      }
      return retval;
    }

    #endregion

  }
}

