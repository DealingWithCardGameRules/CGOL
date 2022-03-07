using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace CardGameWebApp.Client
{
	public static class Base64Helper
	{
        public static string Encode64(this string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Base64UrlTextEncoder.Encode(valueBytes);
        }

        public static string Decode64(this string value)
        {
            var valueBytes = Base64UrlTextEncoder.Decode(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
    }
}
