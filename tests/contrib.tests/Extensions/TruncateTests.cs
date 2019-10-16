using Xunit;
using Storm.Umbraco.Contrib.Extensions;

namespace Contrib.Tests.Extensions
{
    public class TruncateTests
    {
        [Fact]
        public void Truncate_Length_Only()
        {
            const string s = "the quick brown fox jumps over the lazy dog";
            const string expected = "the quick...";

            string actual = s.Truncate(12);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Truncate_Without_Ellipsis()
        {
            const string s = "the quick brown fox jumps over the lazy dog";
            const string expected = "the quick";

            string actual = s.Truncate(12, ellipsis: null);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Truncate_Do_Not_Keep_Full_Word()
        {
            const string s = "the quick brown fox jumps over the lazy dog";
            const string expected = "the quick br...";

            string actual = s.Truncate(12, keepFullWordAtEnd: false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Truncate_Do_Not_Keep_Full_Word_And_No_Ellipsis()
        {
            const string s = "the quick brown fox jumps over the lazy dog";
            const string expected = "the quick br";

            string actual = s.Truncate(12, keepFullWordAtEnd: false, ellipsis: null);
            Assert.Equal(expected, actual);
        }
    }
}
