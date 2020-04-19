﻿using DBManager.Default;
using DBManager.Default.Loader.Sql;
using DBManager.Default.Tree;


namespace DBManager.SqlServer.Loader.AtomicLoaders
{
    class DatabaseLoader : BaseAtomicSqlLoader
    {
        public override MetadataType Type => MetadataType.Database;

        public DatabaseLoader(IDialectComponent components)
            : base(components)
        { }
    }
}