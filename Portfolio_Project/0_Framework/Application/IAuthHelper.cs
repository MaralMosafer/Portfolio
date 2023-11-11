namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void Signin(AuthViewModel account);
        void Signout();
        bool IsAuthenticated();
        string CurrentUserRole();
        AuthViewModel CurrentAccountInfo();
    }
}
