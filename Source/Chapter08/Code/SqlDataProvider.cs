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
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;

namespace YourCompany.Modules.TimePunch
{
  /// -----------------------------------------------------------------------------
  /// <summary>
  /// The SqlDataProvider class is a SQL Server implementation of the abstract DataProvider
  /// </summary>
  /// <remarks>
  /// </remarks>
  /// <history>
  /// </history>
  /// -----------------------------------------------------------------------------
  public class SqlDataProvider : DataProvider
  {

    #region Private Members

    private const string ProviderType = "data";
    private const string ModuleQualifier = "YourCompany_";

    private ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
    private string _connectionString;
    private string _providerPath;
    private string _objectQualifier;
    private string _databaseOwner;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructs new SqlDataProvider instance
    /// </summary>
    public SqlDataProvider()
    {
      //Read the configuration specific information for this provider
      Provider objProvider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];

      //Read the attributes for this provider
      if ((objProvider.Attributes["connectionStringName"] != "") && (System.Configuration.ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]] != ""))
      {
        _connectionString = System.Configuration.ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]];
      }
      else
      {
        _connectionString = objProvider.Attributes["connectionString"];
      }

      _providerPath = objProvider.Attributes["providerPath"];

      _objectQualifier = objProvider.Attributes["objectQualifier"];

      if ((_objectQualifier != "") && (_objectQualifier.EndsWith("_") == false))
      {
        _objectQualifier += "_";
      }

      _databaseOwner = objProvider.Attributes["databaseOwner"];
      if ((_databaseOwner != "") && (_databaseOwner.EndsWith(".") == false))
      {
        _databaseOwner += ".";
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets and sets the connection string
    /// </summary>
    public string ConnectionString
    {
      get { return _connectionString; }
    }

    /// <summary>
    /// Gets and sets the Provider path
    /// </summary>
    public string ProviderPath
    {
      get { return _providerPath; }
    }

    /// <summary>
    /// Gets and sets the Object qualifier
    /// </summary>
    public string ObjectQualifier
    {
      get { return _objectQualifier; }
    }

    /// <summary>
    /// Gets and sets the database owner
    /// </summary>
    public string DatabaseOwner
    {
      get { return _databaseOwner; }
    }

    #endregion

    #region Private Methods

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Gets the fully qualified name of the stored procedure
    /// </summary>
    /// <param name="name">The name of the stored procedure</param>
    /// <returns>The fully qualified name</returns>
    /// -----------------------------------------------------------------------------
    private string GetFullyQualifiedName(string name)
    {
      return DatabaseOwner + ObjectQualifier + ModuleQualifier + name;
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Gets the value for the field or DbNull if field has "null" value
    /// </summary>
    /// <param name="Field">The field to evaluate</param>
    /// <returns></returns>
    /// -----------------------------------------------------------------------------
    private Object GetNull(Object Field)
    {
      return Null.GetNull(Field, DBNull.Value);
    }

    #endregion

    #region Public Methods

    public override void AddTimePunch(int ModuleId, int PunchType, int PunchUserID)
    {
      SqlHelper.ExecuteNonQuery(ConnectionString, 
                                GetFullyQualifiedName("AddTimePunch"), 
                                                      ModuleId, 
                                                      PunchType,
                                                      PunchUserID);
    }

    public override void DeleteTimePunch(int ModuleId, int ItemId)
    {
      SqlHelper.ExecuteNonQuery(ConnectionString, 
                                GetFullyQualifiedName("DeleteTimePunch"), 
                                                       ModuleId, 
                                                       ItemId);
    }

    public override IDataReader GetTimePunch(int ModuleId, int ItemId)
    {
      return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, 
                                GetFullyQualifiedName("GetTimePunch"), 
                                                       ModuleId, 
                                                       ItemId);
    }

    public override IDataReader GetTimePunchs(int ModuleId, int PunchUserID)
    {
      return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, 
                                GetFullyQualifiedName("GetTimePunchs"), 
                                                       ModuleId,
                                                       PunchUserID);
    }

    public override void UpdateTimePunch(int ModuleId, 
                                          int ItemId,
                                          int PunchUser,
                                          int PunchType,
                                          DateTime PunchDate)
    {
      SqlHelper.ExecuteNonQuery(ConnectionString, 
                                GetFullyQualifiedName("UpdateTimePunch"), 
                                                       ModuleId, 
                                                       ItemId, 
                                                       PunchUser, 
                                                       PunchType,
                                                       PunchDate);
    }

    #endregion

  }
}
