namespace Berf.DataEf
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;

    public class DomainTypes
    {
        public string FileDropDirectory { get; set; }
        public string ProjectNameSpace { get; set; }
        public string TablesWhiteList { get; set; }
    }

    public class TimedItem
    {
        public string Id { get; set; }
        public string RunSigId { get; set; }
        public string SigId { get; set; }
        public string Sig { get; set; }
        public double Time { get; set; }
        public int Count { get; set; }
        public string EventDt { get; set; }
        public string ClientSig { get; set; }
        public string ClientSigVer { get; set; }
        public string Server { get; set; }

        public static TimedItem TimedItemZero()
        {
            return new TimedItem
            {
                Id = Guid.NewGuid().ToString(),
                RunSigId = "",
                Sig = "",
                SigId = "",
                Time = 0.0,
                Count = 0,
                EventDt = DateTime.UtcNow.ToString(@"yyyy-MM-ddTHH\:mm\:ss"),
                ClientSig = "",
                ClientSigVer = "",
                Server = System.Environment.MachineName
            };
        }

        public static void saveTimedItem(TimedItem timedItem, Stopwatch watch)
        {
            var path = @"C:\Users\john kennerley\Dropbox\BerfWeb" + @"\" + @"TestTimeLog.txt";
            var json = JsonConvert.SerializeObject(timedItem);
            var f = String.Format("{0}{1}", Environment.NewLine, json);
            System.IO.File.AppendAllText(path, f);
            //let config = getAppConfig()
            //let path = config.FileDropDirectory + @"\" + @"TestTimeLog.txt";
            //File.AppendAllText(getTestTimeLogFilename(), (sprintf "%s%s" System.Environment.NewLine(JsonConvert.SerializeObject(timedItem))) );
        }
    }
}

namespace Berf.DataEf
{
    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System;

    public static class BerfClientExtension
    {
        public static BerfClient BerfClientZero()
        {
            return new BerfClient
            {
                id = Guid.NewGuid(),
                sessionId = Guid.Empty,
                renderId = Guid.Empty,
                ord = 0,
                url = String.Empty,
                entryType = String.Empty,
                source = String.Empty,
                created = DateTime.UtcNow.ToString(@"yyyy-MM-ddTHH\:mm\:ss"),
                unloadEventStart = 0.0,
                unloadEventEnd = 0.0,
                linkNegotiationStart = 0.0,
                linkNegotiationEnd = 0.0,
                redirectStart = 0.0,
                redirectEnd = 0.0,
                fetchStart = 0.0,
                domainLookupStart = 0.0,
                domainLookupEnd = 0.0,
                connectStart = 0.0,
                connectEnd = 0.0,
                secureConnectionStart = 0.0,
                requestStart = 0.0,
                responseStart = 0.0,
                responseEnd = 0.0,
                domLoading = 0.0,
                domInteractive = 0.0,
                domContentLoadedEventStart = 0.0,
                domContentLoadedEventEnd = 0.0,
                domComplete = 0.0,
                loadEventStart = 0.0,
                loadEventEnd = 0.0,
                prerenderSwitch = 0.0,
                redirectCount = 0,
                initiatorType = String.Empty,
                name = String.Empty,
                startTime = 0.0,
                duration = 0.0,
                navigationStart = 0.0,
                userName = String.Empty,
                clientIP = String.Empty,
                userAgent = String.Empty,
                browser = String.Empty,
                browserVersion = String.Empty,
                hostMachineName = String.Empty
            };
        }
    }
}

namespace Berf.DataEf
{
    using System;

    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    //using Berf.Data;
    //using BerfDacAltIntegrationTest.
    using Xunit;

    public class BerfDacAltIntegrationTest
    {
        public List<BerfClient> getTestableInserts(int n)
        {
            var xs = new List<BerfClient>();

            for (var i = 0; i < n; i++)
            {
                xs.Add(BerfClientExtension.BerfClientZero());
            }

            return xs;
        }
        public static MiRet InsertBerfClient(BerfClient model)
        {
            var berfDbEntities = new BerfDbEntities();

            var repo = new BerfRepo(berfDbEntities);

            var ret = repo.InsertBerfClient(model);

            if (ret != null)
            {
                repo.Save();
            }

            return ret;
        }

        public static MiRet UpdateBerfClient(BerfClient model)
        {
            var berfDbEntities = new BerfDbEntities();

            var repo = new BerfRepo(berfDbEntities);

            var ret = repo.UpdateBerfClient(model);

            if (ret != null)
            {
                repo.Save();
            }

            return ret;
        }

        public static MiRet DeleteBerfClient(BerfClient model)
        {
            var berfDbEntities = new BerfDbEntities();

            var repo = new BerfRepo(berfDbEntities);

            var ret = repo.DeleteBerfClient(model);

            if (ret != null)
            {
                repo.Save();
            }

            return ret;
        }

        [Theory]
        [InlineData(1000)]
        public void insert_n_records(int n )
        {
            // Arrange

            // Act
            var watch = new Stopwatch();
            watch.Start();

            // a record to be inserted and then read back
            var insertableBes = this.getTestableInserts(n);

            var rets =
                insertableBes
                .Select(InsertBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = Berf.DataEf.TimedItem.TimedItemZero();
            //timedItem.Sig = thisFunctionName();
            timedItem.Sig = "insert_n_records_C#Ef";
            timedItem.SigId = "C#Ef";
            timedItem.Time = (float)watch.ElapsedMilliseconds;
            timedItem.Count = n;
            TimedItem.saveTimedItem(timedItem, watch);
        }

        [Theory]
        [InlineData(1000)]
        public void update_n_records(int n)
        {
            // Arrange

            // Act
            var watch = new Stopwatch();
            watch.Start();

            // a record to be inserted and then read back
            var insertableBes = this.getTestableInserts(n);

            // insert
            var insertedRets =
                insertableBes
                .Select(InsertBerfClient)
                .ToList();

            Func<BerfClient, BerfClient> lam = (x) =>
                {
                    x.source = "ITG_UPDATED_C#EF";
                    return x;
                };

            // update
            var updatedRets =
                insertableBes
                .Select(x => lam(x))
                .Select(UpdateBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = Berf.DataEf.TimedItem.TimedItemZero();
            //timedItem.Sig = thisFunctionName();
            timedItem.Sig = "update_n_records_C#Ef";
            timedItem.SigId = "C#Ef";
            timedItem.Time = (float)watch.ElapsedMilliseconds;
            timedItem.Count = n;
            TimedItem.saveTimedItem(timedItem, watch);
        }

        [Theory]
        [InlineData(1000)]
        public void delete_n_records(int n)
        {
            // Arrange

            // Act
            var watch = new Stopwatch();
            watch.Start();

            // a record to be inserted and then read back
            var insertableBes = this.getTestableInserts(n);

            // insert
            var insertedRets =
                insertableBes
                .Select(InsertBerfClient)
                .ToList();

            Func<BerfClient, BerfClient> lam = (x) =>
            {
                x.source = "ITG_DELETED_C#EF";
                return x;
            };

            // update
            var updatedRets =
                insertableBes
                .Select(x => lam(x))
                .Select(DeleteBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = Berf.DataEf.TimedItem.TimedItemZero();
            //timedItem.Sig = thisFunctionName();
            timedItem.Sig = "delete_n_records_C#Ef";
            timedItem.SigId = "C#Ef";
            timedItem.Time = (float)watch.ElapsedMilliseconds;
            timedItem.Count = n;
            TimedItem.saveTimedItem(timedItem, watch);
        }
    }
}