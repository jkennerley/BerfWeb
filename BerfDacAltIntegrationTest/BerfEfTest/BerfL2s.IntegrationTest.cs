namespace Berf.RepoL2s
{
    using EfRepo;
    using EfTest;
    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Xunit;

    public class BerfL2sIntegrationTest
    {
        public List<BerfDataContextDal.BerfClient> getTestableInserts(int n)
        {
            var xs = new List<BerfDataContextDal.BerfClient>();

            for (var i = 0; i < n; i++)
            {
                xs.Add(BerfClientL2sExtension.BerfClientZero());
            }

            return xs;
        }

        public readonly string SIGID  = "C#Ls";

        public string thisFunctionName()
        {
            var stackTrace = new StackTrace();
            var frame = stackTrace.GetFrame(1);
            return frame.GetMethod().Name;
        }

        [Theory]
        [InlineData(1000)]
        public void insert_n_records(int n)
        {
            // Arrange
        
            // Act
            var watch = new Stopwatch();
            watch.Start();
        
            // a record to be inserted and then read back
            var bs = this.getTestableInserts(n);
        
            var rets =
                bs
                .Select(x=> BerfL2sRepo.InsertBerfClient(x))
                .ToList();
        
            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero("", this.thisFunctionName(),SIGID, n, (float)watch.ElapsedMilliseconds);
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
            var bs = this.getTestableInserts(n);

            Func<BerfDataContextDal.BerfClient, BerfDataContextDal.BerfClient> lam = (x) =>
            {
                x.Source = "ITG_UPDATED_C#L2S";
                return x;
            };

            // insert
            var rets =
                bs
                .Select(x => BerfL2sRepo.InsertBerfClient(x))
                .ToList();

            // update
            var updatedRets =
                bs
                .Select(x => lam(x))
                .Select(BerfL2sRepo.UpdateBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero("", this.thisFunctionName(), SIGID, n, (float)watch.ElapsedMilliseconds);
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
            var bs = this.getTestableInserts(n);

            Func<BerfDataContextDal.BerfClient, BerfDataContextDal.BerfClient> lam = (x) =>
            {
                x.Source = "ITG_UPDATED_C#L2S";
                return x;
            };

            // insert
            var rets =
                bs
                .Select(x => BerfL2sRepo.InsertBerfClient(x))
                .ToList();

            // delete
            var updatedRets =
                bs
                .Select(x => lam(x))
                .Select( BerfL2sRepo.DeleteBerfClient )
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero("", this.thisFunctionName(), SIGID, n, (float)watch.ElapsedMilliseconds);
            TimedItem.saveTimedItem(timedItem, watch);
        }

        [Theory]
        [InlineData(1000)]
        public void read_n_records(int n)
        {
            // Arrange

            // Act
            var watch = new Stopwatch();
            watch.Start();

            // a record to be inserted and then read back
            var bs = this.getTestableInserts(n);

            Func<BerfDataContextDal.BerfClient, BerfDataContextDal.BerfClient> lam = (x) =>
            {
                x.Source = "ITG_UPDATED_C#L2S";
                return x;
            };

            // insert
            var rets =
                bs
                .Select(x => BerfL2sRepo.InsertBerfClient(x))
                .ToList();

            // read 
            var updatedRets =
                bs
                .Select(x => lam(x))
                .Select(BerfL2sRepo.ReadBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero("", this.thisFunctionName(), SIGID, n, (float)watch.ElapsedMilliseconds);
            TimedItem.saveTimedItem(timedItem, watch);
        }
    }
}