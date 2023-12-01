using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class OperationResult
    {
        public int RecordId { get; set; } = 0;
        public string Opration { get; set; }
        public string TableName { get; set; }
        public long OprationDate { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public string Message { get; set; }
        public bool Success { get; set; } = false;

        public OperationResult(string tablename)
        {
            TableName = tablename;
        }
    }
}
