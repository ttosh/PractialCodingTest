using System;

namespace PracticalCodingTestProj.Droid.Interfaces {
  public interface IMockExceptionLogHandling {
    void LogException(string message, Exception ex);
    void LogInfo(string msg, string error);
    void LogWarning(string msg, string error);
  }
}