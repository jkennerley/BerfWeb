namespace Berf.Data
{
    using Berf.DataEf;
    using BerfDacAltIntegrationTest.BerfDataEfContext;
    using System.Data.Entity;

    public class BerfEfDac
    {
        public BerfDbEntities Ctx { get; set; }

        public BerfEfDac(BerfDbEntities ctx)
        {
            this.Ctx = ctx;

            // anything that is lazy loaded will attempt to create the object that is behind them
            // watch out for circular dependencies, Topic gets replies but may also get Topics that they belong to
            // must eager load
            this.Ctx.Configuration.LazyLoadingEnabled = false;

            // handle change management in straightforward way ;
            // proxy gen can cause problems with serialization, can get props that are not really part of your models
            this.Ctx.Configuration.ProxyCreationEnabled = false;
        }

        public MiRet InsertBerfClient(BerfClient be)
        {
            var miRet = new MiRet { };

            try
            {
                this.Ctx.BerfClients.Add(be);
                miRet.IsOK = true;
            }
            catch (System.Exception ex)
            {
                miRet.IsOK = false;
            }

            return miRet;
        }

        public MiRet UpdateBerfClient(BerfClient be)
        {
            // Declaration
            var miRet = new MiRet { };

            // Code
            this.Ctx.BerfClients.Attach(be);

            this.Ctx.Entry(be).State = EntityState.Modified;

            // Return
            return miRet;
        }

        public MiRet DeleteBerfClient(BerfClient be)
        {
            // Declaration
            var miRet = new MiRet { };

            // Code
            this.Ctx.BerfClients.Attach(be);

            this.Ctx.Entry(be).State = EntityState.Deleted;

            // Return
            return miRet;
        }

        public MiRet Save()
        {
            var miRet = new MiRet { IsOK = false };

            try
            {
                miRet.IsOK = Ctx.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                var exMsg = ex.Message;
                miRet.IsOK = false;
            }

            return miRet;
        }

        /*

        public IQueryable<BerfClient> SelectBerfClient()
        {
            return Ctx.BerfClients;
        }

        public IQueryable<Idea> SelectIdeasWithNotes()
        {
            var ret = Ctx
                .Ideas
                .Include("Note");

            return ret;
        }

        public IQueryable<Idea> SelectIdeasWithAll()
        {
            var ret = Ctx
                .Ideas
                .Include("Notes");

            // Return
            return ret;
        }

        public IQueryable<Note> SelectNotesByIdea(Guid id)
        {
            return Ctx.Notes.Where(x => x.IdeaId == id);
        }

        public MiRet Save()
        {
            var miRet = new MiRet { IsOK = false };

            try
            {
                miRet.IsOK = Ctx.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                var exMsg = ex.Message;

                //if(ex != null)
                //{
                //    exMsg += string.Format( "{1}{0} " , System.Environment.NewLine , ex.Message );
                //    if (ex.InnerException != null)
                //    {
                //        exMsg += string.Format("{1}{0} ", System.Environment.NewLine, ex.InnerException.Message);
                //        if (ex.InnerException.InnerException != null)
                //        {
                //            exMsg += string.Format("{1}{0} ", System.Environment.NewLine, ex.InnerException.InnerException.Message);
                //        }
                //
                //    }
                //}

                //var exc = ex;
                //while (exc != null)
                //{
                //    exMsg += string.Format( "{1}{0} " , System.Environment.NewLine , exc.Message );
                //    if (exc.InnerException != null)
                //    {
                //        exc = exc.InnerException;
                //    }
                //}

                // TODO :: log error
                miRet.IsOK = false;
            }

            return miRet;
        }

        public Idea ReadIdea(Guid key)
        {
            object[] keys = { key };

            var ret = Ctx.Ideas.Find(keys);

            return ret;
        }

        public Note ReadNote(Guid key)
        {
            object[] keys = { key };

            var ret = Ctx.Notes.Find(keys);

            return ret;
        }

        public MiRet AddIdea(Idea be)
        {
            var miRet = new MiRet { };

            try
            {
                this.Ctx.Ideas.Add(be);

                miRet.IsOK = true;
            }
            catch (System.Exception ex)
            {
                miRet.IsOK = false;
                miRet.StatusCode = MiError.GetErrorCode(MiErrorEnum.ExceptionAddIdea);
                miRet.MessageUser = MiError.GetErrorText(MiErrorEnum.ExceptionAddIdea);
                miRet.MessageTech = ex.Message;
            }

            return miRet;
        }

        public MiRet AddNote(Note be)
        {
            // Declaration
            var miRet = new MiRet { };

            // Code

            try
            {
                this.Ctx.Notes.Add(be);
                miRet.IsOK = true;
            }
            catch (System.Exception)
            {
                miRet.IsOK = false;
            }

            // Return
            return miRet;
        }

        public MiRet UpdateIdea(Idea be)
        {
            // Declaration
            var miRet = new MiRet { };

            // Code
            this.Ctx.Ideas.Attach(be);

            this.Ctx.Entry(be).State = EntityState.Modified;

            // Return
            return miRet;

            //http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

            //db.Users.Attach(updatedUser);
            //db.Entry(updatedUser).State = EntityState.Modified;
            //db.SaveChanges();
            //this.Ctx.SaveChanges();
            //var ret = new AddRet { };
            //try
            //{
            //    this.Ctx.Ideas.Add(be);
            //    ret.IsOK = true;
            //}
            //catch (System.Exception)
            //{
            //    ret.IsOK = false;
            //}
        }

        public IQueryable<AspNetUser> SelectAspNetUsers()
        {
            var ret = Ctx
                .AspNetUsers
                ;

            // Return
            return ret;
        }

        public List<AspNetUser> GetAspNetUsersForIdeas(List<Idea> ideas)
        {
            // Code
            var userIds =
                ideas
                .Select(x => x.UserId)
                .Distinct();

            var aspNetUsers =
                this
                .SelectAspNetUsers()
                .Where(x => userIds.Contains(x.Id))
                .ToList();

            // Return
            return aspNetUsers;
        }

        */
    }
}