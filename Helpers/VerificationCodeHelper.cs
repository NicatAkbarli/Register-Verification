using System;

public class VerificationCodeHelper
{
    private static string generatedCode;

    public static string GenerateVerificationCode()
    {
        Random random = new Random();
        generatedCode = random.Next(100000, 999999).ToString(); // 6 haneli kod
        return generatedCode;
    }

    public static void SendVerificationCode(string toEmail)
    {
        string code = GenerateVerificationCode();
        string subject = "Email Tesdiqleme kodu";
        string body = $"Sizin tesdiqleme kodunuz: {code}";

        EmailHelper.SendEmail(toEmail, subject, body);
    }

    public static bool ValidateCode(string inputCode)
    {
        return inputCode == generatedCode;
    }
}
