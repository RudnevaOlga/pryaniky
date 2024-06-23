using System.ComponentModel;

namespace Domain
{
    public enum OperationStatus
    {
        [Description("Successfully deleted")]
        Deleted = 0,

        [Description("Added successfully")]
        Add = 1,
    }
}
