using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EscapeMines.Domain.Test.Utils
{
    public static class AssertExtension
    {
        //I created an extension method to minimize the amount of asserts

        public static void ValidMessage(this ArgumentException argumentException, string messageError)
        {
            if (argumentException.Message == messageError)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"The message is {messageError}");
            }
        }
    }
}
