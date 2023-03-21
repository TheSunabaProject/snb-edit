using System;

namespace SNBEdit.Common.Shell.Commands
{
    /// <summary>
    /// Marks a command that is visible internally and isn't ever exposed to the user.
    /// </summary>
    public class InternalCommandAttribute : Attribute
    {
    }
}