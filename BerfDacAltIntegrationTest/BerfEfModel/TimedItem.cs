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

        public static TimedItem TimedItemZero(string runSigId  = "", string sig = "", string sigId = "" , int count = 0 , float time = (float)0.0, string clientSig = "", string clientSigVer = "" )
        {
            var dtString = @"yyyy-MM-ddTHH\:mm\:ss"; 

            return new TimedItem
            {
                Id = Guid.NewGuid().ToString(),
                RunSigId = runSigId,
                Sig = sig,
                SigId = sigId,
                Time =time ,
                Count = count,
                EventDt = DateTime.UtcNow.ToString(dtString),
                ClientSig = clientSig,
                ClientSigVer = clientSigVer,
                Server = System.Environment.MachineName
            };
        }

        public static void saveTimedItem(TimedItem timedItem, Stopwatch watch)
        {
            var path = @"C:\Users\john kennerley\Dropbox\BerfWeb" + @"\" + @"TestTimeLog.txt";
            var json = JsonConvert.SerializeObject(timedItem);
            var f = String.Format("{0}{1}", Environment.NewLine, json);
            System.IO.File.AppendAllText(path, f);
        }
    }
}