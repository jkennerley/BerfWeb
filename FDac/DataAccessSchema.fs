[<AutoOpen>]
module FDac.DataAccessSchema 

    open FSharp.Data

    [<Literal>]
    let SelectTablesSql = """SELECT * FROM midb.information_schema.tables"""

    [<Literal>]
    let SelectColumnsSql = """SELECT * FROM midb.INFORMATION_SCHEMA.COLUMNS """

    [<Literal>]
    let SelectPrimaryKeySql = """
        SELECT * 
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1
        /*AND table_name = @table*/
    """

    type SelectTables = SqlCommandProvider<SelectTablesSql, FDac.DataAccessConfig.CnString>

    type SelectColumns = SqlCommandProvider<SelectColumnsSql, FDac.DataAccessConfig.CnString>

    type SelectPrimaryKey = SqlCommandProvider<SelectPrimaryKeySql, FDac.DataAccessConfig.CnString>




