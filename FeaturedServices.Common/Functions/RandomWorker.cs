using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Functions
{
    public class RandomWorker
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

		public static string ComputeMd5Hash(string message)
		{
			using (MD5 md5 = MD5.Create())
			{
				byte[] input = Encoding.ASCII.GetBytes(message);
				byte[] hash = md5.ComputeHash(input);

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hash.Length; i++)
				{
					sb.Append(hash[i].ToString("X2"));
				}
				var result = sb.ToString();
				return result.Substring(result.Length - 5);
			}
		}
	}
}
