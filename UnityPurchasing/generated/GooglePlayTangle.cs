// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("mrqCPm1u+M1aRMfmh7ZNF1fbCSSWJxax7SX2dpY3jLF22L3kNhzoI7ynVNe+H6gH+Dbj9c1kw53IdIFs7W5gb1/tbmVt7W5ub//+OaSkkBJf7W5NX2JpZkXpJ+mYYm5ubmpvbFbu//Kyi4NhXgwQIo2tWVY0uwX7y+sgq1uS0xzxXgi0PDq7qtVUMq5+colVZOfkxoQjV/neIIQkEDVaesQ/FVCTseEXUQ7e+CtkSssC0O7ZiShduHZ7Fp7qMfJNOeg2pK1CBnuVdECGZbU+2z6dKWdRLALfuJld3+7pX+kjTXjH3CywpGLjB1MfmB6+6R5DqBQviJihcQ6F0S0LU8lGqMhhFtqXAtjmxEabZmpmDXei2utImjYRABdpc6folm1sbm9u");
        private static int[] order = new int[] { 4,3,8,3,4,6,11,11,11,13,11,12,12,13,14 };
        private static int key = 111;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
