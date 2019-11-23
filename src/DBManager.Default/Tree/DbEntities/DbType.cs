﻿using System.Runtime.Serialization;
using System.Text;

namespace DBManager.Default.Tree.DbEntities
{
	[DataContract(Name = "db-type")]
	public class DbType : DbObject
	{
		public override MetadataType Type => MetadataType.Type;

		public DbType(string name, int? length, int? precision, int? scale) : base(name)
		{
			Length = length;
			Precision = precision;
			Scale = scale;
		}

		[DataMember(Name = "length")]
		public int? Length { get; private set; }

		[DataMember(Name = "precision")]
		public int? Precision { get; private set; }

		[DataMember(Name = "scale")]
		public int? Scale { get; private set; }

        //TODO:CHANGE USING PRINTER
		public override string ToString()
		{
			StringBuilder name = new StringBuilder();
			name.Append($"{Name}");
			switch (Name)
			{
				case "nvarchar":
				case "varchar":
				case "nchar":
				case "сhar":
				case "varbinary":
				case "binary":
					name.Append(Length == -1 ? $"(max)" : $"({Length})");
					break;

				case "time":
				case "datetime2":
					name.Append($"({Scale})");
					break;

				case "decimal":
					name.Append($"({Precision},{Scale})");
					break;
				
			}
			return name.ToString();
		}
	}
}
