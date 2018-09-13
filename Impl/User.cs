using System;
using System.Text.RegularExpressions;
using Android.Util;
using PracticalCodingTestProj.Droid.Interfaces;

namespace PracticalCodingTestProj.Droid.Impl {
  public class User : IValidation, IMockExceptionLogHandling {

    private IMockAPI mockApi;
    private int Userid { get; }
    
    public string Username { get; }
    public string Fullname { get; }
    public string Password { get; }

    public User(){ }

    public User(int userid, string username, string fullname, string password){
      Userid = userid;
      Username = username;
      Fullname = fullname;
      Password = password;
    }

    /* Validation Rules
      must have at least 1 char and number
      must be only characters and numbers
      must be 5-12 in length
      cannot contain 3 consecutive's
    */
    public bool IsValid(){
      // ensure length between 5-12 characters...
      var charNumLenBetween5And12 = new Regex("^[a-zA-Z0-9]{5,12}$");

      // ensure only characters and numbers with at least one of each
      var charNumOnlyAndAtLeastOneExpression = new Regex("^(?:[0-9]+[/a-zA-Z]|[a-z]+[0-9])[a-zA-Z0-9]*$");

      const string value = "twt0";
      var retVal = charNumLenBetween5And12.IsMatch(value) || charNumOnlyAndAtLeastOneExpression.IsMatch(value);
      return retVal;
    }

    public void LogException(string message, Exception ex){
      Log.Error(message, ex.Message);
    }

    public void LogInfo(string msg, string error){
      Log.Info(msg, error);
    }

    public void LogWarning(string msg, string error){
      Log.Warn(msg, error);
    }

    public void CreateUser(){
      try {
        mockApi.CreateUser(this);
      } catch (Exception ex) {
        LogException("Error creating user...", ex);
      }
    }
  }
}