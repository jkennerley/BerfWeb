namespace Berf.EfIntegrationTest
{
    using EfRepo;
    using EfTest;
    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
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
                .Select(BerfEfRepo.InsertBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero();
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
            var bs = this.getTestableInserts(n);

            // insert
            var insertedRets =
                bs
                .Select(BerfEfRepo.InsertBerfClient)
                .ToList();

            Func<BerfClient, BerfClient> lam = (x) =>
                {
                    x.source = "ITG_UPDATED_C#EF";
                    return x;
                };

            // update
            var updatedRets =
                bs
                .Select(x => lam(x))
                .Select(BerfEfRepo.UpdateBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero();
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
            var bs = this.getTestableInserts(n);

            // insert
            var insertedRets =
                bs
                .Select(BerfEfRepo.InsertBerfClient)
                .ToList();

            Func<BerfClient, BerfClient> lam = (x) =>
            {
                x.source = "ITG_DELETED_C#EF";
                return x;
            };

            // update
            var updatedRets =
                bs
                .Select(x => lam(x))
                .Select(BerfEfRepo.DeleteBerfClient)
                .ToList();

            // Log stop watch
            watch.Stop();
            var timedItem = TimedItem.TimedItemZero();
            //timedItem.Sig = thisFunctionName();
            timedItem.Sig = "delete_n_records_C#Ef";
            timedItem.SigId = "C#Ef";
            timedItem.Time = (float)watch.ElapsedMilliseconds;
            timedItem.Count = n;
            TimedItem.saveTimedItem(timedItem, watch);
        }
    }
}