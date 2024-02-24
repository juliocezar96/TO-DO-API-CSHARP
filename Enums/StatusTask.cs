using System.ComponentModel;

namespace crud.Enums
{
    public enum StatusTask
    {
        [Description("To do")]
        ToDo = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("Done")]
        Done = 3,

    }
}
