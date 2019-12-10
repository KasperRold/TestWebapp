using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace TestWebapp.Test
{
    [TestFixture]
    public class ApiWebApplicationFactory : WebApplicationFactory<TestWebapp.Startup>
    {
        
    }
}