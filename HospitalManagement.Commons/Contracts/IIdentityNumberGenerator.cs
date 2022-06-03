namespace HospitalManagement.Commons.Contracts
{
    public interface IIdentityNumberGenerator
    {
        string GenerateIdNumber(string designationInitial, int length = 10);
    }
}
