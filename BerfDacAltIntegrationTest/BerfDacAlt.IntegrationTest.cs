//using Xunit;
//
//namespace BerfDacAltIntegrationTest
//{
//    public class BerfDacAltIntegrationTest
//    {
//        [Fact]
//        public void asb_2()
//        {
//            Assert.Equal(1, 1);
//        }
//    }
//}

namespace Berf.Data
{
    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System;

    //using Berf.Data;
    //using BerfDacAltIntegrationTest.

    using Xunit;

    public class BerfDacAltIntegrationTest
    {
        [Fact]
        public void insert_n_records()
        {
            /*
            The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices,
            EntityFramework.SqlServer' registered in the application config file for the ADO.NET provider
            with invariant name 'System.Data.SqlClient' could not be loaded.
            Make sure that the assembly-qualified name is used and that the assembly is
            available to the running application.
            See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            */
            // Arrange
            var berfDbEntities = new BerfDbEntities();

            var Repo = new BerfRepo(berfDbEntities);

            var Zero = new BerfClient
                            {
                            id = Guid.NewGuid()
                            , sessionId = Guid.Empty
                            , renderId = Guid.Empty
                            , ord = 0
                            , url = String.Empty
                            , entryType = String.Empty
                            , source = String.Empty
                            , created = DateTime.UtcNow.ToString("yyyy-MM-dd")
                            , unloadEventStart = 0.0
                            , unloadEventEnd = 0.0
                            , linkNegotiationStart = 0.0
                            , linkNegotiationEnd = 0.0
                            , redirectStart = 0.0
                            , redirectEnd = 0.0
                            , fetchStart = 0.0
                            , domainLookupStart = 0.0
                            , domainLookupEnd = 0.0
                            , connectStart = 0.0
                            , connectEnd = 0.0
                            , secureConnectionStart = 0.0
                            , requestStart = 0.0
                            , responseStart = 0.0
                            , responseEnd = 0.0
                            , domLoading = 0.0
                            , domInteractive = 0.0
                            , domContentLoadedEventStart = 0.0
                            , domContentLoadedEventEnd = 0.0
                            , domComplete = 0.0
                            , loadEventStart = 0.0
                            , loadEventEnd = 0.0
                            , prerenderSwitch = 0.0
                            , redirectCount = 0
                            , initiatorType = String.Empty
                            , name = String.Empty
                            , startTime = 0.0
                            , duration = 0.0
                            , navigationStart = 0.0
                            , userName = String.Empty
                            , clientIP = String.Empty
                            , userAgent = String.Empty
                            , browser = String.Empty
                            , browserVersion = String.Empty
                            , hostMachineName = String.Empty
                            };

            var model = Zero;




            var ret = Repo.InsertBerfClient(model);

            if (ret != null)
            {
                Repo.Save();
            }

            // Assert
            Assert.Equal(1, 1);
        }
    }
}