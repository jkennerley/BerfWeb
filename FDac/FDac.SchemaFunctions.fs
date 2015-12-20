[<AutoOpen>]
module FDac.SchemaFunctions

///
//let getTablesList () =
//    let cmd  = new FDac.DataAccessSchema.SelectTables()
//
//    let xs = cmd.Execute()
//        
//    xs
//        |> Seq.map (fun x -> {Table.TableName = x.TABLE_NAME; Catalog = (defaultToEmpty x.TABLE_CATALOG) } )
//        |> Seq.toList

///
let getTables () =
    let cmd  = new FDac.DataAccessSchema.SelectTables()
    
    let xs = cmd.Execute()
        
    xs
        |> Seq.map (fun x -> {Table.TableName = x.TABLE_NAME; Catalog = (defaultToEmpty x.TABLE_CATALOG) } )
        |> Seq.toList

///
let getColumns =
    let cmd  = new FDac.DataAccessSchema.SelectColumns()

    let xs = cmd.Execute()

    xs 
    |> Seq.map (fun x -> 
        {
            Column.Catalog = ( defaultToEmpty x.TABLE_CATALOG) ; 
            TableName = x.TABLE_NAME; 
            ColumnName= (defaultToEmpty x.COLUMN_NAME) ; 
            DataType = ( defaultToEmpty x.DATA_TYPE) 
            MaxLength = (defaultTo0  x.CHARACTER_MAXIMUM_LENGTH )
        } )

///
let getTableColumns tableName (columns:seq<Column>) =
    columns 
        |> Seq.filter (fun x -> x.TableName = tableName)

///
let getPkeys =
    let cmd  = new FDac.DataAccessSchema.SelectPrimaryKey()

    let xs = cmd.Execute()

    xs
    |> Seq.map (fun x -> 
            { 
            PKey.Catalog = ( defaultToEmpty x.TABLE_CATALOG) ; 
            TableName = x.TABLE_NAME; 
            ColumnName= (defaultToEmpty x.COLUMN_NAME) ; 
            ConstraintName = x.CONSTRAINT_NAME ; 
            Ord = x.ORDINAL_POSITION
            }    
        )

///
let getPkeyColumns tableMeta =
    let pkeys = 
        tableMeta.Pkeys
        |> Seq.where( fun x -> x.TableName = tableMeta.Table.TableName) 
        |> Seq.toList

    let pkeyCols = 
        tableMeta.Cols 
        |> Seq.where (fun x -> 
            (pkeys |>  Seq.exists (fun y -> y.ColumnName = x.ColumnName  ) )
            )

    pkeyCols

///
let getTablePkey tableName (pkeys:seq<PKey>) =
    pkeys
    |> Seq.filter (fun x -> x.TableName = tableName)

///
let getNonPkeyColumns tableMeta =
    let pkeys = 
        tableMeta.Pkeys
        |> Seq.where( fun x -> x.TableName = tableMeta.Table.TableName) 
        |> Seq.toList

    tableMeta.Cols 
    |> Seq.where (fun x -> 
        (pkeys |>  Seq.exists(fun y -> y.ColumnName = x.ColumnName ) = false )
        )

/// 
let getPkeyFields tableMeta =
    let pkeyFields = 
        tableMeta.Pkeys
        |> Seq.where (fun x -> x.TableName = tableMeta.Table.TableName   )
        |> Seq.map (fun x -> sprintf "@%s" x.ColumnName ) 
        |> Seq.toList

    pkeyFields

///
let getNonPkeyColumnsSetList tableMeta =
    let xs  = getNonPkeyColumns tableMeta 

    let xs' = 
        xs
        |> Seq.map (fun x -> sprintf "%s = @%s" x.ColumnName x.ColumnName )
        |> Seq.toList

    xs'
        |> FDac.Util.toSeparatedString ", "

///
let getDeleteProcParams tableMeta=
    let pkeyCols = getPkeyColumns tableMeta

    let pkeyColsList = 
            
        let getTypeString (col:Column) = 
            let ret = 
                match col.DataType with 
                | "nvarchar" ->  sprintf "[%s](%s)" "nvarchar" (col.MaxLength.ToString())  
                | _ -> col.DataType 
            ret 

        pkeyCols  
        |> Seq.map (fun x -> 
            sprintf "@%s %s" x.ColumnName   (getTypeString x) ) 
        |> Seq.toList

    pkeyColsList  
        |> toSeparatedString ","

///
let getDeleteWherePredicate tableMeta =
    let pkeyCols = getPkeyColumns tableMeta

    let pkeyColsList = 
        pkeyCols  
        |> Seq.map (fun x -> sprintf "%s = @%s" x.ColumnName x.ColumnName  ) |> Seq.toList

    pkeyColsList  
        |> toSeparatedString ","

/// 
let getFieldsListString tableMeta =
    let fieldsList = 
        tableMeta.Cols
        |> Seq.where (fun x -> x.TableName = tableMeta.Table.TableName   )
        |> Seq.map (fun x -> sprintf "%s" x.ColumnName ) 
        |> Seq.toList

    fieldsList
        |> toSeparatedString ","

/// 
let getFieldsListStringWithAt tableMeta =
    tableMeta.Cols
        |> Seq.where (fun x -> x.TableName = tableMeta.Table.TableName )
        |> Seq.map (fun x -> sprintf "@%s" x.ColumnName ) 
        |> Seq.toList
        |> toSeparatedString ","

/// 
let getFieldsListStringWithPrePost tableMeta =
    tableMeta.Cols
        |> Seq.where (fun x -> x.TableName = tableMeta.Table.TableName )
        |> Seq.map (fun x -> sprintf "%s" x.ColumnName ) 
        |> Seq.toList
        |> toSeparated "be." ","

/// 
let getToBe tableMeta pre post mid=
    tableMeta.Cols
        |> Seq.where (fun x -> x.TableName = tableMeta.Table.TableName )
        |> Seq.map (fun x -> sprintf "%s = %s%s" x.ColumnName mid x.ColumnName ) 
        |> Seq.toList
        |> toSeparated pre post 

/// 
let getPkeyFieldsListStringWithPrePost tableMeta =
    tableMeta.Pkeys
        |> Seq.where (fun x -> x.TableName = tableMeta.Table.TableName )
        |> Seq.map (fun x -> sprintf "%s" x.ColumnName ) 
        |> Seq.toList
        |> toSeparated "be." ","

/// 
let getPkeyFieldsListStringWithAt tableMeta =
    let pkeyFields = getPkeyFields tableMeta

    pkeyFields 
        |> toSeparatedString ","

///
let getProcNamePrefix = 
    sprintf """lsp_""" 

///
let getInsertProcName tableMeta = 
    sprintf """Insert%s""" tableMeta.Table.TableName

///
let getUpsertProcName tableMeta = 
    sprintf """Upsert%s""" tableMeta.Table.TableName

///
let getUpdateProcName tableMeta = 
    sprintf """Update%s""" tableMeta.Table.TableName

///
let getReadProcName withNoLock tableMeta = 
    if withNoLock then 
        sprintf """Read%sWithNoLock""" tableMeta.Table.TableName
    else
        sprintf """Read%s""" tableMeta.Table.TableName

///
let getSelectProcName tableMeta = 
    sprintf """Select%s""" tableMeta.Table.TableName

///
let getDeleteProcName tableMeta = 
    sprintf """Delete%s""" tableMeta.Table.TableName

///
let getColsProcParams tableMeta  = 
    let getTypeString (col:Column) = 
        let ret = 
            match col.DataType ,col.MaxLength   with 
            | "nvarchar" , -1 ->  sprintf "[%s](%s)" "nvarchar" "MAX"  
            | "nvarchar", _ ->  sprintf "[%s](%s)" "nvarchar" (col.MaxLength.ToString())  
            | _ -> col.DataType 
        ret 

    let tableCols = 
        tableMeta.Cols
        |> Seq.filter (fun x -> x.TableName = tableMeta.Table.TableName)

    let colsList = 
        tableCols   
        |> Seq.map (fun x -> 
            sprintf "@%s %s" x.ColumnName (getTypeString x ) ) 
        |> Seq.toList

    colsList 
        |> toSeparatedString ","

///
let getPkeyProcParams tableMeta = 
    getDeleteProcParams tableMeta 

///
let getWhereClausePkeyPredicate tableMeta= 
    getDeleteWherePredicate tableMeta

///
let getInsertFSharp tableMeta  = 
    let fieldsListStringWithAt  = getFieldsListStringWithAt tableMeta

    let code = sprintf 
                        """
///
[<Literal>]
let lsp_Insert%sSqlAutoString = "exec lsp_Insert%s %s"

type Insert%s = SqlCommandProvider<lsp_Insert%sSqlAutoString, DataAccessConfig.CnString>

                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsListStringWithAt
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
          
    { Lang = FSHARP_TYPES ; Type = LANG_ELEMENT_INSERT ; Code = code }

///
let getInsertCrudFSharp tableMeta  = 
    let fieldsList = getFieldsListStringWithPrePost tableMeta

    let code = sprintf 
                        """
///
let insert%s (be : %s) =
    let cmd = new DataAccess.Insert%s()
    cmd.Execute
        (%s)

                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsList

    { Lang = FSHARP_CRUD ; Type = LANG_ELEMENT_INSERT ; Code = code }

///
let getUpdateCrudFSharp tableMeta  = 
    let fieldsList = getFieldsListStringWithPrePost tableMeta
    let code = sprintf 
                        """
///
let update%s (be : %s) =
    let cmd = new DataAccess.Update%s()
    cmd.Execute
        (%s)
                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsList

    { Lang = FSHARP_CRUD ; Type = LANG_ELEMENT_INSERT ; Code = code }


///
let getDeleteCrudFSharp tableMeta  = 
    let fieldsList = getPkeyFieldsListStringWithPrePost tableMeta
    let code = sprintf 
                        """
///
let delete%s (be : %s) =
    let cmd = new DataAccess.Delete%s()
    cmd.Execute (%s)
                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsList
    { Lang = FSHARP_CRUD ; Type = LANG_ELEMENT_INSERT ; Code = code }


///
let getReadCrudFSharp tableMeta  = 
    let fieldsList = getToBe tableMeta "" " ; " "d."
    let de2Be = sprintf 
                        """
    let be = match de with
        | Some(d) -> Some { %s.Zero with %s  } 
        | _ -> None
                        """ 
                        (tableMeta.Table.TableName)  
                        fieldsList 

    let code = sprintf 
    
                        """
///
let read%s (be : %s) =
    let cmd = new DataAccess.Read%s()
    let de = cmd.Execute (%s)
    %s
    be
                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (getPkeyFieldsListStringWithPrePost tableMeta)
                        de2Be 
    { Lang = FSHARP_CRUD ; Type = LANG_ELEMENT_INSERT ; Code = code }

///
let getReadWithNoLockCrudFSharp tableMeta  = 

    let fieldsList = getToBe tableMeta "" " ; " "d."
    let de2Be = sprintf 
                        """
    let be = match de with
        | Some(d) -> Some { %s.Zero with %s  } 
        | _ -> None
                        """ 
                        (tableMeta.Table.TableName)  
                        fieldsList 

    let code = sprintf 
                        """
///
let read%sNoLock (be : %s) =
    let cmd = new DataAccess.Read%sWithNoLock()
    let de = cmd.Execute (%s)
    %s
    be
                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (getPkeyFieldsListStringWithPrePost tableMeta)
                        de2Be 
    { Lang = FSHARP_CRUD ; Type = LANG_ELEMENT_INSERT ; Code = code }




///
let getUpsertCrudFSharp tableMeta  = 
    let fieldsList = getFieldsListStringWithPrePost tableMeta
    let code = sprintf 
                        """
///
let upsert%s (be : %s) =
    let cmd = new DataAccess.Upsert%s()
    cmd.Execute
        (%s)
                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsList
    { Lang = FSHARP_CRUD ; Type = LANG_ELEMENT_INSERT ; Code = code }

///
let getUpdateFSharp tableMeta  = 
    let fieldsListStringWithAt  = getFieldsListStringWithAt tableMeta

    let code = sprintf 
                        """
///
[<Literal>]
let lsp_Update%sSqlAutoString = "exec [dbo].[lsp_Update%s] %s"

type Update%s = SqlCommandProvider<lsp_Update%sSqlAutoString, DataAccessConfig.CnString>

                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsListStringWithAt
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
          
    { Lang = FSHARP_TYPES ; Type = LANG_ELEMENT_INSERT ; Code = code }


///
let getUpsertFSharp tableMeta  = 
    let fieldsListStringWithAt  = getFieldsListStringWithAt tableMeta
    let code = sprintf 
                        """
///
[<Literal>]
let lsp_Upsert%sSqlAutoString = "exec [dbo].[lsp_Upsert%s] %s"

type Upsert%s = SqlCommandProvider<lsp_Upsert%sSqlAutoString, DataAccessConfig.CnString>

                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        fieldsListStringWithAt
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
          
    { Lang = FSHARP_TYPES ; Type = LANG_ELEMENT_INSERT ; Code = code }


///
let getReadFSharpByLockStyle withNoLock tableMeta  = 
    let procNamePrefix  = getProcNamePrefix

    let procName = getReadProcName withNoLock tableMeta

    let procParams   = getPkeyFieldsListStringWithAt tableMeta

    let code = sprintf 
                        """
///
[<Literal>]
let %s%s_SqlAutoString = "exec %s%s %s"

type %s = SqlCommandProvider<%s%s_SqlAutoString, DataAccessConfig.CnString,SingleRow=true>

                        """ 
                        procNamePrefix  
                        procName
                        procNamePrefix  
                        procName
                        procParams   
                        procName
                        procNamePrefix  
                        procName
          
    { Lang = FSHARP_TYPES ; Type = LANG_ELEMENT_READ ; Code = code }

///
let getReadFSharp tableMeta  = 
    getReadFSharpByLockStyle false tableMeta  

///
let getReadFSharpWithNoLock tableMeta  = 
    getReadFSharpByLockStyle true tableMeta 
       
///
let getDeleteFSharp tableMeta = 
    let pkeyParamsWithAt  = getPkeyFieldsListStringWithAt tableMeta

    let code = sprintf 
                        """
///
[<Literal>]
let lsp_Delete%sSqlAutoString = "exec [dbo].[lsp_Delete%s] %s"


type Delete%s = SqlCommandProvider<lsp_Delete%sSqlAutoString, DataAccessConfig.CnString>

                        """ 
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
                        pkeyParamsWithAt
                        (tableMeta.Table.TableName)  
                        (tableMeta.Table.TableName)  
          
    { Lang = FSHARP_TYPES ; Type = LANG_ELEMENT_DELETE ; Code = code }

///    
let getInsertSql tableMeta = 
    let procNamePrefix  = getProcNamePrefix
    let proc = getInsertProcName tableMeta
    let procParams = getColsProcParams tableMeta
    let fieldsListString = getFieldsListString tableMeta
    let fieldsListStringWithAt  = getFieldsListStringWithAt tableMeta

    let sql = sprintf 
                    """
--***********
go 
drop proc %s%s
go 
create proc %s%s  
%s
as
begin
    insert into %s ( %s ) values ( %s )
end
go 
                    """ 
                    procNamePrefix  
                    proc    
                    procNamePrefix  
                    proc 
                    procParams 
                    (tableMeta.Table.TableName)
                    fieldsListString
                    fieldsListStringWithAt   

    { Lang = T_SQL ; Type = LANG_ELEMENT_INSERT  ; Code = sql }


///    
let getUpdateSql tableMeta = 
    let procNamePrefix  = getProcNamePrefix
    let procName = getUpdateProcName tableMeta
    let procParams = getColsProcParams tableMeta
    let nonPkeyUpdateSetAssignments = getNonPkeyColumnsSetList tableMeta 
    let pkeyWherePredicate = getWhereClausePkeyPredicate tableMeta 

    let sql = sprintf 
                    """
--***********
go 
drop proc %s%s
go 
create proc %s%s  
%s
as
begin
    update %s 
    set %s 
    where %s
end
go 
                    """ 
                    procNamePrefix
                    procName
                    procNamePrefix
                    procName
                    procParams 
                    (tableMeta.Table.TableName)
                    nonPkeyUpdateSetAssignments
                    pkeyWherePredicate  

    { Lang = T_SQL ; Type = LANG_ELEMENT_INSERT ; Code = sql }


///
let getDeleteSql tableMeta = 
    let procNamePrefix  = getProcNamePrefix
    let procName = getDeleteProcName tableMeta
    let procParas = getPkeyProcParams tableMeta
    let where = getWhereClausePkeyPredicate tableMeta 
    let sql = sprintf 
                    """
--***********
go 
drop proc %s%s
go 
create proc %s%s  
%s
as
begin
delete from %s 
where %s									 
end
go 
                    """ 
                    procNamePrefix  
                    procName
                    procNamePrefix  
                    procName 
                    procParas 
                    (tableMeta.Table.TableName)
                    where

    { Lang = T_SQL ; Type = LANG_ELEMENT_DELETE ; Code = sql }

///    
let getUpsertSql tableMeta = 
    let procNamePrefix  = getProcNamePrefix
    let proc = getUpsertProcName tableMeta
    let procParams = getColsProcParams tableMeta
    let fieldsListString = getFieldsListString tableMeta
    let fieldsListStringWithAt  = getFieldsListStringWithAt tableMeta
    let where = getWhereClausePkeyPredicate tableMeta 

    let sql = sprintf 
                    """
--***********
go 
drop proc %s%s
go 
create proc %s%s  
%s
as
begin
	if ( select count(*) from %s with (nolock) where %s ) > 0 
		exec lsp_Update%s %s 
	else
		exec lsp_Insert%s %s
end
go 
                    """ 
                    procNamePrefix  
                    proc    
                    procNamePrefix  
                    proc 
          
                    procParams 


                    (tableMeta.Table.TableName)
                    where
                    (tableMeta.Table.TableName)
                    fieldsListStringWithAt   
                    (tableMeta.Table.TableName)
                    fieldsListStringWithAt   


    { Lang = T_SQL ; Type = LANG_ELEMENT_INSERT  ; Code = sql }


///
let getReadSqlByLockStyle withNoLock tableMeta = 
    let procName = getReadProcName withNoLock tableMeta
    let withNoLockText = if withNoLock then " with (nolock) " else ""
    let procParams = getPkeyProcParams tableMeta
    let where = getWhereClausePkeyPredicate tableMeta 
    let cols = 
        tableMeta.Cols
        |> Seq.map (fun x -> x.ColumnName )
        |> Seq.toList

    let fieldsList = 
        cols 
        |> toSeparatedString ", "

    let sql = sprintf 
                    """
--***********
go 
drop proc %s%s
go 
create proc %s%s  
%s
as
begin
select %s 
from %s %s 
where %s									 
end
go 
                    """ 
                    getProcNamePrefix
                    procName 
                    getProcNamePrefix
                    procName  
                    procParams 
                    fieldsList
                    (tableMeta.Table.TableName)
                    withNoLockText
                    where

    { Lang = T_SQL ; Type = LANG_ELEMENT_DELETE ; Code = sql }

///
let getReadSql tableMeta = 
    getReadSqlByLockStyle false tableMeta 

///
let getReadWithNoLockSql tableMeta = 
    getReadSqlByLockStyle true tableMeta 

/// create {F#,T-SQL} language elements for some tables
let getLanguageElements tableMeta = 
    seq { 
            yield ( getInsertSql tableMeta )  
            yield ( getUpdateSql tableMeta )  
            yield ( getDeleteSql tableMeta ) 
            yield ( getReadSql tableMeta )  
            yield ( getReadWithNoLockSql tableMeta )  
            yield ( getUpsertSql tableMeta )  

            yield ( getInsertFSharp tableMeta ) 
            yield ( getUpdateFSharp tableMeta  )
            yield ( getDeleteFSharp tableMeta  )
            yield ( getReadFSharp tableMeta  )
            yield ( getReadFSharpWithNoLock tableMeta  )
            yield ( getUpsertFSharp tableMeta  )

            yield ( getInsertCrudFSharp tableMeta ) 
            yield ( getUpdateCrudFSharp tableMeta ) 
            yield ( getDeleteCrudFSharp tableMeta ) 
            yield ( getReadCrudFSharp tableMeta ) 
            yield ( getReadWithNoLockCrudFSharp tableMeta ) 
            yield ( getUpsertCrudFSharp tableMeta ) 
        }

let getDbMetaForWhiteList (tableNamesWhiteList: string list) = 
    let tables = getTables()
    let tables = 
        tables 
        |> Seq.where (fun x -> (tableNamesWhiteList |>  Seq.exists (fun y -> y = x.TableName) ))
        |> Seq.sortBy (fun x -> x.TableName  ) 
        |> Seq.toList

    let pkeys = 
        getPkeys 
        |> Seq.toList

    let cols = 
        getColumns 
        |> Seq.toList

    {DbMeta.Tables = tables ; Pkeys = pkeys ; Cols = cols }

///
let createTableMeta (table:Table) (dbMeta:DbMeta) = 
    let pkeys = 
        dbMeta.Pkeys 
        |> Seq.filter( fun x -> x.TableName = table.TableName )
        
    let cols = 
        dbMeta.Cols 
        |> Seq.filter( fun x -> x.TableName = table.TableName )

    {TableMeta.Table = table ; Pkeys = pkeys ; Cols = cols }

let getTableMetaCodeElementsForWhiteList (tablesWhiteList:string list) =
    let dbMeta  = getDbMetaForWhiteList tablesWhiteList 

    let langElementsGrouped = 
        dbMeta.Tables
        |> Seq.map (fun table -> 
            let tableMeta = ( createTableMeta table dbMeta )
            getLanguageElements tableMeta
            ) 

    let codeElementsFlat =
        langElementsGrouped 
        |> Seq.concat

    codeElementsFlat 
