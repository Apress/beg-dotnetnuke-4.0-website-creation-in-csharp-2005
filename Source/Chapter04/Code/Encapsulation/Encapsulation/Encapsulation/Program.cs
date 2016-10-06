using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
  class Program
  {

    private class DataHiding
    {
      private int mPrivate_integer;
      private string  mPrivate_string;

      public int      mPublic_integer;
      public string   mPublic_string;

      //This is a constructor.  It is used to initialize the object
      // that is created from this class
      public DataHiding()
      {
        mPrivate_integer = 1;
        mPrivate_string  = "one";
        mPublic_integer  = 2;
        mPublic_string   = "two";
      }

      //Accessor method to get and set the private integer
      public int Private_integer
      {
        get { return mPrivate_integer; }
        set { mPrivate_integer = value; }
      }

      //Accessor method to get and set the private string
      public string Private_string
      {
        get { return mPrivate_string; }
        set { mPrivate_string = value; }
      }


    }

    // This is the function that gets run when the program is started 
    static void Main(string[] args)
    {
      //Create the new object fom the class
      DataHiding dh = new DataHiding();

      //get the public values
      Console.Write(dh.mPublic_integer);
      Console.Write(dh.mPublic_string);

      //get the private values via accessor methods
      Console.Write(dh.Private_integer);
      Console.Write(dh.Private_string);
    }
  }
}
