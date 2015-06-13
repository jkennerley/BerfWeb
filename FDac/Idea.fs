[<AutoOpen>]
module FDac.Idea
 
    open System 

    let Zero =
        {
            Idea.Id             = Guid.Empty
            IdeaTypeEnum        = 0
            ParentId            = Guid.Empty
            StageEnum           = 0
            UserId              = String.Empty
            UiOrder             = 0.
            UiVisible           = int16 0
            Title               = String.Empty
            Tags                = String.Empty
            Body                = String.Empty
            Publish             = DateTime.Now
            Created             = DateTime.Now
            Updated             = DateTime.Now
        }

    let createDefaultTest () =
        {
            Idea.Id             = Guid.NewGuid()
            IdeaTypeEnum        = 1
            ParentId            = Guid.Empty
            StageEnum           = 1
            UserId              = String.Empty
            UiOrder             = 0.
            UiVisible           = int16 0
            Title               = String.Empty
            Tags                = String.Empty
            Body                = String.Empty
            Publish             = DateTime.Now
            Created             = DateTime.Now
            Updated             = DateTime.Now
        }
