namespace password_class_lib;

public class Password
{
    public static bool IsValid(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        
        if (password.Length < 6) return false;

        bool hasLower = false;
        bool hasUpper = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsLower(c))
                hasLower = true;
            else if (char.IsUpper(c))
                hasUpper = true;
            else if (char.IsDigit(c))
                hasDigit = true;
        }

        return hasLower && hasUpper && hasDigit;
    }
}