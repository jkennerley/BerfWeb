[<AutoOpen>]
module FDac.DomainTypes

//open System

type Table =
    { Catalog : string
      TableName : string }

type Column =
    { Catalog : string
      TableName : string
      ColumnName : string
      DataType : string
      MaxLength : int }

type PKey =
    { Catalog : string
      TableName : string
      ColumnName : string
      ConstraintName : string
      Ord : int }

type DbMeta =
    { Tables : seq<Table>
      Pkeys : seq<PKey>
      Cols : seq<Column> }

type TableMeta =
    { Table : Table
      Pkeys : seq<PKey>
      Cols : seq<Column> }

type CodeElement =
    { Lang : string
      Type : string
      Code : string }

