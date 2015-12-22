namespace Berf.EfTest
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