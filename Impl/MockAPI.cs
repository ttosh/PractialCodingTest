using PracticalCodingTestProj.Droid.Interfaces;

namespace PracticalCodingTestProj.Droid.Impl {
  public class MockAPI : IMockAPI {
    public bool CreateUser(User user){
      // push async call then update UI
      return true;
    }
  }
}