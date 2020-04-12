using NPoco;
using System;

namespace UUMS.Services.Entities
{
    [TableName("App")]
    [PrimaryKey("Id", AutoIncrement = false)]
    [ExplicitColumns]
    class App
    {
        [Column]
        public Guid Id { get; set; }
        [Column]
        public string AppName { get; set; }
    }
}
