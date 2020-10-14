namespace BLL.Contracts.Services
{
    public interface IRequestValidationService<in T>
    {
        void ValidateRequest(T request);
    }
}