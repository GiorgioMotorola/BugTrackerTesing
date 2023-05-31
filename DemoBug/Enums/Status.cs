
using System.Runtime.Serialization;

namespace DemoBug.Enums
{
    public enum Status
    {
        Open,

        Assigned,
        
        Progress,

        Testing,

        Closed,

        Reopened,

        Duplicate,

        Deferred,
        
        Rejected
    }
}
