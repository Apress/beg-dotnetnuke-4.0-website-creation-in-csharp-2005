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
using System.Configuration;
using System.Data;

namespace YourCompany.Modules.TimePunch
{
  /// -----------------------------------------------------------------------------
  ///<summary>
  /// The Info class for the TimePunch
  /// </summary>
  /// <remarks>
  /// </remarks>
  /// <history>
  /// </history>
  /// -----------------------------------------------------------------------------
  public class TimePunchInfo
  {

    #region Private Members

    private int       _ModuleId;
    private int       _ItemId;
    private int       _PunchType;
    private int       _PunchUserID;
    private DateTime  _PunchDate;
    private string    _Punch_UserName;

    #endregion

    #region Constructors

    // initialization
    public TimePunchInfo()
    {
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets and sets the Module Id
    /// </summary>
    public int ModuleId
    {
      get { return _ModuleId;  }
      set { _ModuleId = value; }
    }

    /// <summary>
    /// Gets and sets the Item Id
    /// </summary>
    public int ItemId
    {
      get { return _ItemId; }
      set { _ItemId = value; }
    }

    /// <summary>
    /// gets and sets the punch type
    /// </summary>
    public int Punch_Type
    {
      get { return _PunchType; }
      set { _PunchType = value; }
    }

    /// <summary>
    /// Gets and sets the User Id who Created/Updated the content
    /// </summary>
    public int Punch_User
    {
      get { return _PunchUserID; }
      set { _PunchUserID = value; }
    }

    /// <summary>
    /// Gets the User name 
    /// </summary>
    public string Punch_UserName
    {
      get { return _Punch_UserName; }
      set { _Punch_UserName = value; }
    }

    /// <summary>
    /// Gets and sets the Date when punched
    /// </summary>
    public DateTime Punch_Date
    {
      get { return _PunchDate; }
      set { _PunchDate = value; }
    }

    #endregion

  }
}
