using System;
using System.Text;
using System.Security.Cryptography;

namespace CT.Services
{
    public class TestService
    {
        public interface IHashAction
        {
            string GetRfc2898Hash(string HashStr);
        }
        public class IHashService : IHashAction
        {
            private string SaltKey_1;
            private string SaltKey_2;
            public IHashService()
            {
                this.SaltKey_1 = @"FirstSalt";
                this.SaltKey_2 = @"SecondSalt";
            }
            public string GetRfc2898Hash(string HashStr)
            {
                var result = UsingRfc2898Hash(HashStr);
                return result;
            }
            private string UsingRfc2898Hash(string HashStr)
            {
                byte[] ByteStr = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(HashStr)));

                //位元組的隨機金鑰
                int Byte_cb = 8;

                //定義兩組SaltKey,必須大於8Byte
                byte[] SaltKey_1 = Encoding.UTF8.GetBytes(this.SaltKey_1);
                byte[] SaltKey_2 = Encoding.UTF8.GetBytes(this.SaltKey_2);

                //First Add Salt
                Rfc2898DeriveBytes Rfc_1 = new Rfc2898DeriveBytes(ByteStr, SaltKey_1, 2);
                byte[] GetRfc_1 = Rfc_1.GetBytes(Byte_cb);
                var Salt_1Pwd = Convert.ToBase64String(GetRfc_1);

                //Second Add Salt
                Rfc2898DeriveBytes Rfc_2 = new Rfc2898DeriveBytes(Salt_1Pwd, SaltKey_2);
                byte[] GetRfc_2 = Rfc_2.GetBytes(Byte_cb);

                var Salt_2Pwd = Convert.ToBase64String(GetRfc_2);
                return Salt_2Pwd;
            }
        }
    }
}